using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curves : MonoBehaviour
{
    public AnimationCurve curve;
    public bool startAnim=false;
    public bool isMoving=false;
    public float duration=2f;

    Vector3 startPos;
    float elapsedTIme;
    
    void Start()
    {
        startPos=transform.position;
        curve.preWrapMode=WrapMode.PingPong;
        curve.postWrapMode=WrapMode.PingPong;
    }


    void Update()
    {
        if(startAnim){
            startAnim=false;
            isMoving=true;
            elapsedTIme=0f;
        }

        if(isMoving){
            elapsedTIme+=Time.deltaTime;
            float normalizedTime=elapsedTIme/duration;
            float zvalue=curve.Evaluate(normalizedTime);
            transform.position=new Vector3(startPos.x,startPos.y,startPos.z+zvalue);

            if(normalizedTime>=1){
                isMoving=false;
            }
        }

    }
}
