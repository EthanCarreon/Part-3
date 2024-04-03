using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        health = bossHealth;

        StartCoroutine(BossDamageAnim(1));

        if (bossHealth <= 0)
        {
            DestroyDie();
        }
    }
}
