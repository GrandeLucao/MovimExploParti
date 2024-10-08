using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    Vector2 position;
    Vector2 velocity;
    Vector2 acceleration;

    void Awake()
    {
        velocity.x = Random.Range(-1f, 1f);
        velocity.y = Random.Range(-1f, 1f);
    }


    void FixedUpdate()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;
    }

    public Vector2 s_acceleration{
        get { return acceleration; }
        set { acceleration = value; }
    }

    public Vector2 s_velocity{
        get { return velocity; }
        set { velocity = value; }
    }

    public Vector2 s_position{
        get { return position; }
        set { position = value; }
    }
}
