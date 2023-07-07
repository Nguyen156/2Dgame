using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;

    Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        startPos = transform.position;
    }

    void Falling()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        coll.isTrigger = true;
        Invoke(nameof(OnReset), 2f);
    }

    void OnReset()
    {
        rb.bodyType = RigidbodyType2D.Static;
        coll.isTrigger = false;
        transform.position = startPos;
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(Falling), 0.3f);
        }
    }

}
