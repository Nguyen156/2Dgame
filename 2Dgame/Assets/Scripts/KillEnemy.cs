using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Rino rino;
    GameObject EnemyRino;

    [SerializeField] float playerBounce;

    private void Start()
    {
        EnemyRino = GameObject.FindGameObjectWithTag("Rino");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rino rino = collision.gameObject.GetComponent<Rino>();
        if (collision.gameObject.CompareTag("Rino") && !rino.isDeath && !player.isDeath)
        {
            rino.Hit();
            player.Jump(playerBounce);
            player.ChangeAnim("jump");
            Destroy(EnemyRino, 1f);
        }
    }
}
