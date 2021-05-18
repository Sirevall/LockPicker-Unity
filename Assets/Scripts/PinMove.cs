using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMove : MonoBehaviour
{
    [SerializeField] GameObject[] pins;
    private DoorLock doorLock;
    private RectTransform rectTransformPin;
    private Vector2 anchoredPinPosition;

    private void Start()
    {
        doorLock = GetComponent<DoorLock>();
    }
    public void SetPinPositions()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            rectTransformPin = pins[i].GetComponent<RectTransform>();
            anchoredPinPosition = rectTransformPin.anchoredPosition;
            anchoredPinPosition.y = (float)doorLock.DoorLockValuePins[i] * 4f + 10f;
            rectTransformPin.anchoredPosition = anchoredPinPosition;
        }
        
    }


}
