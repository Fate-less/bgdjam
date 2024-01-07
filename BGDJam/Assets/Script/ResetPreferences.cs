using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPreferences : MonoBehaviour
{
    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
    }
}
