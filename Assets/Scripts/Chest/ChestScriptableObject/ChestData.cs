using UnityEngine;

[CreateAssetMenu(fileName = "New Chest Data", menuName = "Chest Data")]
public class ChestData : ScriptableObject
{
    [Header("Chest Type")]
    public ChestType chestType;
    public Sprite chestImage;
    public string chestName;
    [Header("Range")]
    public int coinMinValue;
    public int coinMaxValue;
    public int gemsMinValue;
    public int gemsMaxValue;
    [Header("Unlock Values")]
    public float chestUnlockTime;
}