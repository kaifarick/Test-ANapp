using System;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine;
using UnityEngine.Purchasing;

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
                
                Debug.Log("UnityServiceInitialize");
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
        Debug.Log($"OnInitializeFailed {error}");
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log($"OnInitializeFailed {error} {message}");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        OnPurchaseSuccessEvent?.Invoke(purchaseEvent.purchasedProduct);
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"OnPurchaseFailed {product} {failureReason}");
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
