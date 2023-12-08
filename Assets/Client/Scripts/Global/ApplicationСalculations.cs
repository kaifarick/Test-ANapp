using System;
using Zenject;

public class ApplicationСalculations : IInitializable
{

    public event Action OnOpenLevel;
    
    
    public void Initialize()
    {
        CalculateDailyDayRow();
        
        ApplicationData.LastUserLoginTime = DateTime.Now;
    }

    private void CalculateDailyDayRow()
    {
        int daysWait = 1;
        
        var lastUserLogin = ApplicationData.LastUserLoginTime;
        var timeLeft = lastUserLogin == default ? new TimeSpan(1,0,0,0) : DateTime.Now.Date - lastUserLogin.Date ;

        if (timeLeft.Days > daysWait || 
            timeLeft.Days == daysWait && ApplicationData.DailyDaysCurrent == ApplicationData.MaxDailyDays)
        {
            ApplicationData.DailyDaysCollect = 0;
            ApplicationData.DailyDaysCurrent = 0;
            ApplicationData.DailyDaysCurrent++;
        }

        else if (timeLeft.Days == daysWait)
        {
            ApplicationData.DailyDaysCurrent++;
        }
    }
    
    public void OpenLevel(int level)
    {
        if (ApplicationData.LevelCompleted + 1 == level)
        {
            ApplicationData.LevelCompleted = level;
            OnOpenLevel?.Invoke();
        }
    }
}
