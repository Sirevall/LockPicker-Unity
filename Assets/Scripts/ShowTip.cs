using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject TipPanel;
    private Text tipPanelText;
    private string descriptionText;
    private void Start()
    {
        tipPanelText = TipPanel.GetComponentInChildren<Text>();
        descriptionText = GetComponent<Tool>().GetToolDescription;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        tipPanelText.text = descriptionText;
        TipPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TipPanel.SetActive(false);
    }
}
