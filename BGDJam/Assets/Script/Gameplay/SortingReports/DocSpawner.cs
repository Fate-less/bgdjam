using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array of prefab objects
    public int numberOfObjectsToSpawn = 30; // Number of objects to spawn
    public Vector3 spawnRange = new Vector3(10f, 0f, 10f); // The range in which objects will be spawned
    public SceneHandler sceneHandler;

    void Start()
    {
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
            transform.position.z + Random.Range(-spawnRange.z, spawnRange.z)
        );

        // Instantiate the chosen object at the random position
        GameObject spawnedObject = Instantiate(randomObject, randomPosition, Quaternion.identity);
        spawnedObject.transform.SetParent(transform);
    }

}
