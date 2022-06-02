using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.IO;

public class JsonSettingsSaveFiles : MonoBehaviour
{

    [HideInInspector] public string settingsFileDestination = string.Empty;
    [HideInInspector] public SettingsSaveClass settingsData = new SettingsSaveClass();
    [SerializeField] AudioMixer bgmAudioMixer;
    [SerializeField] AudioMixer vfxAudioMixer;


    void Start()
    {
        settingsFileDestination = Application.persistentDataPath + "Settings.json";
        LoadSettings();
    }


    public void SaveSettings()
    {
        // add  GetResolutionSettings()
        WriteSettingsToJson(GetFullScreenSettings(), GetVFXVolumeSettings(), GetBGMVolumeSettings());
    }

    public void LoadSettings()
    {
        ReadSettingsFromJson();
        SetFullScreen(settingsData.fullscreen);
        SetBGMVolumeSettings(settingsData.bgmVolume);
        SetVFXVolumeSettings(settingsData.vfxVolume);
        //SetResolutionSettings(settingsData.resolution, settingsData.fullscreen);
    }
    public void ResetSettingsToDefault()
    {
        //resolutions always come before fullscreen
        // SetResolutionSettings(1080, true);
        SetFullScreen(true);
        // the zero is a hard coded value of default u can edit that if u want
        SetVFXVolumeSettings(0);
        VFXSliderHandler.instance.SetVisuals();
        SetBGMVolumeSettings(0);
        BGMSliderHandler.instance.SetVisuals();

    }
    //add an int resolution
    void WriteSettingsToJson(bool fullscreen, float vfxVolume, float bgmVolume)
    {

        settingsData.fullscreen = fullscreen;
        //settingsData.resolution = resolution;
        settingsData.vfxVolume = vfxVolume;
        settingsData.bgmVolume = bgmVolume;
        System.IO.File.WriteAllText(settingsFileDestination, JsonUtility.ToJson(settingsData));
    }
    void ReadSettingsFromJson()
    {
        bool doesFileExist = File.Exists(settingsFileDestination);
        if (doesFileExist)
        {

            settingsData = JsonUtility.FromJson<SettingsSaveClass>(File.ReadAllText(settingsFileDestination));
        }
        else
        {
            WriteSettingsToJson(GetFullScreenSettings(), GetVFXVolumeSettings(), GetBGMVolumeSettings());
            settingsData = JsonUtility.FromJson<SettingsSaveClass>(File.ReadAllText(settingsFileDestination));
        }
        settingsData = JsonUtility.FromJson<SettingsSaveClass>(File.ReadAllText(settingsFileDestination));

    }
    private void SetBGMVolumeSettings(float volume)
    {
      
        bgmAudioMixer.SetFloat("BGMVolume", volume);
    }
    private float GetBGMVolumeSettings()
    {
        float placeholder;
        bgmAudioMixer.GetFloat("BGMVolume", out placeholder);
        return placeholder;

    }
    private void SetVFXVolumeSettings(float volume)
    {

        vfxAudioMixer.SetFloat("VFXVolume", volume);
    }
    private float GetVFXVolumeSettings()
    {
        float placeholder;
        vfxAudioMixer.GetFloat("VFXVolume", out placeholder);
        return placeholder;

    }
    private void SetFullScreen(bool fullscreen)
    {

        Screen.fullScreen = fullscreen;
    }
    private bool GetFullScreenSettings()
    {
        return Screen.fullScreen;
    }

    /*/ private void SetResolutionSettings(int resolution, bool fullscreen)
      {
          if (FindObjectOfType<OptionsMenu>() != null)
          {
              FindObjectOfType<OptionsMenu>().ChangeResoltuion(resolution);
          }
          else
          {
              switch (resolution)
              {
                  case 0:
                      Screen.SetResolution(800, 600, fullscreen);
                      break;
                  case 1:
                      Screen.SetResolution(1280, 800, fullscreen);
                      break;
                  case 2:
                      Screen.SetResolution(1024, 576, fullscreen);
                      break;
                  case 3:
                      Screen.SetResolution(1024, 768, fullscreen);
                      break;
                  case 4:
                      Screen.SetResolution(1680, 1050, fullscreen);
                      break;
                  case 5:
                      Screen.SetResolution(1280, 720, fullscreen);
                      break;
                  case 6:
                      Screen.SetResolution(1920, 1440, fullscreen);
                      break;
                  case 7:
                      Screen.SetResolution(1920, 1200, fullscreen);
                      break;
                  case 8:
                      Screen.SetResolution(1920, 1080, fullscreen);
                      break;
                  default:
                      Screen.SetResolution(1920, 1080, fullscreen);
                      break;
              }
          }
      }

      private int GetResolutionSettings()
      {
          int resolutionIndex;
          switch (Screen.height)
          {
              case 600:
                  resolutionIndex = 0;
                  break;
              case 800:
                  resolutionIndex = 1;
                  break;
              case 576:
                  resolutionIndex = 2;
                  break;
              case 768:
                  resolutionIndex = 3;
                  break;
              case 1050:
                  resolutionIndex = 4;
                  break;
              case 720:
                  resolutionIndex = 5;
                  break;
              case 1440:
                  resolutionIndex = 6;
                  break;
              case 1200:
                  resolutionIndex = 7;
                  break;
              case 1080:
                  resolutionIndex = 8;
                  break;

              default:
                  resolutionIndex = 8;
                  break;
          }
          return resolutionIndex;
      }/*/


}
