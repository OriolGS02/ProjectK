using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    public List<Enemy> roundOrder;

    [SerializeField]
    PlayerMovement player; //create a script for the attacks/battle on player

    [SerializeField]
    Transform enemiesPlace;
    public Transform playerPlace;

    GameManager gameManager;
    int rows = 0;


    bool RoundEnd = false;
    public int nEnemy = 0;

    bool battleStart = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();

        Debug.Log(playerPlace.position);

    }

    // Update is called once per frame
    void Update()
    {

       /* if (battleStart) { StartCoroutine(Battle()); }*/
        
    }




    public void SetOrder(List<Enemy> list,PlayerMovement individual) 
    {
        gameManager.PlayerLocation = individual.transform;
        if (roundOrder.Count<1)
        {
            roundOrder.AddRange(list);
            player = individual.GetComponent<PlayerMovement>();
            player.fighting = true;
            
        }


        PlaceBattle();

        gameManager.CamManagement(true);
    }

    public void PlaceBattle() 
    {
        
        player.transform.position = playerPlace.position+new Vector3(0,1,0);
        player.transform.rotation=playerPlace.rotation;

        

        for (int i = 0; i < roundOrder.Count; i++)
        {
            
            roundOrder[i].transform.position = enemiesPlace.position+new Vector3(0, (roundOrder[i].transform.localScale.y/2), 0);
            
            roundOrder[i].transform.rotation = enemiesPlace.rotation;


            if (rows < 2)
            {
                enemiesPlace.position += new Vector3(2, 0, 0);
               
            }
            else
            {
                rows = 0;
                enemiesPlace.position = enemiesPlace.position + new Vector3(-4, 0, 2);
               
            }
            rows++;

            
           

            
            
        }

        battleStart = true;
        StartCoroutine(Battle());


    }

    IEnumerator Battle() 
    {
        yield return new WaitForSeconds(3);

        while (roundOrder.Count > 0)//or enemy alive
        {
            if (nEnemy < roundOrder.Count)
            {
                if (roundOrder[nEnemy].Attack())
                {
                    Debug.Log("enemy attacked");
                    yield return new WaitForSecondsRealtime(5f); // enemy delay
                    nEnemy++;
                }
            }
            else
            {
                yield return new WaitForSecondsRealtime(10f); // player delay
                Debug.Log("Player attack");
                 // <-- add this when you implement player attack
                nEnemy = 0;
            }
            
        }

       


    }



}
