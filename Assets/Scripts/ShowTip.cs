using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject tipPanel;

    private Text tipPanelText;
    private string descriptionText;

    private void Start()
    {
        tipPanelText = tipPanel.GetComponentInChildren<Text>();
        descriptionText = GetComponent<Tool>().GetToolDescription;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        tipPanelText.text = descriptionText;
        tipPanel.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        tipPanel.SetActive(false);
    }
}
