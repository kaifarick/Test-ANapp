
using UnityEngine;
using UnityEngine.Purchasing;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    [SerializeField] private WindowsManager _windowsManager;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private IapManager _iapManager;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<WindowsManager>().FromInstance(_windowsManager).AsSingle();
        Container.BindInterfacesAndSelfTo<AudioManager>().FromInstance(_audioManager).AsSingle();
        Container.BindInterfacesAndSelfTo<IapManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<ApplicationСalculations>().AsSingle();
        Container.BindInterfacesAndSelfTo<ShopManager>().AsSingle();
    }
}
