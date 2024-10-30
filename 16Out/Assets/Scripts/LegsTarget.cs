using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsTarget : MonoBehaviour
{
    float distanceRay=50f;
    LayerMask mask;
    float sphereRad=0.5f;
    float distance=5f;
    
    void Start()
    {
        mask=LayerMask.GetMask("Ground");   
        Debug.Log(mask);     
    }

    void Update()
    {
        
    }

    public Vector3 getNewPos(){
        if(Physics.SphereCast(transform.position+Vector3.up*10,sphereRad,Vector3.down,out RaycastHit hit, distanceRay,mask)){
            Vector3 newPos=transform.position;
            newPos.y=hit.point.y;
            Debug.Log(newPos);
            return newPos;
        }else{
            return new Vector3(0,0,0);
        }
    }
}
