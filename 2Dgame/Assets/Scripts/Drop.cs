using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float gravity;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = gravity;
            transform.DetachChildren();
            Destroy(gameObject);
        }
    }

}
