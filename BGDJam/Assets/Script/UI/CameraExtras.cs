using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraExtras : MonoBehaviour
{
    public VHSPostProcessEffect vhs;
    public bool isGlitching;
    public DayNightTime timeManager;
    // Start is called before the first frame update
    void Start()
    {
        vhs = GetComponent<VHSPostProcessEffect>();
        timeManager = GameObject.Find("TimeManager").GetComponent<DayNightTime>();
    }
    private void Update()
    {
        if (PlayerPrefs.GetString("EyeGlitch") == "true" && SceneManager.GetActiveScene().ToString() != "Shop")
        {
            vhs.enabled = true;
        }
        else
        {
            vhs.enabled = false;
        }
    }
}
