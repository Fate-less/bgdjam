using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileC : MonoBehaviour
{
    public GameObject segitiga;
    public GameObject kotak;
    public GameObject bulat;
    public GameObject silang;
    public GameObject atas;
    public GameObject bawah;

    public Transform spawnPos1;
    public Transform spawnPos2;
    public Transform spawnPos3;
    public Transform spawnPos4;
    public Transform spawnPos5;
    public Transform spawnPos6;
    public Transform spawnPos7;

    public DiffSeed seedManager;
    public string seed;


    // Start is called before the first frame update
    void Start()
    {
        seedManager = GameObject.Find("GameManager").GetComponent<DiffSeed>();
        seed = seedManager.LoadSeedVerif();
        if (seed == "Easy")
        {
            Instantiate(segitiga, spawnPos3.position, Quaternion.identity).transform.SetParent(transform);
            Instantiate(kotak, spawnPos4.position, Quaternion.identity).transform.SetParent(transform);
            Instantiate(bulat, spawnPos5.position, Quaternion.identity).transform.SetParent(transform);
        }
        if (seed == "Medium")
        {
            Instantiate(segitiga, spawnPos2.position, Quaternion.identity).transform.SetParent(transform);
            Instantiate(kotak, spawnPos3.position, Quaternion.identity).transform.SetParent(transform);
            Instantiate(bulat, spawnPos4.position, Quaternion.identity).transform.SetParent(transform);
            Instantiate(silang, spawnPos5.position, Quaternion.identity).transform.SetParent(transform);
            Instantiate(segitiga, spawnPos6.position, Quaternion.identity).transform.SetParent(transform);
        }
        if (seed == "Hard")
        {
            Instantiate(segitiga, spawnPos1.position, Quaternion.identity).transform.SetParent(transform);
            Instantiate(kotak, spawnPos2.position, Quaternion.identity).transform.SetParent(transform);
            Instantiate(bulat, spawnPos3.position, Quaternion.identity).transform.SetParent(transform);
            Instantiate(silang, spawnPos4.position, Quaternion.identity).transform.SetParent(transform);
            Instantiate(segitiga, spawnPos5.position, Quaternion.identity).transform.SetParent(transform);
            Instantiate(atas, spawnPos6.position, Quaternion.identity).transform.SetParent(transform);
            Instantiate(bawah, spawnPos7.position, Quaternion.identity).transform.SetParent(transform);
        }
    }
}
