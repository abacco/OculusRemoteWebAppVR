using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopupForestPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject popupPanel;

    void Start()
    {
        // Disable the popup panel initially
        popupPanel.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Enable the popup panel when the mouse enters the button
        popupPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Disable the popup panel when the mouse exits the button
        popupPanel.SetActive(false);
    }
}