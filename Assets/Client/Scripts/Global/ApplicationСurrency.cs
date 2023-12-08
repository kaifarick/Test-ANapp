using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ApplicationСurrency
{

    public static event Action OnAddCurrency;

    public static int GetCurrency(AppCurrency appCurrency)
    {
        switch (appCurrency)
        {
            case AppCurrency.Ticket:
                return TicketCount;
            
            default: return TicketCount;
        }
    }

    public static void AddCurrency(AppCurrency appCurrency, int count)
    {
        switch (appCurrency)
        {
            case AppCurrency.Ticket:
                TicketCount += count;
                OnAddCurrency?.Invoke();
                break;
        }
    }
    
    
    
    
    
    
    public static int TicketCount
    {
        get { return PlayerPrefs.GetInt(TICKET_COUNT_KEY); }
        private set { PlayerPrefs.SetInt(TICKET_COUNT_KEY, value); }
    }
    
    private const string TICKET_COUNT_KEY = "tkcuk";
    
    public enum AppCurrency
    {
        Ticket
    }
}
