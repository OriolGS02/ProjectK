using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    public List<Enemy> roundOrder;

    [SerializeField]
    PlayerMovement player; //create a script for the attacks/battle on player
    [SerializeField]
    PlayerCombatBehavour playerAttacks;

    [SerializeField]
    Transform enemiesPlace;
    public Transform playerPlace;

    GameManager gameManager;
    int rows = 0;


    
    public int nEnemy = 0;
    int playerRound;

    bool battleStart = false;
    public bool playerAttacked=false;


    bool OpenUi = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
        
       

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }


   




    public void SetOrder(List<Enemy> list,PlayerMovement individual) 
    {
        gameManager.PlayerLocation = individual.transform;
        if (roundOrder.Count<1)
        {
            roundOrder.AddRange(list);
            player = individual.GetComponent<PlayerMovement>();
            player.fighting = true;

            playerAttacks=individual.gameObject.GetComponent<PlayerCombatBehavour>();

            nEnemy=roundOrder.Count;
            
        }


        PlaceBattle();

        gameManager.CamManagement(true);
    }

    public void PlaceBattle() 
    {
        
        player.transform.position = (playerPlace.position+new Vector3(0, player.transform.localScale.y/2, 0));
        player.transform.position = playerPlace.position;
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
        gameManager.StartBattle();
        

    }

    IEnumerator Battle() 
    {
        

        Debug.Log("in corroutine");
        while (roundOrder.Count > 0 )//or player alive
        {
            if (nEnemy < roundOrder.Count)
            {
                if (roundOrder[nEnemy] == null)
                {
                    roundOrder.RemoveAt(nEnemy);
                    
                }
                else 
                {
                    if (roundOrder[nEnemy].Attack())
                    {
                        Debug.Log("enemy attacked");
                        yield return new WaitForSecondsRealtime(2f); // enemy delay
                        nEnemy++;
                    }

                    Debug.Log("enemy doing attack");
                    yield return new WaitForSecondsRealtime(2);
                }

                
                
            }
            else 
            {
                yield return StartCoroutine(gameManager.StartBattle());

                // wait until player performs an attack
                bool playerDone = false;
                while (!playerDone)
                {
                    if (playerAttacks.Attack())
                    {
                        Debug.Log("Player attacked!");
                        playerDone = true;

                    }
                    yield return null; // check again next frame
                }

                // small pause before next round
                yield return new WaitForSecondsRealtime(2f);
                nEnemy = 0;

            }
                

        }

        Debug.Log("Zero enemies left");

        //call a function that show the rewards

        
        //call a function that return the player to the area
        gameManager.OpenEndUI();
        player.fighting = false;
        yield break;
        

       


    }



}
