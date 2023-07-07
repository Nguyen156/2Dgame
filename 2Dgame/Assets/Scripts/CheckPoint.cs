using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Animator anim;
    bool isActive;
   

    private void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isActive)
        {
            isActive = true;
            other.gameObject.GetComponent<Player>().SavePoint(transform.position);
            anim.SetTrigger("active");
        }
    }

}
