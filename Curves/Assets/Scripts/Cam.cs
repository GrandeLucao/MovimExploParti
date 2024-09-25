using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Transform target;
    public AnimationCurve pitchCurve;
    public AnimationCurve distanceCurve;

    void Start(){
        target=GameObject.FindGameObjectWithTag("Player").transform;
        pitchCurve=AnimationCurve.EaseInOut(0.0f,0.0f,1.0f,90.0f);

        Keyframe[] ks=new Keyframe[2];
        ks[0]=new Keyframe(0,0.5f);
        ks[0].outTangent=0;
        ks[1]=new Keyframe(1,60);
        ks[1].inTangent=90;
        distanceCurve=new AnimationCurve(ks);
    }

    void Update(){
        float distance=Vector3.Distance(transform.position,target.position);
        float targetRotX = pitchCurve.Evaluate(distance);
        float targetRotY = target.rotation.eulerAngles.y;
        Quaternion targetRot = Quaternion.Euler(targetRotX, targetRotY, 0.0f);
        Vector3 offset = Vector3.forward * distanceCurve.Evaluate(distance);
        Vector3 targetPos = target.position - targetRot * offset;
        transform.position=Vector3.Lerp(transform.position,targetPos,distance);
        transform.rotation=Quaternion.Slerp(transform.rotation,targetRot,distance);
    }

}
