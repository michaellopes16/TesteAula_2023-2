using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBehaviour : MonoBehaviour
{
    [SerializeField]
    [Range(10.0f, 30.0f)]
    public float force = 15.0f;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            Rigidbody2D rg = collision.GetComponent<Rigidbody2D>();
            rg.AddForce(new Vector2(0f, force), ForceMode2D.Impulse);
            BoxCollider2D boxCollider2D = transform.parent.gameObject.GetComponent<BoxCollider2D>();
            boxCollider2D.enabled = false;
            Destroy(transform.parent.gameObject, 3f);      
        }
    }
}
