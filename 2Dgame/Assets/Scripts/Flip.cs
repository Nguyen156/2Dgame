using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    [SerializeField] Rino rino;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject sight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rino"))
        {
            if(rino.target != null)
            {
                UnActive();
            }
            rino.Flip();
        }
    }

    void UnActive()
    {
        sight.SetActive(false);
        Invoke(nameof(Active), 2f);
    }

    void Active()
    {
        sight.SetActive(true);
    }

    
}
