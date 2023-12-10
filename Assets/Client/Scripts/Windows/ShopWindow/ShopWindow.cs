using System;
using UnityEngine;
using Zenject;

public class ShopWindow : BaseWindow
{

    [SerializeField] private ShopItemView[] _shopItemView;

    [Inject] private ShopManager _shopManager;

    public event Action<GameEnums.ShopItemEnum> OnPurchaseSuccessEvent;
    private void Awake()
    {
        _closeButton.onClick.AddListener(Hide);
    }

    private void Start()
    {
        _shopManager.OnPurchaseSuccessEvent += OnPurchaseSuccess;
    }

    public void Initialize()
    { 
        for (int i = 0; i < _shopItemView.Length; i++)
        {
            var shopReward = _shopManager.ShopRewards[_shopItemView[i].ShopEnum];
            var isPurchased = _shopManager.CheckPurchasedState(_shopItemView[i].ShopEnum);
            
            _shopItemView[i].Initialize(this, shopReward, isPurchased, OnBuyButtonClick);
        }
    }

    private void OnBuyButtonClick(GameEnums.ShopItemEnum shopItemEnum)
    {
        _shopManager.BuyProduct(shopItemEnum);
    }

    private void OnPurchaseSuccess(GameEnums.ShopItemEnum shopItemEnum)
    {
        OnPurchaseSuccessEvent?.Invoke(shopItemEnum);
    }


    private void Reset()
    {
        _shopItemView = GetComponentsInChildren<ShopItemView>();
    }
}
