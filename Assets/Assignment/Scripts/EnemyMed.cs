using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMed : Enemy
{
    public GameObject miniEnemy;
    bool isMedDead = false;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        StartCoroutine(MedDamageAnim(1));

        health = medHealth;

        if (medHealth <= 0)
        {
            SpawnDie();
        }
    }

    public void SpawnDie()
    {   
        isMedDead = true;

        if (isMedDead)
        {
            miniEnemy.transform.localPosition = gameObject.transform.position;
            miniEnemy.SetActive(true);
        }
    }

}
