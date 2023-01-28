using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    #region Singleton
    public static TurnManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] int TurnNumber = 0;

    [SerializeField] List<GameObject> CardHolders;

    [HideInInspector] public Card PreviouslyUsedCard;

    private void Start()
    {
        TurnOffAllCards();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        CardHolders[0].SetActive(true);
    }

    private void TurnOffAllCards()
    {
        foreach(GameObject i in CardHolders)
        {
            i.SetActive(false);
        }
    }
}
