using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Attack()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i > 3)
            {
                transform.Translate(Vector3.up);
                return true;
            }
            
            
        }
        
        
       return false;

        
    }


    public override void Damaged(int damage)
    {
        Debug.Log($"Enemy Class: Damage recived: {damage}");

       base.Damaged(damage);

        if (hp<0)
        {
            Debug.Log("Dead :"+gameObject.name);
            Destroy(gameObject);
        }

    }
}
