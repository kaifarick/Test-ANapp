using Mopsicus.InfiniteScrollMod;
using UnityEngine;
using Zenject;

public class InfiniteScrollInitializer : MonoBehaviour
{
    [SerializeField] private InfiniteScrollMod scrollMod;
    [SerializeField] private int _itemHeight;
    [SerializeField] private int _count;

    [Inject] private ApplicationСalculations _applicationСalculations;

    void Start () 
    {
        scrollMod.OnFill += OnFillItem;
        scrollMod.OnHeight += OnHeightItem;

        scrollMod.InitData (_count);
    }

    void OnFillItem (int index, GameObject item)
    {
        item.GetComponentInChildren<LevelsRoadPage>().Initialize(index, _applicationСalculations);
    }

    int OnHeightItem (int index) {
        return _itemHeight;
    }
}
