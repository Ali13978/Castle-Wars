using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class Card : ScriptableObject
{
    public string Name;
    public Sprite BgSprite;
    public Color BgColor;
    public Sprite CardImage;

    [HideInInspector]
    public enum Type{ Bricks, Weapon, Crystal};


    [SerializeField] public Type economyType;

    public int EconomyReq;

    [Header("Card Use info")]

    public string UseText;

    [Header("Change resources")]
    public int AddCastle;
    public int AddFence;
    public int AddBuilder;
    public int AddBricks;
    public int AddWeapons;
    public int AddCrystals;
    public int AddMagic;
    public int AddSoldier;
    
    public int SubCastle;
    public int SubBricks;
    public int SubWeapons;
    public int SubCrystals;


    [Header("Attack")]
    public int AddAttack;

    [Header("InDeck")]
    public int TimesInDeck = 2;

}
