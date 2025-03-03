using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject plant;
    float speed = 0.4f;

    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}
