using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VFXSliderHandler : MonoBehaviour
{
    public static VFXSliderHandler instance { get; private set; }
    [SerializeField] public Slider slider;
    [SerializeField] AudioMixer vfxMixer;


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
        vfxMixer.GetFloat("VFXVolume", out placeholder);
        slider.value = placeholder;
    }

    public void ResetValue()
    {
        slider.value = 0;

    }
}
