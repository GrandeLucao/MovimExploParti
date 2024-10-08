using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    Boid[] boids;

    private void Start()
    {
        boids = FindObjectsByType<Boid>(FindObjectsSortMode.None);
    }

    void FixedUpdate()
    {
        foreach (var boid in boids)
        {
            Vector2 center = Vector2.zero;
            int count = 0;
            foreach (var other in boids)
            {
                float distance = Vector2.Distance(other.s_position, boid.s_position);
                if (other != boid && distance < 1f)
                {
                    center += other.s_position;
                    count++;
                }
            }
            if (count == 0)
            {
                center = boid.s_position;
            }
            else
            {
                center /= count;
            }

            boid.s_acceleration = boid.s_position - center;
            boid.s_acceleration += -boid.s_position * 0.2f;
        }
    }
}
