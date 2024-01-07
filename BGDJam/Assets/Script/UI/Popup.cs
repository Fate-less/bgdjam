using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public int noSoal = 1;

    public GameObject folderA;
    public GameObject folderB;
    public GameObject folderC;
    public GameObject segitiga;
    public GameObject kotak;
    public GameObject bulat;
    public GameObject silang;
    public GameObject atas;
    public GameObject bawah;

    public Transform spawnPos0;
    public Transform spawnPos1;
    public Transform spawnPos2;
    public Transform spawnPos3;
    public Transform spawnPos4;
    public Transform spawnPos5;
    public Transform spawnPos6;
    public Transform spawnPos7;

    public DiffSeed seedManager;
    public string seed;

    private void Start()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        seedManager = GameObject.Find("GameManager").GetComponent<DiffSeed>();
        if (PlayerPrefs.GetString("VerifState", "Cleared") == "Active")
        {
            PopIn();
        }
    }
    private void Update()
    {
        if (noSoal > 3)
        {
            PlayerPrefs.SetString("VerifState", "Cleared");
        }
    }
    public void PopIn()
    {
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.5f).setEase(LeanTweenType.easeOutBack);
        seed = seedManager.LoadSeedVerif();
        if (seed == "Easy" && noSoal == 1)
        {
            Instantiate(folderC, spawnPos0.position, Quaternion.identity);
            Instantiate(segitiga, spawnPos1.position, Quaternion.identity);
            Instantiate(kotak, spawnPos2.position, Quaternion.identity);
            Instantiate(bulat, spawnPos3.position, Quaternion.identity);
        }
        else if (seed == "Easy" && noSoal == 2)
        {
            //ini yg bener
            Instantiate(folderA, spawnPos0.position, Quaternion.identity);
            Instantiate(segitiga, spawnPos1.position, Quaternion.identity);
            Instantiate(kotak, spawnPos2.position, Quaternion.identity);
            Instantiate(bulat, spawnPos3.position, Quaternion.identity);
        }
        else if (seed == "Easy" && noSoal == 3)
        {
            Instantiate(folderB, spawnPos0.position, Quaternion.identity);
            Instantiate(segitiga, spawnPos1.position, Quaternion.identity);
            Instantiate(kotak, spawnPos2.position, Quaternion.identity);
            Instantiate(bulat, spawnPos3.position, Quaternion.identity);
        }
        if (seed == "Medium" && noSoal == 1)
        {
            Instantiate(folderA, spawnPos0.position, Quaternion.identity);
            Instantiate(segitiga, spawnPos1.position, Quaternion.identity);
            Instantiate(kotak, spawnPos2.position, Quaternion.identity);
            Instantiate(bulat, spawnPos3.position, Quaternion.identity);
            Instantiate(silang, spawnPos4.position, Quaternion.identity);
            Instantiate(segitiga, spawnPos5.position, Quaternion.identity);
        }
        else if (seed == "Medium" && noSoal == 2)
        {
            Instantiate(folderB, spawnPos0.position, Quaternion.identity);
            Instantiate(segitiga, spawnPos1.position, Quaternion.identity);
            Instantiate(kotak, spawnPos2.position, Quaternion.identity);
            Instantiate(bulat, spawnPos3.position, Quaternion.identity);
            Instantiate(silang, spawnPos4.position, Quaternion.identity);
            Instantiate(segitiga, spawnPos5.position, Quaternion.identity);
        }
        else if (seed == "Medium" && noSoal == 3)
        {
            //ini yg bener
            Instantiate(folderC, spawnPos0.position, Quaternion.identity);
            Instantiate(segitiga, spawnPos1.position, Quaternion.identity);
            Instantiate(kotak, spawnPos2.position, Quaternion.identity);
            Instantiate(bulat, spawnPos3.position, Quaternion.identity);
            Instantiate(silang, spawnPos4.position, Quaternion.identity);
            Instantiate(segitiga, spawnPos5.position, Quaternion.identity);
        }
        if (seed == "Hard" && noSoal == 1)
        {
            //ini yg bener
            Instantiate(folderA, spawnPos0.position, Quaternion.identity);
            Instantiate(segitiga, spawnPos1.position, Quaternion.identity);
            Instantiate(kotak, spawnPos2.position, Quaternion.identity);
            Instantiate(bulat, spawnPos3.position, Quaternion.identity);
            Instantiate(silang, spawnPos4.position, Quaternion.identity);
            Instantiate(segitiga, spawnPos5.position, Quaternion.identity);
            Instantiate(atas, spawnPos6.position, Quaternion.identity);
            Instantiate(bawah, spawnPos7.position, Quaternion.identity);
        }
        else if (seed == "Hard" && noSoal == 2)
        {
            Instantiate(folderC, spawnPos0.position, Quaternion.identity);
            Instantiate(segitiga, spawnPos1.position, Quaternion.identity);
            Instantiate(kotak, spawnPos2.position, Quaternion.identity);
            Instantiate(bulat, spawnPos3.position, Quaternion.identity);
            Instantiate(silang, spawnPos4.position, Quaternion.identity);
            Instantiate(segitiga, spawnPos5.position, Quaternion.identity);
            Instantiate(atas, spawnPos6.position, Quaternion.identity);
            Instantiate(bawah, spawnPos7.position, Quaternion.identity);
        }
        else if (seed == "Hard" && noSoal == 3)
        {
            Instantiate(folderB, spawnPos0.position, Quaternion.identity);
            Instantiate(segitiga, spawnPos1.position, Quaternion.identity);
            Instantiate(kotak, spawnPos2.position, Quaternion.identity);
            Instantiate(bulat, spawnPos3.position, Quaternion.identity);
            Instantiate(silang, spawnPos4.position, Quaternion.identity);
            Instantiate(segitiga, spawnPos5.position, Quaternion.identity);
            Instantiate(atas, spawnPos6.position, Quaternion.identity);
            Instantiate(bawah, spawnPos7.position, Quaternion.identity);
        }
    }
    public void PopOut()
    {
        LeanTween.scale(gameObject, new Vector3(0f, 0f, 1f), 0.5f).setEase(LeanTweenType.easeInBack);
        GameObject[] gos = GameObject.FindGameObjectsWithTag("TSV");
        foreach (GameObject go in gos) Destroy(go);
    }
    public void PressYes()
    {
        if(seed == "Easy" && noSoal == 2 || seed == "Medium" && noSoal == 3 || seed == "Hard" && noSoal == 1)
        {
            PopOut();
            noSoal++;
            if (noSoal < 4)
            {
                PopIn();
            }
        }
        else
        {
            //hasilnya salah
            PopOut();
            noSoal++;
            if (noSoal < 4)
            {
                PopIn();
            }
        }
    }
    public void PressNo()
    {
        if (seed == "Easy" && noSoal == 2 || seed == "Medium" && noSoal == 3 || seed == "Hard" && noSoal == 1)
        {
            PopOut();
            noSoal++;
            //hasilnya salah
            if (noSoal < 4)
            {
                PopIn();
            }
        }
        else
        {
            PopOut();
            noSoal++;
            //hasilnya bener
            if (noSoal < 4)
            {
                PopIn();
            }
        }
    }
}
