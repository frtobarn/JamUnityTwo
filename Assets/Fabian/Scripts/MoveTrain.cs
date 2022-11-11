using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrain : MonoBehaviour
{
    private float speed = 2;
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.x > 25)
        {
            Destroy(gameObject);
        }
    }
}
