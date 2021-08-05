using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
  void Awake()
    {
        GameObject[] audio = GameObject.FindGameObjectsWithTag("BtnSound");
        if (audio.Length > 3)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);

    }
}
