using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField]
    List<Enemy> enemies;

    BattleManager battleManager;
    // Start is called before the first frame update
    void Start()
    {

        battleManager = GameObject.Find("BattleArena").GetComponent<BattleManager>();
        foreach (Transform child in transform) 
        {
            if (child.GetComponent<Enemy>()) 
            {
                enemies.Add(child.GetComponent<Enemy>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemies.RemoveAll(e=> e== null);

        if (enemies.Count==0) 
        {
            Destroy(this.gameObject);
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) 
        {

            PlayerMovement player = other.GetComponent<PlayerMovement>();
            battleManager.SetOrder(enemies,player);

            
        }
    }


}
