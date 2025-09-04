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
    // Start is called before the first frame update
    void Start()
    {
        BattleCam=GameObject.Find("CM_Virtual_Battle").GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndBattle()
    {

    }

    public void CamManagement(bool battle)
    {
        animator.SetTrigger("Fade");
        if (battle) 
        {

            BattleCam.m_Priority = 100;
        }
        else { BattleCam.m_Priority = 0; }
    }





}
