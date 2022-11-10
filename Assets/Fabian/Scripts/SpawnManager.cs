using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject trainPrefab;
    void Start()
    {
        InvokeRepeating("SpawnTrain", 0, 17);
    }
    void SpawnTrain()
    {
        Instantiate(trainPrefab, new Vector3(-19.08f,0.587f,-0.416f), trainPrefab.transform.rotation);
    }
}
