using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    public GameObject chestPrefab;
    public ChestData[] chestDataArray;
    public Transform chestSlotsParent;
    public int maxChestsAllowed = 4;
    private Dictionary<int, ChestModel> _chestSlots = new Dictionary<int, ChestModel>();
    private ChestModel[] _chestModels;
    private ChestView[] _chestViews;
    public int currentChestCount = 0;

    private void Start()
    {
        _chestModels = new ChestModel[chestDataArray.Length];
        _chestViews = new ChestView[chestDataArray.Length];
        for (int i = 0; i < chestDataArray.Length; i++)
        {
            _chestModels[i] = new ChestModel { ChestData = chestDataArray[i] };
        }

        for (int i = 0; i < chestSlotsParent.childCount; i++)
        {
            _chestSlots.Add(i, null);
        }
    }

    private int GetNextEmptySlotIndex()
    {
        int nextIndex = -1;
        for (int i = 0; i < _chestSlots.Count; i++)
        {
            if (_chestSlots[i] == null)
            {
                nextIndex = i;
                break;
            }
        }
        Debug.Log("Next empty index: " + nextIndex);
        return nextIndex;
    }

    public void SpawnChest()
    {
        int nextEmptySlotIndex = GetNextEmptySlotIndex();
        if (nextEmptySlotIndex != -1)
        {
            int chestIndex = GetNextChestIndex();
            if (chestIndex != -1)
            {
                int chestSlotIndex = nextEmptySlotIndex;
                GameObject chestInstance = Instantiate(chestPrefab, chestSlotsParent.GetChild(chestSlotIndex));
                var chestView = chestInstance.GetComponent<ChestView>();
                var chestController = new ChestController(_chestModels[chestIndex], chestView, this);
                chestView.SetChestController(chestController);
                chestView.chestSlotIndex = chestSlotIndex;
                _chestSlots[chestSlotIndex] = _chestModels[chestIndex];
                currentChestCount++;
            }
            else
            {
                Debug.Log("No Chest Available");
            }
        }
        else
        {
            Debug.Log("No Empty Slot Available");
        }
    }

    private int GetNextChestIndex()
    {
        int nextChestIndex = -1;
        if (currentChestCount < chestDataArray.Length)
        {
            for (int i = 0; i < chestDataArray.Length; i++)
            {
                if (!_chestModels[i].IsUsed)
                {
                    nextChestIndex = i;
                    _chestModels[i].IsUsed = true;
                    break;
                }
            }
        }
        return nextChestIndex;
    }
    public void RemoveChest(ChestModel chestModel, int slotIndex)
    {
        _chestSlots[slotIndex] = null;
        chestModel.IsUsed = false;
        currentChestCount--;
    }
    
    
    
}