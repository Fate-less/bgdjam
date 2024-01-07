using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShop : MonoBehaviour
{
    public GameObject eyeItem;
    public GameObject handItem;
    public void itemSelected(string itemName)
    {
        if(itemName == "Eye")
        {
            eyeItem.SetActive(true);
        }
        if(itemName == "Hand")
        {
            handItem.SetActive(true);
        }
    }
    public void itemBought(string itemName)
    {
        if (itemName == "Eye")
        {
            PlayerPrefs.SetString("EyeGlitch", "false");

        }
        if (itemName == "Hand")
        {
            PlayerPrefs.SetString("CursorGlitch", "false");
        }
    }

    public void itemUnselect(string itemName)
    {
        if (itemName == "Eye")
        {
            eyeItem.SetActive(false);

        }
        if (itemName == "Hand")
        {
            handItem.SetActive(false);
        }
    }
}
