using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Light m_light;
    public AnimationCurve m_curve;
    [SerializeField]
    private bool startAnim=false;

    public float duration;
    public float initialIntensity;

    float elapsedTime;
    

    void Start()
    {   
        m_light=GetComponent<Light>();

        m_curve.preWrapMode=WrapMode.PingPong;
        m_curve.postWrapMode=WrapMode.PingPong;
        m_light.intensity=initialIntensity;
        
    }


    void Update()
    {        
        if(startAnim){
            elapsedTime=0f;
            startAnim=false;    
            m_light.intensity=initialIntensity;      
        }
        AnimTrig();
    }

    void AnimTrig(){
            elapsedTime+=Time.deltaTime;  
            float flicker=m_curve.Evaluate(elapsedTime); 
            if(elapsedTime<duration){          
                m_light.intensity+=flicker;
            } 
            if(elapsedTime>duration){
                if(m_light.intensity>initialIntensity){
                    m_light.intensity-=flicker;
                }
                if(m_light.intensity<=initialIntensity){
                    startAnim=true;
                }
            }       
    }
}
