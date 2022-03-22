using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float speed = 5f;

    void Update()
    {
        Vector3 a = transform.position;
        Vector3 b = target.position + offset;

        transform.position = Vector3.Lerp(a, b, speed * Time.deltaTime);
    }
}
