using System;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine;
using UnityEngine.Purchasing;
using Zenject;

public class IapManager : IStoreListener
{
    public event Action<ProductCollection> OnProductsFetchedEvent;
    public event Action<Product> OnPurchaseSuccessEvent;

    private IStoreController _storeController;
    

    public void Initialize()
    {
        async void InitializeGameService()
        {

            try
            {
                var options = new InitializationOptions()
                    .SetEnvironmentName("production");

                await UnityServices.InitializeAsync(options);
            }
            catch (Exception exception)
            {
                Debug.Log(exception);
            }
        }
        
        InitializeGameService();


        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct("com.epic.chest", ProductType.Consumable, new IDs
        {
            {"com.epic.chest", GooglePlay.Name},
        });
        
        builder.AddProduct("com.lucky.chest", ProductType.Consumable, new IDs
        {
            {"com.lucky.chest", GooglePlay.Name},
        });

        UnityPurchasing.Initialize(this, builder);
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        //throw new NotImplementedException();
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        //throw new NotImplementedException();
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        OnPurchaseSuccessEvent?.Invoke(purchaseEvent.purchasedProduct);
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        //throw new NotImplementedException();
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        _storeController = controller;
        OnProductsFetchedEvent?.Invoke(controller.products);
    }
    
    public void BuyProduct(string productId) 
    {
        _storeController.InitiatePurchase(productId);
    }

}
