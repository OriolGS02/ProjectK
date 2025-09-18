using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public Transform PlayerLocation;
    CinemachineVirtualCamera BattleCam;

    public Animator animator;

    BattleBehavour BattleBehavour;
    UI_Manager ui_manager;

    // Start is called before the first frame update
    void Start()
    {
        BattleCam=GameObject.Find("CM_Virtual_Battle").GetComponent<CinemachineVirtualCamera>();
        BattleBehavour=GameObject.Find("Canvas").GetComponentInChildren<BattleBehavour>();
        ui_manager = GameObject.Find("UI_Manager").GetComponentInChildren<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndBattle()
    {
        ShowUICards(false);
        CamManagement(false);
        
    }



    public void OpenEndUI() 
    {
        ui_manager.EndBattleUI();
    }

    public IEnumerator StartBattle() 
    {
        yield return new WaitForSecondsRealtime(3);
        BattleBehavour.PaneInteraction(true);
        ui_manager.SetBattleUI();// set hps of everibody
        yield break;

    }

    public void ShowUICards(bool show) 
    {
        BattleBehavour.PaneInteraction(show);
    }

    public void CamManagement(bool battle)
    {
        animator.SetTrigger("Fade");
        if (battle) 
        {

            BattleCam.m_Priority = 100;
            StartCoroutine(StartBattle());
            
        }
        else { BattleCam.m_Priority = 0; }
    }





}
