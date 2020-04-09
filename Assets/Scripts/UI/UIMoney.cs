using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMoney;

    public void TakeMoney(int money)
    {
        _textMoney.text = "Монетки: " + money.ToString();
    }
}
