
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    [SerializeField] private WindowsManager _windowsManager;
    [SerializeField] private AudioManager audioManager;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ApplicationСalculations>().AsSingle();
        Container.BindInterfacesAndSelfTo<WindowsManager>().FromInstance(_windowsManager).AsSingle();
        Container.BindInterfacesAndSelfTo<AudioManager>().FromInstance(audioManager).AsSingle();
    }
}
