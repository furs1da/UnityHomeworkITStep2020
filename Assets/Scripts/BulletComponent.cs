using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    [SerializeField] int damage = 40;
    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthComponent target = collision.gameObject.GetComponent<HealthComponent>();
        if (target != null)
            target.TakeDamage(damage);
        Destroy(gameObject);
    }

    //float t = 5f;
    // Update is called once per frame
    //void Update()
    //{
    //    t -= Time.deltaTime;
    //    if (t <= 0f)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}
