using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopCountdown : MonoBehaviour
{
    public float count;
    public TextMeshProUGUI countTMP;

    // Update is called once per frame
    void Update()
    {
        CountDown();
    }

    public void CountDown()
    {
        count -= Time.deltaTime;
        countTMP.text = "Countdown: " + count.ToString("0");
        if (count <= 0)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
