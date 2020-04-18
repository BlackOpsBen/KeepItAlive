using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    private int minAmount = 0;
    private int maxAmount = 999999999;
    private int currentBalance;
    [SerializeField] private int startingAmount = 1000;

    [SerializeField] private TextMeshProUGUI moneyText;

    private void Awake()
    {
        currentBalance = startingAmount;
        GainOrSpendMoney(0);
    }

    public void GainOrSpendMoney(int amount)
    {
        currentBalance = Mathf.Clamp(currentBalance + amount, minAmount, maxAmount);
        moneyText.text = "$" + currentBalance.ToString();
    }

    public int GetCurrentBalance()
    {
        return currentBalance;
    }
}
