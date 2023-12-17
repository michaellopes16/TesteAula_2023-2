using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private const float speed = 5f;
    private int index = 0;

    // Start is called before the first frame update
    private Rigidbody2D rb;
    private SpriteRenderer sp;

    [SerializeField]
    private Transform[] waypoints;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage();
        }
    }

    private void FixedUpdate()
    {
        if (gameObject.GetComponent<BoxCollider2D>().enabled)
        {
            Patrol();
        }
    }

    public void Patrol()
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, waypoints[index].position, speed * Time.deltaTime));

        if (Vector2.Distance(transform.position, waypoints[index].position) <= 1f)
        {

            sp.flipX = !sp.flipX;
            if (index < waypoints.Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
    }
}
