using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Card", menuName = "Create/Card")]
public class CardData : ScriptableObject
{
    public string Name;
    public Element type_Element;
    public float Damage;
    public string Description;
    public Sprite Image;
    public TypeCard type_Card;

    public enum Element
    {
        Normal,
        Water,
        Fire,
        Earth,
        Air,
        Chaos,
        Electricity,
        Vapor,
        Crystal,
        Flora,

    }

    [System.Flags]
    public enum TypeCard 
    {
        None = 0,
        Offensive =1<<0,
        Defensive =1<<1,
    }

    public CardBehavour cardEffect;
}
