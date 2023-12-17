using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            //Rigidbody2D rg = collision.GetComponent<Rigidbody2D>();
            BoxCollider2D boxCollider2D = transform.parent.gameObject.GetComponent<BoxCollider2D>();
            boxCollider2D.enabled = false;
            Destroy(transform.parent.gameObject, 3f);
            
        }
    }
}
