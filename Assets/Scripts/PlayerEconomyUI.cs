using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerEconomyUI : MonoBehaviour
{
    [Header("Group 1")]
    [SerializeField] public TMP_Text NoOfBuilders;
    [SerializeField] public TMP_Text NoOfBricks;

    [Header("Group 2")]
    [SerializeField] public TMP_Text NoOfSoldiers;
    [SerializeField] public TMP_Text NoOfWeapons;

    [Header("Group 3")]
    [SerializeField] public TMP_Text NoOfMagic;
    [SerializeField] public TMP_Text NoOfCrystals;

    [Header("Group 4")]
    [SerializeField] public TMP_Text CastleValue;
    [SerializeField] public TMP_Text FenceValue;
}
