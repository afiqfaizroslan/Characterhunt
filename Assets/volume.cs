using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volume : MonoBehaviour
{

    public AudioMixer mixer;
    public Slider sliderMain;
    public Slider sliderMusic;
    public Slider sliderFX;


    void Start()
    {


        sliderMain.value = PlayerPrefs.GetFloat("MainVol", 0.75f);
        sliderMusic.value = PlayerPrefs.GetFloat("MusicVol", 0.75f);
        sliderFX.value = PlayerPrefs.GetFloat("FxVol", 0.75f);

    }

    public void SetMain(float sliderValue)
    {
        mixer.SetFloat("MainVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MainVol", sliderValue);
    }

    public void SetMusic(float sliderValue)
    {
        mixer.SetFloat("musicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVol", sliderValue);
    }

    public void SetFX(float sliderValue)
    {
        mixer.SetFloat("FxVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("FxVol", sliderValue);
    }




}