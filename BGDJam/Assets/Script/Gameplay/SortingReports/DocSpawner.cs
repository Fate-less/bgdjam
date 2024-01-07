using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array of prefab objects
    private int numberOfObjectsToSpawn; // Number of objects to spawn
    public Vector3 spawnRange = new Vector3(10f, 0f, 10f); // The range in which objects will be spawned
    public Vector3 rotateRange = new Vector3(10f, 0f, 10f);
    public SceneHandler sceneHandler;

    void Start()
    {
        if(PlayerPrefs.GetString("SortingSeed", "Easy") == "Easy")
        {
            numberOfObjectsToSpawn = 3;
        }
        else if(PlayerPrefs.GetString("SortingSeed", "Easy") == "Medium")
        {
            numberOfObjectsToSpawn = 5;
        }
        else if(PlayerPrefs.GetString("SortingSeed", "Easy") == "Hard")
        {
            numberOfObjectsToSpawn = 9;
        }
        // Spawn objects
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            SpawnRandomObject();
        }
    }
    private void Update()
    {
        if (transform.childCount <= 0)
        {
            sceneHandler.OpenScene("Game");
            PlayerPrefs.SetString("SortingState", "Cleared");
        }
    }

    public void SpawnRandomObject()
    {
        if (objectsToSpawn.Length == 0)
        {
            Debug.LogWarning("No prefab objects assigned.");
            return;
        }

        // Randomly choose an object from the array
        GameObject randomObject = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

        // Generate a random position within the specified range
        Vector3 randomPosition = new Vector3(
            transform.position.x + Random.Range(-spawnRange.x, spawnRange.x),
            transform.position.y + Random.Range(-spawnRange.y, spawnRange.y),
            transform.position.z + Random.Range(1, spawnRange.z));

        Vector3 randomRotation = new Vector3(
            transform.position.x + Random.Range(-rotateRange.x, rotateRange.x),
            transform.position.y + Random.Range(-rotateRange.y, rotateRange.y),
            transform.position.z + Random.Range(-rotateRange.z / 2, rotateRange.z));

        // Instantiate the chosen object at the random position
        GameObject spawnedObject = Instantiate(randomObject, randomPosition, Quaternion.Euler(randomRotation));
        spawnedObject.transform.SetParent(transform);
    }

}
