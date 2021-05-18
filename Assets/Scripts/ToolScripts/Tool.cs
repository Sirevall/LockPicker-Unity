using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    [SerializeField] protected int[] toolPinValues;
    [SerializeField] [Multiline] protected string toolDescription;
    protected int[] lockPinValues;
    protected GameObject doorLockObject;
    protected DoorLock doorLock;
    private void Start()
    {
        doorLockObject = GameObject.Find("GameManager");
        doorLock = doorLockObject.GetComponent<DoorLock>();
        lockPinValues = doorLock.DoorLockValuePins;
    }

    public virtual string GetToolDescription { get { return toolDescription; } }

    public virtual void UseToolClick()
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
        if (value > 10) return value = 10;
        else if (value < 0) return value = 0;
        else return value;
    }
}
