using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviiour : MonoBehaviour
{
    private bool isCollider = false;
    public Transform coinTarget;
    public float velCoin = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        coinTarget = GameObject.FindGameObjectWithTag("TargetCoin").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollider)
        {
            transform.position = Vector3.Lerp(transform.position, coinTarget.position, Time.deltaTime * velCoin);
            if (Vector3.Distance(transform.position, coinTarget.position) < 0.1f)
            {
                Destroy(gameObject);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().SetCountCoin();
            isCollider = true;
        }
    }
}
