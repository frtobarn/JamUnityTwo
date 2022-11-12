using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneSpawner : MonoBehaviour
{
    public GameObject[] vehiclePrefabs;
    void Start()
    {
        InvokeRepeating("SpawnVehicles", 0, 5);
    }
    void SpawnVehicles()
    {
        int prefabIndex = Random.Range(0, vehiclePrefabs.Length);
        Debug.Log("Index is " + prefabIndex);
        Instantiate(vehiclePrefabs[prefabIndex], new Vector3(-78.44f, 0.6499991f, -2.04f), vehiclePrefabs[prefabIndex].transform.rotation);
    }
}
