using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerEconomyUI economyUI;
    [SerializeField] CardsDeck cardsDeck;

    [SerializeField] List<GameObject> playerCardObjects;

    public int Builders = 2;
    public int Bricks = 5;

    public int Soldiers = 2;
    public int Weapons = 5;

    public int Magic = 2;
    public int Crystals = 5;

    public int Castle = 30;
    public int Fence = 10;

    private void Start()
    {
        UpdateValues();
        StartCoroutine(FillPlayerCardsList());
    }

    private IEnumerator FillPlayerCardsList()
    {
        yield return new WaitForSeconds(1f);
        foreach(GameObject i in playerCardObjects)
        {
            i.GetComponent<PlayerCard>().card = cardsDeck.GiveCard();
            i.GetComponent<PlayerCard>().DisplayCard();
            i.GetComponent<PlayerCard>().CheckUseablity(this);

        }
    }

    private void UpdateValues()
    {
        economyUI.NoOfBuilders.text = Builders.ToString();
        economyUI.NoOfBricks.text = Bricks.ToString();

        economyUI.NoOfSoldiers.text = Soldiers.ToString();
        economyUI.NoOfWeapons.text = Weapons.ToString();

        economyUI.NoOfMagic.text = Magic.ToString();
        economyUI.NoOfCrystals.text = Crystals.ToString();

        economyUI.CastleValue.text = Castle.ToString();
        economyUI.FenceValue.text = Fence.ToString();
    }

    private void IncreaseEconomyValue()
    {
        Bricks += Builders;

        Weapons += Soldiers;

        Crystals += Magic;

        UpdateValues();
    }

}