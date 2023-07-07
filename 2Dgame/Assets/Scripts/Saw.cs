using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] Transform aPoint, bPoint;

    [SerializeField] float speed;

    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = aPoint.position;
        target = bPoint;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, aPoint.position) < 0.1f)
        {
            target = bPoint;
        }
        else if (Vector2.Distance(transform.position, bPoint.position) < 0.1f)
        {
            target = aPoint;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.Rotate(0, 0, 360 * 2f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (other.gameObject.CompareTag("Player") && !player.isDeath)
        {
            player.Hit();
        }
    }

}
