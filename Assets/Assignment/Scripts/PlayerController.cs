 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    public GameObject bossLock;

    public static bool bossPickupKey = false;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            GameController.lives -= 1;
            Debug.Log("lives remaining: " + GameController.lives);
            gameObject.transform.position = Vector3.zero;
            Enemy.didPlayerDie = true;
        }

        if (GameController.lives == 0)
        {
            Debug.Log("you lost");
        }

        if (collision.gameObject.CompareTag("Boss Key"))
        {
            bossPickupKey = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss Lock"))
        {
            if (bossPickupKey)
            {
                bossLock.SetActive(false);
            }
        }
    }
}
