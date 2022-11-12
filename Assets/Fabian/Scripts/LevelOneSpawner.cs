using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneSpawner : MonoBehaviour
{
    public GameObject[] vehiclePrefabs;
    private static Vector3[] spawnPlaces;
    void Start()
    {
        // vehiclePrefabs = new Vector3[2];
        // vehiclePrefabs[0] = new Vector3(-95.44f, 0.6499991f, -2.04f);
        InvokeRepeating("SpawnVehicles", 0, 5);
    }
    void SpawnVehicles()
    {
        int prefabIndex = Random.Range(0, vehiclePrefabs.Length);
        //* new Quaternion(0,-180,0,1)
        Instantiate(vehiclePrefabs[prefabIndex], new Vector3(-95.44f, 0.6499991f, -2.04f), vehiclePrefabs[prefabIndex].transform.rotation );
    }
}
