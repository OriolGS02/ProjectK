using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Manager : MonoBehaviour
{
    GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Image WinLosePanel;

    
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        WinLosePanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBattleUI()
    {
        //implement hp bars of player abd enemies on the battle
    }


    public void EndBattleUI() 
    {
        //show the ui to chosing card
        //open the end battle menu
        WinLosePanel.gameObject.SetActive(true);
    }

    public void CloseUI() 
    {
        //close the ui panels of end battle
        WinLosePanel.gameObject.SetActive(false);
        gameManager.EndBattle();
    }





}
