using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{

    [Header("Icon")]
    [SerializeField] private GameObject _blockImage;
    [SerializeField] private GameObject _iconImage;
    [SerializeField] private TextMeshProUGUI _rewardCountTxt;
    [SerializeField] private TextMeshProUGUI _lockLvlTxt;

    [Space]
    [Header("PriceButton")]
    [SerializeField] private GameObject _priceImage;
    [SerializeField] private GameObject _successImage;
    
    [SerializeField] private TextMeshProUGUI _priceTxt;
    [SerializeField] private Button _button;
    
    [SerializeField] private GameEnums.ShopItemEnum _shopEnum;
    public GameEnums.ShopItemEnum ShopEnum => _shopEnum;
    private ShopProduct _shopProduct;
    private ShopWindow _shopWindow;

    private event Action<GameEnums.ShopItemEnum> _onBuyButonClick;
    private bool _isPurchased;

    private void Awake()
    {
        _button.onClick.AddListener((() => _onBuyButonClick?.Invoke(_shopEnum)));
    }

    private void Start()
    {

        _shopWindow.OnPurchaseSuccessEvent += (shopItemEnum =>
        {
            if (shopItemEnum == _shopEnum)
            {
                if (!_shopProduct.Consumable) _isPurchased = true;
                UpdateView();
            }
        });
    }

    public void Initialize(ShopWindow shopWindow, ShopProduct shopProduct, bool isPurchased, Action<GameEnums.ShopItemEnum> onBuyButtonClick)
    {
        _onBuyButonClick = onBuyButtonClick;
        _shopProduct = shopProduct;
        _isPurchased = isPurchased;
        _shopWindow = shopWindow;
        
        UpdateView();
        
    }

    private void UpdateView()
    {
        _priceTxt.text = _shopProduct.RealPurchase ? $"{_shopProduct.Price}$" : _shopProduct.Price.ToString();
        _rewardCountTxt.text = _shopProduct.ShopReward.Count.ToString();
        _lockLvlTxt.text = $"LV. {_shopProduct.UnlockLevel}";

        _blockImage.SetActive(_shopProduct.UnlockLevel > ApplicationData.LevelCompleted);
        _iconImage.SetActive(ApplicationData.LevelCompleted >= _shopProduct.UnlockLevel);
        
        _priceImage.SetActive(!_isPurchased);
        _successImage.SetActive(_isPurchased);
    }
}
