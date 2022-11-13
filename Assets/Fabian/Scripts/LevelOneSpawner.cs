using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneSpawner : MonoBehaviour
{
    public GameObject[] vehiclePrefabs;
    public GameObject[] DogPrefabs;
    void Start()
    {
        InvokeRepeating("SpawnVehicles", 1, 3);
        InvokeRepeating("SpawnDogs", 0, 6);
    }
    void SpawnVehicles()
    {
        int prefabIndex = Random.Range(0, vehiclePrefabs.Length);
        int randomOption = Random.Range(0, 2);
        switch (randomOption)
        {
        case 0:
            //Instantiate(vehiclePrefabs[prefabIndex], new Vector3(-95.44f, 0.6499991f, -2.04f), vehiclePrefabs[prefabIndex].transform.rotation );
            break;
        case 1:
            Instantiate(vehiclePrefabs[prefabIndex], new Vector3(80.68181f, 0.6499991f, 1.951199f), vehiclePrefabs[prefabIndex].transform.rotation * new Quaternion(0,-180,0,1));
            break;
        default:
            break;
        }        
    }
    
    void SpawnDogs()
    {
        int prefabIndex = Random.Range(0, DogPrefabs.Length);
        //int randomOption = Random.Range(0, 2);
        Instantiate(DogPrefabs[prefabIndex], new Vector3(80.68181f, 0.5999995f, -5.315387f), DogPrefabs[prefabIndex].transform.rotation );
        // switch (randomOption)
        // {
        // case 0:
        //     Instantiate(vehiclePrefabs[prefabIndex], new Vector3(-95.44f, 0.6499991f, -2.04f), vehiclePrefabs[prefabIndex].transform.rotation );
        //     break;
        // case 1:
        //     Instantiate(vehiclePrefabs[prefabIndex], new Vector3(80.68181f, 0.6499991f, 1.951199f), vehiclePrefabs[prefabIndex].transform.rotation * new Quaternion(0,-180,0,1));
        //     break;
        // default:
        //     break;
        // }        
    }
}
