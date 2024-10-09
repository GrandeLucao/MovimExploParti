using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    Boid[] boids;

    private void Start()
    {
        boids = FindObjectsByType<Boid>(FindObjectsSortMode.None);
        bool definedHunter=false;
        foreach(var boid in boids){
            if(boid.s_ID!=4 && !definedHunter){
                boid.s_ID=4;
                definedHunter=true;
            }else if(boid.s_ID==4){
                boid.s_ID=Random.Range(1,3);
            }
        }
    }

    void FixedUpdate()
    {
        for(int i=0;i<boids.Length;i++){
            Separate();
            //Align();
            //Cohesion();
            if(boids[i].s_ID==4){
                Hunt();
            }else{
                Flee();
            }
        }
    }

    void Separate(){
        foreach (var boid in boids)
        {
            Vector3 center = Vector3.zero;
            int count = 0;
            foreach (var other in boids)
            {
                float distance = Vector3.Distance(other.transform.position, boid.transform.position);
                if (other != boid && distance < 1f)
                {
                    center += other.transform.position;
                    count++;
                }
            }
            if (count == 0)
            {
                center = boid.transform.position;
            }
            else
            {
                center /= count;
            }

            boid.s_acceleration = boid.transform.position - center;
            boid.s_acceleration += -boid.transform.position * 0.2f;
        }
    }

    void Align(){
        foreach (var boid in boids)
        {
            Vector3 center = Vector3.zero;
            int count = 0;
            foreach (var other in boids)
            {
                float distance = Vector3.Distance(other.transform.position, boid.transform.position);
                if (other.s_ID == boid.s_ID )
                {
                    center += other.transform.position;
                    boid.s_velocity=other.s_velocity;
                    count++;
                }
            }
            if (count == 0)
            {
                center = boid.transform.position;
            }
            else
            {
                center /= count;
            }

            boid.s_acceleration = boid.transform.position - center;
            boid.s_acceleration += -boid.transform.position * 0.2f;
        }
    }

    void Cohesion(){
        foreach (var boid in boids)
        {
            Vector3 center = Vector3.zero;
            int count = 0;
            foreach (var other in boids)
            {                
                if (other.s_ID== boid.s_ID)
                {
                    center += other.transform.position;
                    count++;
                }
            }
            if (count == 0)
            {
                center = boid.transform.position;
            }
            else
            {
                center /= count;
            }

            boid.s_acceleration = boid.transform.position - center;
            boid.s_acceleration += boid.transform.position * 0.2f;
        }
    }

    void Hunt(){

    }

    void Flee(){

    }
}
