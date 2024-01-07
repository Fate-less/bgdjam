using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;
    public DayNightTime timeManager;

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
        timeManager = GameObject.Find("TimeManager").GetComponent<DayNightTime>();
        SpawnTask();
    }

    private void Update()
    {
        if(PlayerPrefs.GetString("SortingState", "Cleared") == "Cleared" && PlayerPrefs.GetString("TypingState", "Cleared") == "Cleared" && PlayerPrefs.GetString("VerifState", "Cleared") == "Cleared")
        {
            timeManager.currentTime = 19;
        }
    }

    public void SpawnTask()
    {
        if(timeManager.dayCount <= 3)
        {
            SortingActive();
        }
        else if (timeManager.dayCount <= 21)
        {
            SortingActive();
            TypingActive();
        }
        else
        {
            SortingActive();
            TypingActive();
            VerifActive();
        }
    }

    public void SortingActive()
    {
        PlayerPrefs.SetString("SortingState", "Active");
    }
    public void TypingActive()
    {
        PlayerPrefs.SetString("TypingState", "Active");
    }
    public void VerifActive()
    {
        PlayerPrefs.SetString("VerifState", "Active");
    }
}
