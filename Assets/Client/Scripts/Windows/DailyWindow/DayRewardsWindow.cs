using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DayRewardsWindow : BaseWindow, IPointerDownHandler
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _rewardCount;

    public void Initialize(int day, int count)
    {
        _title.text = $"DAY {day}";
        _rewardCount.text = $"X{count}";
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Hide();
    }
}
