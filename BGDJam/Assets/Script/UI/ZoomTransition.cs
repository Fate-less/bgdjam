using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomTransition : MonoBehaviour
{
    public GameObject zoomObject;
    public SceneHandler sceneHandler;
    private string sceneName;

    private void Awake()
    {
        LeanTween.reset();
        Time.timeScale = 1f;
    }
    public void TransisiStart(string sceneName)
    {
        this.sceneName = sceneName;
        if(sceneName == "PC")
        {
            LeanTween.scale(zoomObject, new Vector3(2, 2, 1f), 2).setEase(LeanTweenType.easeOutQuart);
            LeanTween.moveLocal(zoomObject, new Vector2(423, -123), 2).setEase(LeanTweenType.easeOutQuart);
            StartCoroutine(timer());
        }
        if(sceneName == "TwoStepVerification")
        {
            LeanTween.scale(zoomObject, new Vector3(2.5f, 2.5f, 1f), 2).setEase(LeanTweenType.easeOutQuart);
            LeanTween.moveLocal(zoomObject, new Vector2(0, -234), 2).setEase(LeanTweenType.easeOutQuart);
            StartCoroutine(timer());
        }
        if (sceneName == "SortingReports")
        {
            LeanTween.scale(zoomObject, new Vector3(2, 2, 1f), 2).setEase(LeanTweenType.easeOutQuart);
            LeanTween.moveLocal(zoomObject, new Vector2(-423, 23), 2).setEase(LeanTweenType.easeOutQuart);
            StartCoroutine(timer());
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);
        sceneHandler.OpenScene(sceneName);
    }
}
