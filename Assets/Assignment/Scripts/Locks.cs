using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locks : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Key.pickupKey)
        {
            gameObject.SetActive(false);
        }
        
    }
}
