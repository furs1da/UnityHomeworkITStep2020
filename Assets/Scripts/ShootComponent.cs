using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    public void Shot(float direction, float bulletSpeed, GameObject bulletPrefab)
    {
        GameObject instance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D instRB = instance.GetComponent<Rigidbody2D>();
        instRB.velocity = Vector2.right * direction * bulletSpeed;

    }
}
