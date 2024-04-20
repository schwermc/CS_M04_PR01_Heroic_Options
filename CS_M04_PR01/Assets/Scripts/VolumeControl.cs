using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] string _volumeParameter = "MasterVolume";
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _slider;
    [SerializeField] float _multipler = 30f;
    [SerializeField] Toggle _toggle;

    bool _disableToggleEvent;

    void Awake()
    {
        _slider.onValueChanged.AddListener(HandleSliderValueChange);
        _toggle.onValueChanged.AddListener(HandleToggleValueChange);
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _slider.value);
    }

    void HandleToggleValueChange(bool enableSound)
    {
        if (_disableToggleEvent)
            return;

        if (enableSound)
            _slider.value = 0.8f;
        else
            _slider.value = _slider.minValue;
    }

    void HandleSliderValueChange(float value)
    {
        _mixer.SetFloat(_volumeParameter, Mathf.Log10(value) * _multipler);
        _disableToggleEvent = true;
        _toggle.isOn = _slider.value > _slider.minValue;
        _disableToggleEvent = false;
    }

    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volumeParameter, _slider.value);
    }
}
