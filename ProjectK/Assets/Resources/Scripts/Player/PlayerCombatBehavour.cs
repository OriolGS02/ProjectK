using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatBehavour : MonoBehaviour
{
    

    BattleBehavour battleBehavour;
    // Start is called before the first frame update
    void Start()
    {
        Canvas c=GameObject.Find("Canvas").GetComponent<Canvas>();   
        battleBehavour=c.GetComponentInChildren<BattleBehavour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool Attack()
    {

        return battleBehavour.AttackDone;
        
    }
}
