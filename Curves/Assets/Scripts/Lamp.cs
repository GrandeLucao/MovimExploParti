using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private Light m_light;
    public AnimationCurve m_curve;
    [SerializeField]
    private bool startAnim=false;
    private bool playaClose;

    public float duration;
    public float initialIntensity;

    float elapsedTime;
    

    void Start()
    {   
        m_light=GetComponent<Light>();

        m_curve.preWrapMode=WrapMode.PingPong;
        m_curve.postWrapMode=WrapMode.PingPong;
        
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
            float flicker=m_curve.Evaluate(elapsedTime);   
            if(elapsedTime<duration){    
                m_light.intensity+=flicker;
            } 
            if(elapsedTime>duration){
                if(m_light.intensity>initialIntensity){
                    m_light.intensity-=flicker;
                }
            }         
        }
    }

    private void OnTriggerEnter(Collider coll){
        if(coll.gameObject.tag=="Player"){
            startAnim=true;
        }
    }
}
