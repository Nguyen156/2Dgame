using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 offset;
    [SerializeField] Transform target;
    [SerializeField] float speed;
   

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.fixedDeltaTime * speed);
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, 0, 100), transform.position.z);
    }
}
