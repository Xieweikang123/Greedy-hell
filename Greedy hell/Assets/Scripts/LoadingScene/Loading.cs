using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Globe
{
    public static string loadSceneName;
}

public class Loading : MonoBehaviour
{


    public void StartGame(string sceneName)
    {
        if (sceneName == string.Empty)
            sceneName = "Game";

        Globe.loadSceneName = sceneName;

        SceneManager.LoadScene("Transitions");
    }
}
