using System;
using UnityEngine;
using TMPro;

public class ChestPopupManager : MonoBehaviour
{
    [SerializeField] private TMP_Text gemText;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text gemsRequiredText;
    [SerializeField] private TMP_Text timerButtonText;

    [SerializeField] private GameObject chestPopup;
    [SerializeField] private GameObject rewardedPopup;
    [SerializeField] private TMP_Text rewardedCoins;
    [SerializeField] private TMP_Text rewardedGems;

    private Action _onTimerClick;
    private Action _onTimerComplete;
    private Action _onUnlockByGemsBtnClick;
    private Action _actionForOnStartUnlockingByGems;
    private ChestData _chestData;
    private bool _isTimerRunning = false;

    public void OnChestSpawnPopup(ChestData chestData , Action onTimerClick, Action actionForOnStartUnlockingByGems)
    {
        if (_isTimerRunning)
        {
            chestPopup.SetActive(true);
            return;
        }
        
        chestPopup.SetActive(true);
        _chestData = chestData;
        coinText.text= $"{chestData.coinMinValue} - {chestData.coinMaxValue}";
        gemText.text = $"{chestData.gemsMinValue} - {chestData.gemsMaxValue}";
        RequiredTime(chestData.chestUnlockTime);
        gemsRequiredText.text = CalculateGemsCost(chestData.chestUnlockTime).ToString();
        
        _onTimerClick = onTimerClick;
        _actionForOnStartUnlockingByGems = actionForOnStartUnlockingByGems;
    }

    public void OnTimerCompleted(ChestData chestData, Action onTimerComplete)
    {
        rewardedPopup.SetActive(true);
        int coinAmount = UnityEngine.Random.Range(chestData.coinMinValue, chestData.coinMaxValue);
        int gemsAmount = UnityEngine.Random.Range(chestData.gemsMinValue, chestData.gemsMaxValue);
        rewardedCoins.text = coinAmount.ToString();
        rewardedGems.text = gemsAmount.ToString();
        
        _onTimerComplete = onTimerComplete;
        InGameUIManager.Instance.SetTopBarContent(coinAmount, gemsAmount);
    }
    
    public void RequiredTime(float timeLeft)
    {
        float timerCount = timeLeft;
        int hours = (int)(timerCount / 3600);
        int minutes = (int)(timerCount % 3600 / 60);
        int seconds = (int)(timerCount % 60);
        timerButtonText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
    
    public int CalculateGemsCost(float timeLeft)
    {
        return (int)Math.Ceiling(timeLeft / 600f);
    }
    
    public void OnStartUnlockingByGems( Action onUnlockByGemsBtnClick)
    {
        int coinAmount = UnityEngine.Random.Range(_chestData.coinMinValue, _chestData.coinMaxValue);
        int gemsAmount = UnityEngine.Random.Range(_chestData.gemsMinValue, _chestData.gemsMaxValue);
        
        int gemsCost = CalculateGemsCost(_chestData.chestUnlockTime);
        if (gemsCost > InGameUIManager.Instance.GetCurrentGemsCount())
        {
            Debug.Log("Insufficient gems");
            return;
        }
        InGameUIManager.Instance.SpendGems(gemsCost);
        _onUnlockByGemsBtnClick = onUnlockByGemsBtnClick;
        InGameUIManager.Instance.SetTopBarContent(coinAmount, gemsAmount);
    }

    public void OnTimerButtonClick()
    {
        if (_isTimerRunning)
        {
            return;
        }

        _isTimerRunning = true;
        _onTimerClick?.Invoke();
    }
    
    public void OnUnlockByGemsBtnClicked()
    {
        _actionForOnStartUnlockingByGems?.Invoke();
        _onUnlockByGemsBtnClick?.Invoke();
        _isTimerRunning = false;
    }
    
    public void OnCloseButton()
    {
        chestPopup.SetActive(false);
    }

    public void OnCloseRewardedPopup()
    {
        _isTimerRunning = false;
        rewardedPopup.SetActive(false);
        _onTimerComplete?.Invoke();
    }
}
