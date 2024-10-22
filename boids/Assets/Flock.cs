using System.Collections;
using UnityEngine;

public class Flock : MonoBehaviour
{
    Boid[] boids;
    public float SepSpeed,AliSpeed,CohSpeed,HuntSpeed,FleeSpeed;
    private float minX,minY,maxX,maxY;

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
        setBounds(-10,10,-10,10);
        
    }

    void FixedUpdate()
    {
        for(int i=0;i<boids.Length;i++){
            Separate(boids[i], boids,SepSpeed);
            Align(boids[i], boids,AliSpeed);
            Cohesion(boids[i], boids,CohSpeed);
            if(boids[i].s_ID==4){
                Hunt(boids[i], boids,HuntSpeed);
            }else{
                Flee(boids[i], boids,FleeSpeed);
            }
            checkBounds(boids[i]);
        }
    }

    void Separate(Boid boid, Boid[] boids,float speed){
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
                boid.s_acceleration += (boid.transform.position - center)*speed;
            }
    }

    void Align(Boid boid, Boid[] boids,float speed){
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
                boid.s_acceleration += (boid.s_velocity + center)*speed;
            }

    }

    void Cohesion(Boid boid, Boid[] boids,float speed){
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
                boid.s_acceleration += (center -boid.transform.position )*speed;
            }

    }

    void Hunt(Boid boid, Boid[] boids,float speed){
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
                boid.s_acceleration += (center -boid.transform.position )*speed;
            }

    }

    void Flee(Boid boid, Boid[] boids,float speed){
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
                boid.s_acceleration += (boid.transform.position - center)*speed;
            }

    }

    void setBounds(float minX,float maxX,float minY,float maxY){
        this.minX=minX;
        this.maxX=maxX;
        this.minY=minY;
        this.maxY=maxY;
    }

    void checkBounds(Boid boids){
        float boundsWidth=maxX-minX;
        float boundsHeight=maxY-minY;
        if(boids.transform.position.x>maxX){
            boids.transform.position-=new Vector3(boundsWidth,boids.transform.position.y,0);
        }
        if(boids.transform.position.x<minX){
            boids.transform.position+=new Vector3(boundsWidth,boids.transform.position.y,0);
        }
        if(boids.transform.position.y>maxY){
            boids.transform.position-=new Vector3(boids.transform.position.x,boundsHeight,0);

        }
        if(boids.transform.position.y<minY){
            boids.transform.position+=new Vector3(boids.transform.position.x,boundsHeight,0);
        }
    }
}
