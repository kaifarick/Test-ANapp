using System.Collections.Generic;
using UnityEngine;


public class LevelsRoadPage : MonoBehaviour
{
    [SerializeField] private List<SelectLevelButton> _levelMenuViews;
    [SerializeField] private int LevelsOnPage => 7;
    

    public void Initialize(int pageIndex, ApplicationСalculations applicationСalculations)
    {
        int currentLevel = pageIndex * LevelsOnPage + 1;

        foreach (var levelMenuView in _levelMenuViews)
        {
            levelMenuView.Initialize(currentLevel,applicationСalculations);
            currentLevel++;
        }
    }
}
