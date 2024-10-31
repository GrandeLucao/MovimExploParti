using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetMove : MonoBehaviour
{
    public LegsTarget legsT;
    public GameObject myLeg;
    public int ID;
    int groupID;
    float evenDistance=0.7f,oddDistance=0.8f;

    void Start(){
        groupID=checkID(ID);
    }

    void Update()
    {
        float distance=getDistance();
        checkDistance(distance);
    }

    void checkDistance (float distance){
        if(groupID==1){
            if (distance > evenDistance){
                Vector3 newPos=legsT.getNewPos();
                transform.position=newPos;
            }
        }
        if(groupID==2){
            if (distance > oddDistance){
                Vector3 newPos=legsT.getNewPos();
                transform.position=newPos;
            }
        }
    }

    float getDistance(){
        float distance=Vector3.Distance(this.transform.position, myLeg.transform.position);
        return distance;
    }

    public int checkID(int ID){
        if(ID%2==0){
            return 1;
        }else{
            return 2;
        }
    }
}
