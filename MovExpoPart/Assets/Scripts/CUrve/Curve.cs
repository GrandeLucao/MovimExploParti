using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour
{
    public AnimationCurve curve;
    Vector2 startPos;
    [Range(0,1)]
    public float debugFloat=0;
    
    void Start()
    {
        startPos=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float zvalue=curve.Evaluate(debugFloat);
        transform.position=new Vector2(startPos.x,startPos.y+zvalue);
        
    }
}
