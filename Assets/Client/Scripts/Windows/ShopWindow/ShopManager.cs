using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Purchasing;
using Zenject;

public class ShopManager : IInitializable
{
    
    private const string ShopPrefsKey = "shopKey";

    public event Action<GameEnums.ShopItemEnum> OnPurchaseSuccessEvent;

    [Inject] private IapManager _iapManager;
    
    public Dictionary<GameEnums.ShopItemEnum, ShopProduct> ShopRewards { get; private set; } = new Dictionary<GameEnums.ShopItemEnum, ShopProduct>()
    {
            {GameEnums.ShopItemEnum.Character1, new ShopProduct(){Price = 100, UnlockLevel = 0, ShopReward = new ShopReward(){RewardType = GameEnums.RewardType.Character}}},
            {GameEnums.ShopItemEnum.Character2, new ShopProduct(){Price = 200, UnlockLevel = 0, ShopReward = new ShopReward(){RewardType = GameEnums.RewardType.Character}}},
            {GameEnums.ShopItemEnum.Location1, new ShopProduct(){Price = 100, UnlockLevel = 5, ShopReward = new ShopReward(){RewardType = GameEnums.RewardType.Location}}},
            {GameEnums.ShopItemEnum.Location2, new ShopProduct(){Price = 200, UnlockLevel = 0, ShopReward = new ShopReward(){RewardType = GameEnums.RewardType.Location}}},
            {GameEnums.ShopItemEnum.Location3, new ShopProduct(){Price = 300, UnlockLevel = 7, ShopReward = new ShopReward(){RewardType = GameEnums.RewardType.Location}}},
    };
    
    
    public void Initialize()
    {
        _iapManager.OnProductsFetchedEvent += OnProductsFetched;
        _iapManager.OnPurchaseSuccessEvent += OnPurchaseSuccess;
        _iapManager.Initialize();
    }

    private void OnProductsFetched(ProductCollection productCollection)
    {
        foreach (var product in productCollection.all)
        {
            switch (product.definition.id)
            {
                case "com.epic.chest":
                  ShopRewards.Add(GameEnums.ShopItemEnum.EpicChest, new ShopProduct()
                  {
                      Price = product.metadata.localizedPrice,
                      Consumable = true,
                      UnlockLevel = 0,
                      RealPurchase =  true,
                      Id = "com.epic.chest",
                      ShopReward = new ShopReward(){RewardType = GameEnums.RewardType.Ticket, Count = 500},
                  });
                  break;
                
                case "com.lucky.chest":
                    ShopRewards.Add(GameEnums.ShopItemEnum.LuckyChest, new ShopProduct()
                    {
                        Price = product.metadata.localizedPrice,
                        Consumable = true,
                        UnlockLevel = 0,
                        RealPurchase =  true,
                        Id = "com.lucky.chest", 
                        ShopReward = new ShopReward(){RewardType = GameEnums.RewardType.Ticket, Count = 1200}
                    });
                    break;
            }
        }
    }

    private void OnPurchaseSuccess(Product product)
    {
        var type = ShopRewards.FirstOrDefault((pair => pair.Value.Id == product.definition.id)).Key;
        if (ShopRewards[type].ShopReward.RewardType == GameEnums.RewardType.Ticket)
        {
            ApplicationСurrency.AddCurrency(ApplicationСurrency.AppCurrency.Ticket, ShopRewards[type].ShopReward.Count);
        }
        OnPurchaseSuccessEvent?.Invoke(type);
    }
    
    
    public void BuyProduct(GameEnums.ShopItemEnum shopItemEnum)
    {
        
        if (ShopRewards[shopItemEnum].RealPurchase)
        {
            _iapManager.BuyProduct(ShopRewards[shopItemEnum].Id);
        }

        else
        {

            if(ApplicationСurrency.TicketCount < ShopRewards[shopItemEnum].Price ||
               ShopRewards[shopItemEnum].UnlockLevel > ApplicationData.LevelCompleted) return;
            

            ApplicationСurrency.SpendCurrency(ApplicationСurrency.AppCurrency.Ticket,Convert.ToInt32(ShopRewards[shopItemEnum].Price));
            if (!ShopRewards[shopItemEnum].Consumable)
            {
                PlayerPrefsExtensions.SetBool(shopItemEnum + ShopPrefsKey, true);
            }

            OnPurchaseSuccessEvent?.Invoke(shopItemEnum);
        }
    }

    public bool CheckPurchasedState(GameEnums.ShopItemEnum shopItemEnum)
    {
        if (ShopRewards[shopItemEnum].Consumable) return false;
        return PlayerPrefsExtensions.GetBool(shopItemEnum + ShopPrefsKey);
    }
}
