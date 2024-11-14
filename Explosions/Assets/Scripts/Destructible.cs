using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    private bool _destroyed = false;
    private double health=100d;

    public void Destroy()
    {
        if (_destroyed)
        {
            return;
        }

        _destroyed = true;
        if (_object != null)
        {
            Instantiate(_object, transform.position, _object.transform.rotation);
        }
        Destroy(gameObject);

        
    }

    public void decreaseHealth(double dmg, bool capDamage){
        if(capDamage){health-=dmg/2f;}
        else{health-=dmg;}
        Debug.Log(health);
        if(health<=0){
            Destroy(gameObject);
        }
    }
}
