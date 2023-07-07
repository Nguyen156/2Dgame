using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class End : MonoBehaviour
{
    Animator anim;
    bool isWin;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isWin)
        {
            isWin = true;
            anim.SetTrigger("pressed");
        }
    }
}
