using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyDayIcon : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dayText;
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private Image _image;

    private int _thisDay;
    private int _rewardCount;

    private DailyRewardsWindow _dailyRewardsWindow;

    private Color32 _standartColor = new Color32(217, 217, 217, 225);
    private Color32 _collectColor = new Color32(91, 187, 46, 225);
    
    public void Initialize(DailyRewardsWindow dailyRewardsWindow, int thisDay, int rewardCount, int collectDays)
    {
        _dailyRewardsWindow = dailyRewardsWindow;
        _thisDay = thisDay;
        _rewardCount = rewardCount;
        
        _dailyRewardsWindow.OnCollectDailyReward += Collect;
        
        SetDefaultView();
        Collect(collectDays);
        
    }

    private void Collect(int day)
    {
        if(_thisDay > day) return;
        _image.color = _collectColor;
    }

    private void SetDefaultView()
    {
        _dayText.text = $"DAY{_thisDay}";
        _countText.text = $"X{_rewardCount}";

        _image.color = _standartColor;
    }
}
