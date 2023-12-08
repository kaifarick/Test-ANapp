using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ticketCount;
    [SerializeField] private LevelsView _levelsView;
    
    [Space]
    [Header("Buttons")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _dailyRewardsButton;
    [SerializeField] private Button _shopButton;

    [Inject] private WindowsManager _windowsManager;

    void Awake()
    {
        _dailyRewardsButton.onClick.AddListener(() => _windowsManager.OpenWindow<DailyRewardsWindow>().Initialize());
        _settingsButton.onClick.AddListener(() => _windowsManager.OpenWindow<SettingsWindow>());
        _playButton.onClick.AddListener((() => _levelsView.Initialize()));

        ApplicationСurrency.OnAddCurrency += UpdateView;
    }

    private void Start()
    {
        UpdateView();
    }

    private void UpdateView()
    {
        ticketCount.text = ApplicationСurrency.GetCurrency(ApplicationСurrency.AppCurrency.Ticket).ToString();
    }

}
