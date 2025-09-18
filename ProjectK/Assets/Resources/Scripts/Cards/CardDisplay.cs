using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public CardData cardData;

    [Header("UI Elements")]
    public Text cardName;
    public Sprite icon;
    public Text Description;

    // Start is called before the first frame update
    void Start()
    {
        CardUIUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CardUIUpdate() 
    {
        cardName.text = cardData.name;
    }

    public IEnumerator PlayCard(PlayerCombatBehavour player,Enemy enemy )
    {
        if (cardData.cardEffect != null)
        {
            new WaitForSecondsRealtime(1);

            if (cardData.cardEffect.Action(player, enemy))
            {
                yield return null;
            }
            else { yield return new WaitForSecondsRealtime(2);
                Debug.Log("Attakc doing");
            }
             

         }

        

        
    }
}
