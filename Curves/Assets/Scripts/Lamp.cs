using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public AnimationCurve curve;
    [SerializeField]
    private bool startAnim=false;
    private bool playaClose;

    public float duration;

    float elapsedTime;
    Vector3 initalScale;

    void Start()
    {
        initalScale=transform.localScale;
        curve.preWrapMode=WrapMode.PingPong;
        curve.postWrapMode=WrapMode.PingPong;
        
    }


    void Update()
    {
        if(startAnim){
            playaClose=true;
            elapsedTime=0f;
            startAnim=false;            
        }
        AnimTrig();
    }

    void AnimTrig(){
        if(playaClose){
            elapsedTime+=Time.deltaTime;
            float scalingValue=curve.Evaluate(elapsedTime);
            transform.localScale=new Vector3(initalScale.x+scalingValue,initalScale.y+scalingValue,initalScale.z+scalingValue);
            if(elapsedTime>duration){
                playaClose=false;
            }
        }
    }
}
