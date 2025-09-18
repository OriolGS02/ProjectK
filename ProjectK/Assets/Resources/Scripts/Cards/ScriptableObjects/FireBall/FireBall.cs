using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Create/Card Game/Effects/Fireball")]
public class FireBall : CardBehavour
{
    public int damage = 5;
    public FireballBehavour fireballObject;

    private void Awake()
    {
        fireballObject.GetComponent<GameObject>();
    }
    public override bool Action(PlayerCombatBehavour player, Enemy enemy)
    {
        
        
        if (fireballObject != null) 
        {

           // FireballBehavour fireballSpawn = Instantiate(fireballObject,new Vector3(0, player.transform.position.y+1, player.transform.position.z +1), Quaternion.identity).GetComponent<FireballBehavour>();
            FireballBehavour fireballSpawn = Instantiate(fireballObject,player.transform.position+new Vector3(0,1,1), Quaternion.identity).GetComponent<FireballBehavour>();
            fireballSpawn.enemy = enemy;

            if (!fireballSpawn.Launch())
            {
                Debug.Log("Launched");
                return false;
            }
            else 
            {
                Debug.Log("damaged");
                enemy.Damaged(damage);

                return true;
            }
            
        }
        
        return true;

        
    }
}
