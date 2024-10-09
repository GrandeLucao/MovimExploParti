using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    Transform position;
    Vector3 velocity;
    Vector3 acceleration;
    [SerializeField]
    int ID;

    void Awake()
    {
        velocity.x = Random.Range(-1f, 1f);
        velocity.y = Random.Range(-1f, 1f);
        ID=Random.Range(1,4);
    }


    void FixedUpdate()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        transform.position += velocity * Time.fixedDeltaTime;
    }

    public Vector3 s_acceleration{
        get { return acceleration; }
        set { acceleration = value; }
    }

    public Vector3 s_velocity{
        get { return velocity; }
        set { velocity = value; }
    }

    public int s_ID{
        get { return ID; }
        set { ID = value; }
    }
}
