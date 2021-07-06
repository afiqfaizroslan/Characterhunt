using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    public void Back()
    {
        SceneManager.UnloadSceneAsync("Setting");
        //SceneManager.LoadScene(next.previous);
        // Debug.Log("Active Scene index:" + next.previous);
    }
}
