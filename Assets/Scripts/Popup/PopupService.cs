using System;
using UnityEngine;

public class PopupService : MonoSingletonGeneric<PopupService>
{

    [SerializeField] private ChestPopupManager chestPopupManager;
    public void ShowChestSpawnPopup(ChestData chestData, Action onTimerClick = null, Action actionForOnStartUnlockingByGems = null)
    {
        chestPopupManager.OnChestSpawnPopup(chestData , onTimerClick, actionForOnStartUnlockingByGems);
    }

    public void ShowRewardedChestPopup(ChestData chestData, Action onTimerEnded = null)
    {
        chestPopupManager.OnTimerCompleted(chestData, onTimerEnded);
    }

    public void OnUnlockByGems(Action onGemsBtnClick = null)
    {
        chestPopupManager.OnStartUnlockingByGems(onGemsBtnClick);
    }

}
