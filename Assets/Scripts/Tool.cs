using UnityEngine;

public class Tool : MonoBehaviour
{
    [SerializeField] private int[] toolPinValues;
    [SerializeField] [Multiline] private string toolDescription;

    private int[] lockPinValues;
    private GameObject doorLockObject;
    private DoorLock doorLock;
    private int maxPinValue = 10;
    private int minPinValue = 0;

    private void Start()
    {
        doorLockObject = GameObject.Find("GameManager");
        doorLock = doorLockObject.GetComponent<DoorLock>();
        lockPinValues = doorLock.DoorLockValuePins;
    }
    public string GetToolDescription
    {
        get
        {
            return toolDescription;
        }
    }
    public void UseToolClick()
    {
        for (int i = 0; i < toolPinValues.Length; i++)
        {
            lockPinValues[i] += toolPinValues[i];
            lockPinValues[i] = CheckValueInRange(lockPinValues[i]);
        }
        doorLock.DoorLockValuePins = lockPinValues;
    }
    private int CheckValueInRange(int value)
    {
        if (value > maxPinValue)
            return maxPinValue;
        else if (value < minPinValue)
            return minPinValue;
        else
            return value;
    }
}
