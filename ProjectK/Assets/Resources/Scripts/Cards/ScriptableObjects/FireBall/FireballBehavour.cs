using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehavour : MonoBehaviour
{
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Launch();
    }

    public bool Launch() 
    {
        if (Vector3.Distance(transform.position,enemy.transform.position)>0.5f) 
        {
            Vector3 move = Vector3.MoveTowards(transform.position, enemy.transform.position, 15*Time.deltaTime); // mirar perque no es mou 



            transform.position = move;

            return false;
        }
        else 
        {
            Debug.Log("fireball reach");
            enemy.Damaged(5);
            Destroy(this.gameObject);
            return true;

        }
            
    }


    







}
