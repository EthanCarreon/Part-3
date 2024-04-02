 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    public float speed = 5f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 horizontalMovement = new Vector2(horizontal, 0);
        Vector2 verticalMovement = new Vector2(0, vertical);

        transform.Translate(horizontalMovement * speed * Time.deltaTime);
        transform.Translate(verticalMovement * speed * Time.deltaTime);
    }
}
