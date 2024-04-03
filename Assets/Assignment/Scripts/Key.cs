using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static bool pickupKey = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pickupKey = true;
       
    }
}
