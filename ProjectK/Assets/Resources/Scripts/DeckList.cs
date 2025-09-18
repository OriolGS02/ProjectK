using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeckList", menuName = "Create/DeckList")]
public class DeckList : ScriptableObject
{
    public List<CardData> cards= new List<CardData>();
  

}
