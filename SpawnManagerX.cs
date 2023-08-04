using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    // gameobject array for prefabs
    public GameObject[] objectPrefabs;
    // start after spawnDelay
    private float spawnDelay = 2;
    // interval
    private float spawnInterval = 1.5f;

    // for use PlayerController class'es variables and methods
    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);

        // to give Player object's PlayerController component to playerControllerScript
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Spawn obstacles
    void SpawnObjects ()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
        // random index for objectprefabs array
        int index = Random.Range(0, objectPrefabs.Length);

        // if game is still active, spawn new object
        if (!playerControllerScript.gameOver)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }

    }
}
