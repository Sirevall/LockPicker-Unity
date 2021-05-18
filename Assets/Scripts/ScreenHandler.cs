using UnityEngine;

public class ScreenHandler : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject badEndScreen;
    [SerializeField] private GameObject goodEndScreen;
    [SerializeField] private GameObject controversialEndScreen;
    [SerializeField] private GameObject specialButton;
    [SerializeField] private float timeToEnableSpecialButton;
    private DoorLock doorLock;
    private GameObject currentScreen;
    private TimerHandler timerHandler;

    void Start()
    {
        doorLock = GetComponent<DoorLock>();
        timerHandler = GetComponent<TimerHandler>();
        startScreen.SetActive(true);
        currentScreen = startScreen;
    }
    private void Update()
    {
        if (timerHandler.StopTimer == true)
        {
            timerHandler.ResetTimer();
            ChangeScreen(badEndScreen);
        }
        if (timerHandler.TimeLeft <= timeToEnableSpecialButton)
        {
            SwitchSpecialButton(true);
        }
        if (doorLock.GetStatusOpenDoor == true)
        {
            timerHandler.ResetTimer();
            doorLock.GetStatusOpenDoor = false;
            ChangeScreen(goodEndScreen);
        }
    }
    public void ChangeScreen(GameObject nextScreen)
    {
        currentScreen.SetActive(false);
        nextScreen.SetActive(true);
        currentScreen = nextScreen;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SwitchSpecialButton(bool statusButton)
    {
        specialButton.SetActive(statusButton);
    }
}
