using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (other.gameObject.CompareTag("Player") && !player.isDeath)
        {
            player.Hit();
        }
    }
}
