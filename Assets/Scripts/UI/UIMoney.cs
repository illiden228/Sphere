using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMoney;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _textMoney = GetComponent<TMP_Text>();
        _player.MoneyChanged += OnMoneyChanged;
        _textMoney.text = "Монетки: 0";
    }

    public void OnMoneyChanged(int money)
    {
        _textMoney.text = "Монетки: " + money.ToString();
    }
}
