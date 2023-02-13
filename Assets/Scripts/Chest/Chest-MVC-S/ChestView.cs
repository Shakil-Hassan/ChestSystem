using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestView : MonoBehaviour
{
    private ChestController _chestController;
    public int chestSlotIndex;
    [SerializeField]
    private Image chestImage;
    [SerializeField]
    private TMP_Text nameText;
    public TMP_Text timerText;
    public GameObject timer;
    private Coroutine _timerCoroutine;
    [HideInInspector] public float timerCount;
    
    public void UpdateChestData(Sprite image, string chestName)
    {
        chestImage.sprite = image;
        nameText.text = chestName;
    }

    public void OnMouseDown()
    {
        _chestController.ChestClicked();
    }

    public void StartTimer(float timeLeft)
    {
        
        Debug.Log("Starting timer for Chest " + chestSlotIndex);
        UpdateChestUnlockTimer(timeLeft);
    }
    
    private void UpdateChestUnlockTimer(float timeLeft)
    {
        timer.SetActive(true);
        if (_timerCoroutine != null)
        {
            StopCoroutine(_timerCoroutine);
        }
        _timerCoroutine = StartCoroutine(CountdownTimer(timeLeft));
    }
    
    private IEnumerator CountdownTimer(float timeLeft)
    {
        timerCount = timeLeft;
        while ( timerCount >= 0)
        {
            int hours = (int)(timerCount / 3600);
            int minutes = (int)(timerCount % 3600 / 60);
            int seconds = (int)(timerCount % 60);
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
            yield return new WaitForSeconds(1f);
            timerCount--;
        }
        timer.SetActive(false);
        _timerCoroutine = null;
        _chestController.OnChestUnlocked();
    }

    public void RemoveChest()
    {
        Destroy(gameObject);
    }
    
    public void SetChestController(ChestController chestController)
    {
        _chestController = chestController;
    }
    
}
