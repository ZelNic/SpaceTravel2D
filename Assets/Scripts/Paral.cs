using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paral : MonoBehaviour
{
    private float speed = 1.2f; 
    public void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime, Space.Self);
    }
}
