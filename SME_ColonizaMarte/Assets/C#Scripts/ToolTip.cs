using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject InfoPanel;

    public void OnPointerEnter(PointerEventData eventData)
    {
        InfoPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InfoPanel.SetActive(false);
    }
}
