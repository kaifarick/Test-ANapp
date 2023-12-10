using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class DailyRewardsWindow : BaseWindow, IPointerDownHandler
{
    [SerializeField] private DailyProgressBar _dailyProgressBar;
    [SerializeField] private List<DailyDayIcon> _dailyDayIcons;

    [Inject] private WindowsManager _windowsManager;

    private Dictionary<int, int> _dayRewards = new Dictionary<int, int>() {{1, 5}, {2, 5}, {3, 10}, {4, 10}, {5, 15}, {6, 15}, {7, 5}};

    public event Action<int> OnCollectDailyReward;
    
    

    private void Start()
    {
        SetDailyDays();
    }

    public void Initialize()
    {
        _dailyProgressBar.Initialize(ApplicationData.DailyDaysCollect, ApplicationData.DailyDaysCurrent, CollectDailyReward);
    }

    private void SetDailyDays()
    {
        int dayNum = 1;
        foreach (var day in _dailyDayIcons)
        {
            day.Initialize(this, dayNum,_dayRewards[dayNum], ApplicationData.DailyDaysCollect);
            dayNum++;
        }
    }

    private void CollectDailyReward()
    {
        if (ApplicationData.DailyDaysCollect < ApplicationData.DailyDaysCurrent)
        {
            ApplicationData.DailyDaysCollect = ApplicationData.DailyDaysCurrent;
            ApplicationСurrency.AddCurrency(ApplicationСurrency.AppCurrency.Ticket, _dayRewards[ApplicationData.DailyDaysCurrent]);
            
            _windowsManager.OpenWindow<DayRewardsWindow>().Initialize(ApplicationData.DailyDaysCurrent,_dayRewards[ApplicationData.DailyDaysCurrent]);
            OnCollectDailyReward?.Invoke(ApplicationData.DailyDaysCurrent);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Hide();
    }
}
