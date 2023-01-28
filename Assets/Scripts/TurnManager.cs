using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnManager : MonoBehaviour
{
    #region Singleton
    public static TurnManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] TMP_Text PlayerNo;
    [SerializeField] GameObject WinScreen;
    [SerializeField] TMP_Text Winner;



    [SerializeField] int TurnNumber = 0;

    [SerializeField] List<GameObject> CardHolders;
    [SerializeField] List<PlayerController> playerControllers;

    [HideInInspector] public Card PreviouslyUsedCard;

    private void Start()
    {
        TurnOffAllCards();
        StartCoroutine(Wait(1f));

        PlayerNo.text = (TurnNumber + 1).ToString();
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);

        playerControllers[TurnNumber].TurnStart();
        CardHolders[TurnNumber].SetActive(true);

        PlayerNo.gameObject.SetActive(true);

        PlayerNo.text = (TurnNumber + 1).ToString();
    }

    private void TurnOffAllCards()
    {
        PlayerNo.gameObject.SetActive(false);

        foreach(GameObject i in CardHolders)
        {
            i.SetActive(false);
        }
    }

    public void NextTurn()
    {
        TurnNumber++;
        if(TurnNumber > 1)
        {
            TurnNumber = 0;
        }

        TurnOffAllCards();
        StartCoroutine(Wait(2f));

    }

    public void Win(int WinnerNo)
    {
        WinScreen.SetActive(true);
        Winner.text = WinnerNo.ToString();
    }


    public void Exit()
    {
        Application.Quit();
    }
}
