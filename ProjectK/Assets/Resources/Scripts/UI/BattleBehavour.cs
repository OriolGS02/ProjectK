using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.EditorCoroutines.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleBehavour : MonoBehaviour
{
    [SerializeField]
    CardDisplay selectedCard;

    [SerializeField]
    CanvasGroup panelImage;

    

    bool fade=false;

    public bool AttackDone=false;
    // Start is called before the first frame update
    void Start()
    {
        panelImage = GetComponent<CanvasGroup>();
        StartCoroutine(FadePanel(1, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
       

        if (selectedCard!=null) 
        {
            
            if (Input.GetMouseButtonDown(0)) // left click
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.collider.gameObject.name);

                    Enemy en;
                    PlayerCombatBehavour player;


                    CardData.TypeCard everything= CardData.TypeCard.Offensive| CardData.TypeCard.Defensive;
                    if ((selectedCard.cardData.type_Card & everything)==everything) 
                    {
                        
                        
                        if (hit.collider.TryGetComponent<Enemy>(out en))//behavour if we create a heal card 
                        {
                            player = GameObject.Find("Player").GetComponent<PlayerCombatBehavour>();
                            

                            StartCoroutine(PlayCards(player, en));

                        }

                    }

                    else if (selectedCard.cardData.type_Card == CardData.TypeCard.Defensive)
                    {

                      

                        if (hit.collider.TryGetComponent<PlayerCombatBehavour>(out player))//behavour if we create a heal card 
                        {
                           


                            StartCoroutine(PlayCards(player, null));

                        }
                    }

                    else if (selectedCard.cardData.type_Card == CardData.TypeCard.Offensive)
                    {
                        
                        if (hit.collider.TryGetComponent<Enemy>(out en))//behavour if we create a heal card 
                        {
                            player = GameObject.Find("Player").GetComponent<PlayerCombatBehavour>();
                            


                            StartCoroutine(PlayCards(player, en));// fer amb corrutinar per que fins que latac no s'acabi no pugi seguir

                           
                           


                            

                            

                        }
                    }
                    
                
                }

                
                
            }
        }

        if (AttackDone) 
        {
            StartCoroutine(ResetPlayerAction());
        }

        if (selectedCard != null && Input.GetKeyDown(KeyCode.Escape))
        {
            PaneInteraction(true);
            selectedCard = null;
        }
    }

    IEnumerator ResetPlayerAction()
    {
        yield return new WaitForSecondsRealtime(5);
        selectedCard= null;
        AttackDone=false;
        yield return null;
    }

    IEnumerator PlayCards(PlayerCombatBehavour player, Enemy en) 
    {
        yield return StartCoroutine(selectedCard.PlayCard(player, en));

        // Coroutine is finished here
        AttackDone = true;
        Debug.Log("Attack finished, AttackDone set to true");
    }


    public void CardSelected(CardDisplay cardBehavour) 
    {


        if (selectedCard == null || selectedCard != cardBehavour)
        {
            selectedCard = cardBehavour;
            PaneInteraction(false);
        }
        else if (selectedCard == cardBehavour) 
        {
            selectedCard = null;
        }

        

    }

    public void PaneInteraction(bool show) 
    {
        
        
        if (show)
        {
            StartCoroutine(FadePanel(0, 1, 0.5f));
        }
        else
        {
            StartCoroutine(FadePanel(1, 0, 0.5f));
        }
        
    }

    private IEnumerator FadePanel(float start, float end,float duration) 
    {
        float counter = 0;

        
        while (counter < duration)
        {
            
            
            panelImage.alpha = Mathf.Lerp(start,end,counter/duration);
            counter += Time.deltaTime;
            yield return null;

        }
        panelImage.alpha = end;


    }
}
