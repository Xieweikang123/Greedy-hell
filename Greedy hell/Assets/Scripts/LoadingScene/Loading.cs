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

    private void OnEnable()
    {
        blackMask.gameObject.SetActive(true);
        StartCoroutine(GradientHide());

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

        yield return GradientShow();

        if (async.progress == 0.9f)
        {
            async.allowSceneActivation = true;
        }

        yield return async;
    }

    IEnumerator GradientShow()
    {
        while (blackMask.color.a < 1f)
        {
            blackMask.color += new Color(0, 0, 0, 0.1f);

            yield return new WaitForSeconds(0.05f);
        }
     
    }
    IEnumerator GradientHide()
    {
        while (blackMask.color.a > 0f)
        {
            blackMask.color -= new Color(0, 0, 0, 0.1f);

            yield return new WaitForSeconds(0.05f);
        }
        blackMask.gameObject.SetActive(false);
    }

}
