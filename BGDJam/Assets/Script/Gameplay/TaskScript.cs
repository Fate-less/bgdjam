using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskScript : MonoBehaviour
{
    public string taskName;

    void Update()
    {
        if(taskName == "Verif")
        {
            if(PlayerPrefs.GetString("VerifState") == "Active")
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        if (taskName == "Typing")
        {
            if (PlayerPrefs.GetString("TypingState") == "Active")
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        if (taskName == "Sorting")
        {
            if (PlayerPrefs.GetString("SortingState") == "Active")
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
