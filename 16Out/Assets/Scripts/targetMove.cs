using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetMove : MonoBehaviour
{
    public LegsTarget legsT;
    public GameObject myLeg;


    void Update()
    {
        float distance=getDistance();
        checkDistance(distance);
    }

    void checkDistance (float distance){
        if (distance > 1f){
            Vector3 newPos=legsT.getNewPos();
            transform.position+=newPos*Time.deltaTime;
        }
    }

    float getDistance(){
        float distance=Vector3.Distance(this.transform.position, myLeg.transform.position);
        return distance;
    }
}
