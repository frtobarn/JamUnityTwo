using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVehicle : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.x > 70)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -80)
        {
            Destroy(gameObject);
        }

    }
}
