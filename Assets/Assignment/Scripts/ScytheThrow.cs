using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ScytheThrow : MonoBehaviour
{
    public GameObject scythe;
    public Transform player;

    Rigidbody2D rb;

    Vector3 target;
    float speed = 5f;

    bool scytheActivated = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = scythe.transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 direction = scythe.transform.position - transform.position;

        if (direction.x > 0)
        {
            scythe.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (direction.x < 0)
        {
            scythe.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!scythe.activeSelf)
            {
                scytheActivated = true;
                scythe.SetActive(true);

                StartCoroutine(DeactivateScythe(1));
            }
        }
        
        if (scytheActivated)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = scythe.transform.position.z;

            scythe.transform.position = Vector3.MoveTowards(scythe.transform.position, target, speed * Time.deltaTime);
        }

    }
    
    IEnumerator DeactivateScythe(float time)
    {
        yield return new WaitForSeconds(time);

        scythe.SetActive(false);
        scytheActivated = false;

        scythe.transform.position = player.position;
    }

}
