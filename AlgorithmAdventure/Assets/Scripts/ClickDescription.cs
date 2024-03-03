using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDescription : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler {

    public GameObject potionUI;

    public void OnPointerEnter(PointerEventData eventData) {
        potionUI.SetActive(true);

        if (Input.GetKey(KeyCode.E)) {
            Debug.Log("Picked");
            gameObject.SetActive(false);
            Debug.Log(gameObject);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        potionUI.SetActive(false);
    }

}
