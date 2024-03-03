using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDescription : MonoBehaviour,  IPointerDownHandler, IPointerUpHandler {

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("Hello");
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("Bye");
    }

}
