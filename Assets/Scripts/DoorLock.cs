using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class DoorLock : MonoBehaviour
{
    [SerializeField] private int[] startPinValues;
    [SerializeField] private int[] openDoorPinValues;
    [SerializeField] private Text[] textPinValues;
    [SerializeField] private Text openDoorPinValuesText;

    private int[] currentPinValues;
    private bool doorOpen = false;
    private PinMove pinMove;

    private void Start()
    {
        openDoorPinValuesText.text = string.Join(", ", openDoorPinValues);
        currentPinValues = new int[startPinValues.Length];
        SetDefaultValuePins();
        pinMove = GetComponent<PinMove>();
    }
    private void Update()
    {
        DisplayValueLockPins();
    }
    public int[] DoorLockValuePins
    {
        get
        {
            return currentPinValues;
        }
        set
        {
            currentPinValues = value;
            CheckOpenLock();
            pinMove.SetPinPositions();
        }
    }
    public bool GetStatusOpenDoor
    {
        get
        {
            return doorOpen;
        }
        set
        {
            doorOpen = value;
        }
    }
    public void DisplayValueLockPins()
    {
        for (int i = 0; i < currentPinValues.Length; i++)
        {
            textPinValues[i].text = currentPinValues[i].ToString();
        }
    }
    public void SetDefaultValuePins()
    {
        for (int i = 0; i < currentPinValues.Length; i++)
        {
            currentPinValues[i] = startPinValues[i];
        }
    }
    private void CheckOpenLock()
    {
        if (currentPinValues.SequenceEqual(openDoorPinValues))
        {
            doorOpen = true;
        }
    }
}
