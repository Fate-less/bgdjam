using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DayNightTime : MonoBehaviour
{
    public static DayNightTime instance;

    // Day-night cycle parameters
    public float dayCount = 1f;
    public float currentTime = 9f;
    private float intervalTime = 0f;

    // Other variables
    public TextMeshProUGUI timeTMP;
    public TextMeshProUGUI dayTMP; //temporary
    private Scene currentScene;
    public DiffSeed gameManager;
    public TaskManager taskManager;
    public Popup popUp;

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
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<DiffSeed>();
        taskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
        try{
            popUp = GameObject.Find("Bubblechat").GetComponent<Popup>();
        }
        catch {}
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() != currentScene)
        {
            try {
                timeTMP = GameObject.Find("menuBG").transform.Find("Alarm").transform.Find("TimeTMP").gameObject.GetComponent<TextMeshProUGUI>();
            }
            catch {}
            try
            {
                dayTMP = GameObject.Find("menuBG").transform.Find("dayTMP").gameObject.GetComponent<TextMeshProUGUI>();
            }
            catch { }
            currentScene = SceneManager.GetActiveScene();
        }
        DayNightCycle();
        if(currentTime > 15)
        {
            PlayerPrefs.SetString("EyeGlitch", "true");
        }
        if(currentTime > 17)
        {
            PlayerPrefs.SetString("CursorGlitch", "true");
        }
        if (currentTime > 18)
        {
            currentTime = 9;
            dayCount++;
            SceneManager.LoadScene("Shop");
            if (dayCount == 3)
            {
                dayCount = 7;
            }
            if (dayCount == 8)
            {
                dayCount = 9;
            }
            if (dayCount == 10)
            {
                dayCount = 17;
            }
            if (dayCount == 23)
            {
                dayCount = 26;
            }
            if (dayCount == 27)
            {
                dayCount = 29;
            }
            taskManager.SpawnTask();
            if (popUp != null)
            {
                popUp.noSoal = 1;
            }
        }
        if (dayCount == 1)
        {
            gameManager.SaveSeedSorting("Easy");
        }
        if (dayCount == 2)
        {
            gameManager.SaveSeedSorting("Medium");
        }
        if (dayCount == 7)
        {
            gameManager.SaveSeedSorting("Medium");
            gameManager.SaveSeedTyping("Easy");
        }
        if (dayCount == 17)
        {
            gameManager.SaveSeedSorting("Medium");
            gameManager.SaveSeedTyping("Medium");
        }
        if (dayCount == 18)
        {
            gameManager.SaveSeedSorting("Easy");
            gameManager.SaveSeedTyping("Medium");
        }
        if (dayCount == 19)
        {
            gameManager.SaveSeedSorting("Medium");
            gameManager.SaveSeedTyping("Medium");
        }
        if (dayCount == 21)
        {
            gameManager.SaveSeedSorting("Hard");
            gameManager.SaveSeedTyping("Easy");
            gameManager.SaveSeedVerif("Easy");
        }
        if (dayCount == 22)
        {
            gameManager.SaveSeedSorting("Hard");
            gameManager.SaveSeedTyping("Hard");
            gameManager.SaveSeedVerif("Medium");
        }
        if (dayCount == 26)
        {
            gameManager.SaveSeedSorting("Hard");
            gameManager.SaveSeedTyping("Hard");
            gameManager.SaveSeedVerif("Hard");
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
        if (dayTMP != null)
        {
            dayTMP.text = "DAY " + dayCount.ToString();
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
