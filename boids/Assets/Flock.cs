using System.Collections;
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
            boid.assignColor();
        }
        
    }

    void FixedUpdate()
    {
        for(int i=0;i<boids.Length;i++){
            Separate(boids[i], boids);
            Align(boids[i], boids);
            Cohesion(boids[i], boids);
            if(boids[i].s_ID==4){
                Hunt(boids[i], boids);
            }else{
                Flee(boids[i], boids);
            }
        }
    }

    void Separate(Boid boid, Boid[] boids){
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
                boid.s_acceleration=Vector3.zero;
                center /= count;
                boid.s_acceleration += (boid.transform.position - center)*2f;
            }
    }

    void Align(Boid boid, Boid[] boids){
            Vector3 center = Vector3.zero;
            int count = 0;
            foreach (var other in boids)
            {
                float distance = Vector3.Distance(other.transform.position, boid.transform.position);
                if (other.s_ID == boid.s_ID && distance<2f)
                {
                    center += other.s_velocity;
                    count++;
                }
            }
            if (count == 0)
            {
                center = boid.s_velocity;
            }
            else
            {
                boid.s_acceleration=Vector3.zero;
                center /= count;
                boid.s_acceleration += (boid.s_velocity + center)*2f;
            }

    }

    void Cohesion(Boid boid, Boid[] boids){
            Vector3 center = Vector3.zero;
            int count = 0;
            foreach (var other in boids)
            {     
                float distance = Vector3.Distance(boid.transform.position, other.transform.position);           
                if (other.s_ID== boid.s_ID && distance<2f)
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
                boid.s_acceleration=Vector3.zero;
                center /= count;
                boid.s_acceleration += (center -boid.transform.position )*2f;
            }

    }

    void Hunt(Boid boid, Boid[] boids){
            Vector3 center = Vector3.zero;
            int count = 0;
            foreach (var other in boids)
            {     
                float distance = Vector3.Distance(boid.transform.position, other.transform.position);           
                if (other.s_ID!= boid.s_ID && distance<11f)
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
                boid.s_acceleration=Vector3.zero;
                center /= count;
                boid.s_acceleration += (center -boid.transform.position )*2f;
            }

    }

    void Flee(Boid boid, Boid[] boids){
        Vector3 center = Vector3.zero;
            int count = 0;
            foreach (var other in boids)
            {
                float distance = Vector3.Distance(other.transform.position, boid.transform.position);
                if (other.s_ID== 4 && distance < 3f)
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
                boid.s_acceleration=Vector3.zero;
                center /= count;
                boid.s_acceleration += (boid.transform.position - center)*2f;
            }

    }
}
