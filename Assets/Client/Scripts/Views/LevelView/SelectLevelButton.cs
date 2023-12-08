using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SelectLevelButton : BaseWindow
{
    [SerializeField] private TextMeshProUGUI _levelNumTxt;
    [SerializeField] private Image _lockImage;
    [SerializeField] private Button _button;

    private ApplicationСalculations _applicationСalculations;
    private LevelsRoadPage _levelsRoadPage;
    
    private int _levelNum;

    private void Start()
    {
        _applicationСalculations.OnOpenLevel += UpdateView;
        
        _button.onClick.AddListener(() => _applicationСalculations.OpenLevel(_levelNum));
    }

    public void Initialize(int num, ApplicationСalculations applicationСalculations)
    {
        _applicationСalculations = applicationСalculations;
        _levelNum = num;
        _levelNumTxt.text = num.ToString();

        UpdateView();
    }

    private void UpdateView()
    {
        _levelNumTxt.gameObject.SetActive(ApplicationData.LevelCompleted + 1 >= _levelNum);
        _lockImage.gameObject.SetActive((ApplicationData.LevelCompleted + 1 < _levelNum));
    }
}
