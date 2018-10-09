using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Globe
{
    public static string loadSceneName;
}

public class Loading : MonoBehaviour
{
    //异步对象
    private AsyncOperation async;

    [SerializeField]
    private Image blackMask;

    bool m_Fading=false;

    private void Update()
    {
        if (m_Fading == true)
        {
            //Fully fade in Image (1) with the duration of 2

            blackMask.CrossFadeAlpha(1f, 3.0f, false);

        }
        ////If the toggle is false, fade out to nothing (0) the Image with a duration of 2
        //if (m_Fading == false)
        //{
        //    blackMask.CrossFadeAlpha(0, 2.0f, false);

        //}

    }
    void OnGUI()
    {
        //Fetch the Toggle's state
        m_Fading = GUI.Toggle(new Rect(0, 0, 100, 30), m_Fading, "Fade In/Out");
    }

    public void StartGame(string sceneName)
    {
        if (sceneName == string.Empty)
            sceneName = "Game";

        Globe.loadSceneName = sceneName;

        StartCoroutine(LoadScene());

    }

    IEnumerator LoadScene()
    {
        blackMask.gameObject.SetActive(true);

        //异步读取场景
        async = SceneManager.LoadSceneAsync(Globe.loadSceneName);

        async.allowSceneActivation = false;

        yield return Gradient();

        if (async.progress == 0.9f)
        {
            async.allowSceneActivation = true;
        }

        yield return async;
    }

    IEnumerator Gradient()
    {
        m_Fading = true;

        yield return  new WaitForSeconds(3f);
    }
}
