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
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerController enemyPlayerController;

    [Space(10)]
    [SerializeField] bool isUseable;

    [SerializeField] GameObject BlurImage;

    public void DisplayCard()
    {
        economyReq.text = card.EconomyReq.ToString();
        nameText.text = card.Name.ToString();
        description.text = card.UseText;
        background.color = card.BgColor;
    }

    public void CheckUseablity(PlayerController playerController)
    {
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
        }
        else
        {
            BlurImage.SetActive(true);
        }
    }

    public void UseCard()
    {
        if (isUseable)
        {
            foreach (GameObject i in playerController.playerCardObjects)
            {
                i.GetComponent<Button>().interactable = false;
            }

            playerController.Castle += card.AddCastle;
            playerController.Fence += card.AddFence;
            playerController.Builders += card.AddBuilder;
            playerController.Bricks += card.AddBricks;
            playerController.Weapons += card.AddWeapons;
            playerController.Crystals += card.AddCrystals;
            playerController.Magic += card.AddMagic;
            playerController.Soldiers += card.AddSoldier;

            enemyPlayerController.Castle += card.SubCastle;
            enemyPlayerController.Bricks += card.SubBricks;
            enemyPlayerController.Weapons += card.SubWeapons;
            enemyPlayerController.Crystals += card.SubCrystals;

            if(card.AddAttack != 0)
            {
                int remainingAttack = card.AddAttack;

                if(enemyPlayerController.Fence > 0)
                {
                    remainingAttack = card.AddAttack - enemyPlayerController.Fence;
                    enemyPlayerController.Fence -= card.AddAttack;

                    if(enemyPlayerController.Fence < 0)
                    {
                        enemyPlayerController.Fence = 0;
                    }
                }

                if(remainingAttack > 0)
                {
                    enemyPlayerController.Castle -= remainingAttack;

                    if(enemyPlayerController.Castle < 0)
                    {
                        enemyPlayerController.Castle = 0;
                    }
                }
            }




            if(enemyPlayerController.Bricks < 0)
            {
                enemyPlayerController.Bricks = 0;
            }

            if(enemyPlayerController.Weapons < 0)
            {
                enemyPlayerController.Weapons = 0;
            }

            if(enemyPlayerController.Crystals < 0)
            {
                enemyPlayerController.Crystals = 0;
            }

            if(enemyPlayerController.Fence < 0)
            {
                enemyPlayerController.Fence = 0;
            }





            if (playerController.Castle >= 100)
            {
                playerController.Castle = 100;
                TurnManager.instance.Win(playerController.PlayerNumber);
            }

            if(enemyPlayerController.Castle <= 0)
            {
                enemyPlayerController.Castle = 0;
                TurnManager.instance.Win(playerController.PlayerNumber);
            }

            playerController.UpdateValues();
            enemyPlayerController.UpdateValues();

            playerController.cardsDeck.TakeCard(card);
            card = playerController.cardsDeck.GiveCard();
            DisplayCard();
            TurnManager.instance.NextTurn();
        }

        else
        {
            playerController.cardsDeck.TakeCard(card);
            card = playerController.cardsDeck.GiveCard();
            DisplayCard();
            TurnManager.instance.NextTurn();
        }
    }
}
