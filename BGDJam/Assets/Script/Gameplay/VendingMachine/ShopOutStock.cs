using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOutStock : MonoBehaviour
{
    public GameObject itemEye;
    public GameObject itemHand;
    public GameObject textEye;
    public GameObject textHand;
    public DayNightTime timeManager;

    private void Start()
    {
        timeManager = GameObject.Find("TimeManager").GetComponent<DayNightTime>();
        if (timeManager.dayCount > 16)
        {
            itemEye.GetComponent<Image>().color = Color.black;
            itemEye.GetComponent<Button>().interactable = false;
            textEye.SetActive(true);
        }
        if (timeManager.dayCount > 24)
        {
            itemEye.GetComponent<Image>().color = Color.black;
            itemEye.GetComponent<Button>().interactable = false;
            textEye.SetActive(true);
            itemHand.GetComponent<Image>().color = Color.black;
            itemHand.GetComponent<Button>().interactable = false;
            textHand.SetActive(true);
        }
    }

    public void eyeOOS()
    {
        itemEye.GetComponent<Image>().color = Color.black;
        itemEye.GetComponent<Button>().interactable = false;
        textEye.SetActive(true);
    }
    public void handOOS()
    {
        itemHand.GetComponent<Image>().color = Color.black;
        itemHand.GetComponent<Button>().interactable = false;
        textHand.SetActive(true);
    }
}