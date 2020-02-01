using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlDisaster : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    InteractableBase actualInteractable = null;

    public void OnPointerDown(PointerEventData eventData)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                actualInteractable = hit.collider.GetComponent<InteractableBase>();
                actualInteractable.OnStartInteraction();
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(actualInteractable != null)
            actualInteractable.OnCancelInteraction();
    }
}
