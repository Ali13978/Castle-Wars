using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCard : MonoBehaviour
{
    public Card card;
    [Space()]
    [SerializeField] Image background;
    [SerializeField] Image economyImage;
    [SerializeField] TMP_Text economyReq;
    [SerializeField] TMP_Text nameText;
    [SerializeField] Image conceptArt;
    [SerializeField] TMP_Text description;

    [Space(10)]
    [SerializeField] bool isUseable;

    [SerializeField] GameObject BlurImage;
    [SerializeField] Button button;


    public void DisplayCard()
    {
        economyReq.text = card.EconomyReq.ToString();
        nameText.text = card.Name.ToString();
        description.text = card.UseText;
        background.color = card.BgColor;
    }

    public void CheckUseablity(PlayerController playerController)
    {
        Card card = GetComponent<PlayerCard>().card;

        if (card.economyType == Card.Type.Bricks)
        {
            if (playerController.Bricks >= card.EconomyReq)
            {
                isUseable = true;
            }
            else
            {
                isUseable = false;
            }
        }

        else if (card.economyType == Card.Type.Crystal)
        {
            if (playerController.Crystals >= card.EconomyReq)
            {
                isUseable = true;
            }
            else
            {
                isUseable = false;
            }
        }

        else if (card.economyType == Card.Type.Weapon)
        {
            if (playerController.Weapons >= card.EconomyReq)
            {
                isUseable = true;
            }
            else
            {
                isUseable = false;
            }
        }

        MakeUseable();
    }

    private void MakeUseable()
    {
        if (isUseable)
        {
            BlurImage.SetActive(false);
            button.interactable = true;
        }
        else
        {
            BlurImage.SetActive(true);
            button.interactable = false;
        }
    }
}
