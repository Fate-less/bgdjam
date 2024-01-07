using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlitchCursor : MonoBehaviour
{
    public static GlitchCursor instance;
    // Intensity of the glitch effect
    public float glitchIntensity = 10f;

    // Frequency of the glitch effect
    public float glitchFrequency = 0.1f;

    // Time counter for glitch effect
    private float timeCounter = 0f;

    // Original cursor texture
    public Texture2D originalCursorTexture;

    public bool isGlitching = false;
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

    void Start()
    {
        // Store the original cursor texture
        Vector2 hotSpot = new Vector2(originalCursorTexture.width / 2f, originalCursorTexture.height / 2f);
        Cursor.SetCursor(originalCursorTexture, hotSpot, CursorMode.Auto);
        timeManager = GameObject.Find("TimeManager").GetComponent<DayNightTime>();
        if (timeManager.dayCount > 16)
        {
            isGlitching = true;
        }
    }

    void Update()
    {
        if (PlayerPrefs.GetString("CursorGlitch") == "true" && SceneManager.GetActiveScene().ToString() != "Shop" )
        {
            // Update the time counter
            timeCounter += Time.deltaTime;

            // Check if it's time to apply a glitch
            if (timeCounter > glitchFrequency)
            {
                // Apply the glitch effect
                ApplyGlitch();

                // Reset the time counter
                timeCounter = 0f;
            }
        }
        else
        {
            Vector2 hotSpot = new Vector2(originalCursorTexture.width / 2f, originalCursorTexture.height / 2f);
            Cursor.SetCursor(originalCursorTexture, hotSpot, CursorMode.Auto);
        }
    }

    void ApplyGlitch()
    {
        // Simulate glitch by randomly changing cursor position
        float offsetX = Random.Range(-glitchIntensity, glitchIntensity);
        float offsetY = Random.Range(-glitchIntensity, glitchIntensity);

        // Apply the glitched cursor position
        Cursor.SetCursor(originalCursorTexture, new Vector2(offsetX, offsetY), CursorMode.Auto);
    }
}
