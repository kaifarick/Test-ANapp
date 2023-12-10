using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    [SerializeField] private WindowsManager _windowsManager;
    [SerializeField] private AudioManager _audioManager;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<WindowsManager>().FromInstance(_windowsManager).AsSingle();
        Container.BindInterfacesAndSelfTo<AudioManager>().FromInstance(_audioManager).AsSingle();
        Container.BindInterfacesAndSelfTo<IapManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<ApplicationСalculations>().AsSingle();
        Container.BindInterfacesAndSelfTo<ShopManager>().AsSingle();
    }
}
