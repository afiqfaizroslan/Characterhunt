using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backach : MonoBehaviour
{
    public void Back()
    {
        SceneManager.UnloadSceneAsync("Achievement");
        //SceneManager.LoadScene(next.previous);
        // Debug.Log("Active Scene index:" + next.previous);
    }
}
