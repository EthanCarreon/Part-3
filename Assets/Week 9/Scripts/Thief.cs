using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject knifePrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    Coroutine dashing;
    //float timer;
    //public float dashTime = 2;
    //bool isDashing;
    protected override void Attack()
    {
        if (dashing != null)
        {
            StopCoroutine(dashing);
        }
        dashing = StartCoroutine(Dash());
    }

    IEnumerator Dash()
    {
        //dash towards mouse
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        speed = 7; 

        while ( speed > 3 )
        {
            yield return null;
        }

        base.Attack();
        yield return new WaitForSeconds(0.1f);
        Instantiate(knifePrefab, spawnPoint1.position, spawnPoint1.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(knifePrefab, spawnPoint2.position, spawnPoint2.rotation);
    }

    //protected override void Update()
    //{
    //    base.Update();
    //    if (isDashing)
    //    {
    //        Dash();
    //    }
    //}
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
