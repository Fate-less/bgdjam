using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DayNightTime : MonoBehaviour
{
    public static DayNightTime instance;

    // Day-night cycle parameters
    public float dayDuration = 24f; // in seconds
    private float currentTime = 0f;
    private float intervalTime = 0f;

    // Other variables
    public TextMeshProUGUI timeTMP;
    private Scene currentScene;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() != currentScene)
        {
            try {
                timeTMP = GameObject.Find("menuBG").transform.Find("TimeTMP").gameObject.GetComponent<TextMeshProUGUI>();
            }
            catch {}
            currentScene = SceneManager.GetActiveScene();
        }
        DayNightCycle();
        if (currentTime > 24)
        {
            currentTime = 0;
        }
    }

    private void DayNightCycle()
    {
        intervalTime += Time.deltaTime;
        if(intervalTime > 20)
        {
            currentTime++;
            intervalTime = 0;
        }
        if (timeTMP != null)
        {
            timeTMP.text = currentTime.ToString() + ":00";
        }
    }

    private void SaveTime()
    {
        PlayerPrefs.SetFloat("SavedTime", currentTime);
    }

    private void LoadTime()
    {
        float savedTime = PlayerPrefs.GetFloat("SavedTime", 0f);
        currentTime = savedTime;
    }
}
