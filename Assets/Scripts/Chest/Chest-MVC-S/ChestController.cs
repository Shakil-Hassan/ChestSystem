using UnityEngine;

public class ChestController
{
    public ChestModel ChestModel;
    public ChestView ChestView;
    public ChestSpawner ChestSpawner;
    private Coroutine _timerCoroutine;
    
    public ChestController(ChestModel chestModel, ChestView chestView, ChestSpawner chestSpawner)
    {
        ChestModel = chestModel;
        ChestView = chestView;
        ChestSpawner = chestSpawner;
        ChestView.SetChestController(this);
        UpdateChestData();
    }
    
    public void ChestClicked()
    {
        Debug.Log("Chest clicked: " + ChestModel.ChestData.chestType);
        PopupService.Instance.ShowChestSpawnPopup(ChestModel.ChestData, StartUnlockingByTimer, OnStartUnlockingByGems);
    }

    private void StartUnlockingByTimer()
    {
        ChestView.StartTimer(ChestModel.ChestData.chestUnlockTime);
    }

    public void OnChestUnlocked()
    {
        PopupService.Instance.ShowRewardedChestPopup(ChestModel.ChestData, RemoveChestOnTimerCompleted);
    }

    public void OnStartUnlockingByGems()
    {
        PopupService.Instance.OnUnlockByGems(RemoveChestByGemsBtnClick);
    }

    public void RemoveChestByGemsBtnClick()
    {
        ChestView.RemoveChest();
        ChestSpawner.RemoveChest(ChestModel, ChestView.chestSlotIndex);
    }
    
    public void RemoveChestOnTimerCompleted()
    {
        ChestView.RemoveChest();
        ChestSpawner.RemoveChest(ChestModel, ChestView.chestSlotIndex);
    }
    
    private void UpdateChestData()
    {
        ChestView.UpdateChestData(ChestModel.ChestData.chestImage, ChestModel.ChestData.chestName);
    }
}
