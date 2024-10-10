using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    Transform position;
    [SerializeField]
    Vector3 velocity;
    [SerializeField]
    Vector3 acceleration;
    int ID;
    SpriteRenderer sr;

    void Awake()
    {
        velocity.x = Random.Range(-1f, 1f);
        velocity.y = Random.Range(-1f, 1f);
        ID=Random.Range(1,4);
        sr=GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        velocity=Vector3.ClampMagnitude(velocity,4);
        transform.position += velocity * Time.fixedDeltaTime;
    }

    public void assignColor(){
        switch(ID){
            case 1:
                sr.color=Color.blue;
                break;
            case 2:
                sr.color=Color.yellow;
                break;
            case 3:
                sr.color=Color.black;
                break;
            case 4:
                sr.color=Color.red;
                break;
            default:
                break;
        }

    }

    public Vector3 s_acceleration{
        get { return acceleration; }
        set { acceleration = value; }
    }

    public Vector3 s_velocity{
        get { return velocity; }
        set { velocity = value; }
    }

    public int s_ID{
        get { return ID; }
        set { ID = value; }
    }
}
