using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffSeed : MonoBehaviour
{
    //Seed dibagi 3
    //Easy
    //Normal
    //Hard
    public static DiffSeed instance;

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

    public string LoadSeedTyping()
    {
        string seed = PlayerPrefs.GetString("TypingSeed", "Easy");
        return seed;
    }

    public string LoadSeedSorting()
    {
        string seed = PlayerPrefs.GetString("SortingSeed", "Easy");
        return seed;
    }

    public string LoadSeedVerif()
    {
        string seed = PlayerPrefs.GetString("VerifSeed", "Easy");
        return seed;
    }

    public void SaveSeedTyping(string seed)
    {
        PlayerPrefs.SetString("TypingSeed", seed);
    }
    public void SaveSeedSorting(string seed)
    {
        PlayerPrefs.SetString("SortingSeed", seed);
    }
    public void SaveSeedVerif(string seed)
    {
        PlayerPrefs.SetString("VerifSeed", seed);
    }

}
