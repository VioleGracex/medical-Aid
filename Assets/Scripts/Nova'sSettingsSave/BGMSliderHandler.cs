using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BGMSliderHandler : MonoBehaviour
{
    public static BGMSliderHandler instance { get; private set; }
    [SerializeField] public Slider slider;
    [SerializeField] AudioMixer bgmMixer;


    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        SetVisuals();

    }

    public void SetVisuals()
    {
        float placeholder;
        bgmMixer.GetFloat("BGMVolume", out placeholder);
        slider.value = placeholder;
    }

    public void ResetValue()
    {
        slider.value = 0;

    }
}
