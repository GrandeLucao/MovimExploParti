using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private Light m_light;
    private Animation m_anim;
    private AnimationClip m_clip;
    public AnimationCurve m_curve;
    [SerializeField]
    private bool startAnim=false;
    private bool playaClose;

    public float duration;
    public float initialIntensity;
    private float intensityIncreaseValue;

    float elapsedTime;
    

    void Start()
    {   
        m_light=GetComponent<Light>();
        m_anim=GetComponent<Animation>();
        m_clip=new AnimationClip();
        m_clip.legacy = true;
        m_light.intensity=initialIntensity;

        m_curve.preWrapMode=WrapMode.PingPong;
        m_curve.postWrapMode=WrapMode.PingPong;

        m_clip.SetCurve("",typeof(Light),"intensity",m_curve);
        m_anim.AddClip(m_clip,"Intensity");
        
    }


    void Update()
    {        
        if(startAnim){
            playaClose=true;
            elapsedTime=0f;
            startAnim=false;  
            intensityIncreaseValue=0.05f;          
        }
        AnimTrig();
    }

    void AnimTrig(){
        if(playaClose){
            elapsedTime+=Time.deltaTime;  
            if(elapsedTime<duration){          
                m_light.intensity+=intensityIncreaseValue;
                m_anim.Play("Intensity");
            } 
            if(elapsedTime>duration){
                if(m_light.intensity>initialIntensity){
                    m_light.intensity-=intensityIncreaseValue;
                    m_anim.Play("Intensity");
                }
            }         
        }
    }

    private void OnTriggerEnter(Collider coll){
        if(coll.gameObject.tag=="Player"){
            Debug.Log("nig");
            startAnim=true;
        }
    }
}
