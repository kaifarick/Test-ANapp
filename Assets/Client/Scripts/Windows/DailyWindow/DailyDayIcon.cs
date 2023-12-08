using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyDayIcon : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dayText;
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;

    private int _day;
    private int _count;

    private DailyRewardsWindow _dailyRewardsWindow;

    private Color32 _standartColor = new Color32(217, 217, 217, 225);
    private Color32 _collectColor = new Color32(91, 187, 46, 225);
    
    public void Initialize(DailyRewardsWindow dailyRewardsWindow, int day, int count, int collectDays)
    {
        _dailyRewardsWindow = dailyRewardsWindow;
        _day = day;
        _count = count;
        
        _dailyRewardsWindow.OnCollectDailyReward += Collect;
        
        SetDefaultView();
        Collect(collectDays);
        
    }

    private void Collect(int day)
    {
        if(_day > day) return;
        _image.color = _collectColor;
    }

    private void SetDefaultView()
    {
        _dayText.text = $"DAY{_day}";
        _countText.text = $"X{_count}";

        _image.color = _standartColor;
    }
}
