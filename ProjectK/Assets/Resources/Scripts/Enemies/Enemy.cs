using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;
    public float damage;
    

    public virtual bool Attack()
    {

        return true;
    }

    public virtual void Damaged()
    {

       
    }

}
