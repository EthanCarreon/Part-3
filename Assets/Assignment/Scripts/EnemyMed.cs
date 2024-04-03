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

        health = medHealth;

        StartCoroutine(MedDamageAnim(1));   

        if (medHealth <= 0)
        {
            SpawnDie();
            DestroyDie();
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
