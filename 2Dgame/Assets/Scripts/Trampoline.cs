using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    Animator anim;
    [SerializeField] float force;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (other.gameObject.CompareTag("Player") && !player.isDeath)
        {
            player.ChangeAnim("jump");
            player.Jump(force);
            anim.SetTrigger("jump");
        }
    }

}
