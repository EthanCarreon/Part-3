using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    protected static int health;
    protected static int medHealth;
    protected static int bossHealth;
    SpriteRenderer sr;

    public static bool didPlayerDie = false;

    Vector3 targetPlayer;

    public GameObject key;
    public GameObject bossKey;

    Rigidbody2D rb;

    public float DetectionRadius = 15f;
    public float speed = 3f;

    public Transform player;

    void Start()
    {

        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        health = 15;
        medHealth = 25;
        bossHealth = 45;
    }

    void FixedUpdate()
    {

        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        if (Vector3.Distance(transform.position, player.transform.position) < DetectionRadius)
        {
            rb.rotation = angle;
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer, speed * Time.deltaTime);
        }
    }

    private void Update()
    {
        targetPlayer = player.transform.position;

        if (didPlayerDie)
        {
            Debug.Log("player died");
            didPlayerDie = false;
        }

        if (GameController.enemyDeath == 3)
        {
            GameController.allEnemiesDead = true;
            key.SetActive(true);

            if (Key.pickupKey)
            {
                key.SetActive(false);
            }
        }

        if (GameController.MedEnemyDeath == 6)
        {
            GameController.allMedEnemiesDead = true;
            bossKey.SetActive(true);

            if (PlayerController.bossPickupKey)
            {
                bossKey.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            Debug.Log("Boss Health: " + bossHealth);
            Debug.Log("Med Enemies Death Count: " + GameController.MedEnemyDeath);
        }
    }

    public virtual void TakeDamage(int damage)
    {
        damage = 1;
        health -= damage;
        

        sr.color = Color.black;
        StartCoroutine(DamageAnim(1));

        if (health <= 0 && !GameController.allEnemiesDead)
        {
            Die();
        }
        if (GameController.allEnemiesDead)
        {
            medHealth -= damage;
        }
        if (GameController.allMedEnemiesDead)
        {
            bossHealth -= damage;
        }
    }

    public virtual void Die()
    {
        gameObject.SetActive(false);

        GameController.IncreaseDeath(1);
    }

    public virtual void DestroyDie()
    {
        Destroy(gameObject);

        GameController.IncreaseMedDeath(1);
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

    public virtual IEnumerator BossDamageAnim(float time)
    {
        yield return new WaitForSeconds(time);
        sr.color = Color.green;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            TakeDamage(1);
        }
    }

}

