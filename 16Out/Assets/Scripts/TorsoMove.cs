using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoMove : MonoBehaviour
{
    [SerializeField]
    float speed;
    Vector3 velocity;
    Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        velocity=new Vector3(speed,0,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position+=velocity*Time.deltaTime;
    }
}
