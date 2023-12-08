using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ApplicationData
{
    
    #region PlayerPrefs

    #region DailyRewards
    
    public static DateTime LastUserLoginTime
    {
        get { return PlayerPrefsExtensions.GetDate(LAST_USER_LOGIN_TIME_KEY); }
        set { PlayerPrefsExtensions.SetDate(LAST_USER_LOGIN_TIME_KEY, value); }
    }
    
    public static int DailyDaysCurrent
    {
        get { return PlayerPrefs.GetInt(DAILY_DEYS_CURRENT_KEY); }
        set { PlayerPrefs.SetInt(DAILY_DEYS_CURRENT_KEY, value); }
    }
    
    public static int DailyDaysCollect
    {
        get { return PlayerPrefs.GetInt(DAILY_DEYS_COLLECT_KEY); }
        set { PlayerPrefs.SetInt(DAILY_DEYS_COLLECT_KEY, value); }
    }
    
    public static int MaxDailyDays => 6;

    #endregion
    
    public static int LevelCompleted
    {
        get { return PlayerPrefs.GetInt(LEVEL_COMPLETED_KEY); }
        set { PlayerPrefs.SetInt(LEVEL_COMPLETED_KEY, value); }
    }
    

    #region PlayerPrefsKey

    private const string LAST_USER_LOGIN_TIME_KEY = "lultk";
    private const string DAILY_DEYS_CURRENT_KEY = "ddcrk";
    private const string DAILY_DEYS_COLLECT_KEY = "ddclk";
    private const string LEVEL_COMPLETED_KEY = "lvlcpldk";

    #endregion


    #endregion
}
