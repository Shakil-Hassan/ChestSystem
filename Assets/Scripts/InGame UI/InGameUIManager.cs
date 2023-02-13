using TMPro;
using UnityEngine;

public class InGameUIManager : MonoSingletonGeneric<InGameUIManager>
{
    [SerializeField] private GameObject coinsBar;
    [SerializeField] private GameObject gemsBar;
    
    [SerializeField] private TMP_Text coinsBarCoinValue;
    [SerializeField] private TMP_Text gemsBarGemsValue;
    [SerializeField] private int currentCoins = 100;
    [SerializeField] private int currentGems = 100;
    
    public void SetTopBarContent(int coinAmount, int gemAmount)
    {
        currentCoins += coinAmount;
        currentGems += gemAmount;
        coinsBarCoinValue.text = currentCoins.ToString();
        gemsBarGemsValue.text = currentGems.ToString();
    }

    public void SpendGems(int removeGemsAmount)
    {
        currentGems -= removeGemsAmount;
        gemsBarGemsValue.text = currentGems.ToString();
    }

    public int GetCurrentGemsCount()
    {
        return currentGems;
    }
}