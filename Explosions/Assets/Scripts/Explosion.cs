using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float _radius = 10f;
    float D1_radius=2f, D2_radius=4f, D3_radius=6f, D4_radius=8f;
    float _time = 1f;
    float _explosionForce = 1f;
    LayerMask mask;

    private void Start()
    {
        mask=LayerMask.GetMask("Wall");
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
        GameObject[] toDestroy=colliders
            .Where(c => c.GetComponent<Destructible>()!=null)
            .Select(c => c.gameObject).ToArray();

        foreach (GameObject obj in toDestroy)
        {
            Vector3 _impulseDirection=obj.transform.position-this.transform.position;
            _impulseDirection=_impulseDirection.normalized;
            obj.gameObject.GetComponent<Rigidbody>().AddForce(_impulseDirection*apllyDistance(obj),ForceMode.Impulse);
        }
    }

    private void Update()
    {
        _time -= Time.deltaTime;
        if (_time <= 0f)
        {
            Destroy(gameObject);
        }
    }

    float apllyDistance(GameObject obj){
        float dist=Vector3.Distance(this.transform.position, obj.transform.position);
        bool hasAWall=checkWalls(obj);
        if(dist<D1_radius){
            obj.GetComponent<Destructible>().decreaseHealth(90f, hasAWall);
            return _explosionForce*30f;
        }else 
        if(dist<D2_radius && dist>D1_radius){
            obj.GetComponent<Destructible>().decreaseHealth(75d, hasAWall);
            return _explosionForce*20f;
        }else 
        if(dist<D3_radius && dist>D2_radius){
            obj.GetComponent<Destructible>().decreaseHealth(50d, hasAWall);
            return _explosionForce*10f;
        }else 
        if(dist<D4_radius && dist>D3_radius){
            obj.GetComponent<Destructible>().decreaseHealth(25d, hasAWall);
            return _explosionForce*5f;
        }
        else{return _explosionForce*0.5f;}
    }

    bool checkWalls(GameObject obj){
        Vector3 _impulseDirection=obj.transform.position-this.transform.position;
        if(Physics.Raycast(this.transform.position,_impulseDirection, out RaycastHit hit,mask)){
            return true;
        }
        else{return false;}
    }
}
