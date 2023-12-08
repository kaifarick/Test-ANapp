using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class SettingsWindow : BaseWindow, IPointerDownHandler
{
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _soundToggle;

    [SerializeField] private Image _musicImage;
    [SerializeField] private Image _soundImage;

    private Color32 _enableColor = new Color32(255, 255, 255, 255);
    private Color32 _disableColor = new Color32(255, 255, 255, 127);

    [Inject] private AudioManager _audioManager;

    private void Awake()
    {
        _musicToggle.onValueChanged.AddListener((arg0 =>
        {
            _musicImage.color = arg0 ? _enableColor : _disableColor;
            _audioManager.SwitchMusicState(arg0);
        }));
        _soundToggle.onValueChanged.AddListener((arg0 =>
        {
            _soundImage.color = arg0 ? _enableColor : _disableColor;
            _audioManager.SwitchSoundState(arg0);
        }));
    }

    private void Start()
    {
        _musicImage.color = _audioManager.MusicEnable ? _enableColor : _disableColor;
        _soundImage.color = _audioManager.SoundEnable ? _enableColor : _disableColor;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.pointerEnter.layer == LayerMask.NameToLayer("Ignore Raycast")) return;
        
        Hide();
    }
}
