using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] int hp = 100;
    public void TakeDamage(int damageAmount)
    {
        hp -= damageAmount;
        if (hp < 0)
            hp = 0;
        if (hp == 0)
            Destroy(gameObject);
    }
}
