using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    protected int health;
    protected int MaxHealth = 5;
    protected int medHealth = 10;
    SpriteRenderer sr;

    Vector3 targetPlayer;

    Rigidbody2D rb;

    public float DetectionRadius = 5f;
    public float speed = 3f;

    public Transform player;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        health = MaxHealth;
    }

    void FixedUpdate()
    {

        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        if (Vector3.Distance(transform.position, player.transform.position) <= DetectionRadius)
        {
            rb.rotation = angle;
            //rb.MovePosition(rb.position + (Vector2)targetPlayer * speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer, speed * Time.deltaTime);
        }
    }

    private void Update()
    {
        targetPlayer = player.transform.position;
    }

    public virtual void TakeDamage(int damage)
    {
        damage = 1;
        health -= damage;
        medHealth -= damage;

        sr.color = Color.black;
        StartCoroutine(DamageAnim(1));

        if (health <= 0 )
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator DamageAnim(float time)
    {
        yield return new WaitForSeconds(time);
        sr.color = Color.red;
    }
    public virtual IEnumerator MedDamageAnim(float time)
    {
        yield return new WaitForSeconds(time);
        sr.color = Color.blue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            TakeDamage(health);
        }
    }
}

