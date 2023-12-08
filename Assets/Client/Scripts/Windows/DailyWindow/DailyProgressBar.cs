using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _counter;

    private int _lastCollectDay;
    private int _currentDay;

    private Action _onFillProgress;

    public void Initialize(int lastCollectDay, int currentDay, Action onFillProgress)
    {
        _slider.maxValue = ApplicationData.MaxDailyDays;
        _onFillProgress = onFillProgress;
        
        _lastCollectDay = lastCollectDay;
        _currentDay = currentDay;

        _slider.value = _lastCollectDay;
        _counter.text = $"{_currentDay}/{ApplicationData.MaxDailyDays}";
        
        FillProgress();
    }

    private void FillProgress()
    {
        if(_lastCollectDay == _currentDay) return;
        
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_slider.DOValue(_currentDay, 2));
        sequence.AppendCallback((() =>
        {
            if(!gameObject.activeInHierarchy) return;
            
            _counter.text = $"{_currentDay}/{ApplicationData.MaxDailyDays}";
            _onFillProgress?.Invoke();
        }));
    }

}
