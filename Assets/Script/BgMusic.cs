using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BgMusic : MonoBehaviour
{
    public AudioMixer mixer;
    
    void Awake()
    {
        

        GameObject[] audio = GameObject.FindGameObjectsWithTag("BgMusic");
        if (audio.Length > 1)
            Destroy(this.gameObject);

       

        DontDestroyOnLoad(this.gameObject);

    }

    void Update()
    {
        float value1 = PlayerPrefs.GetFloat("MainVol");
        mixer.SetFloat("MainVol", Mathf.Log10(value1) * 20);

        float value2 = PlayerPrefs.GetFloat("MusicVol");
        mixer.SetFloat("musicVol", Mathf.Log10(value2) * 20);

        float value3 = PlayerPrefs.GetFloat("FxVol");
        mixer.SetFloat("FxVol", Mathf.Log10(value3) * 20);

      
    }
}