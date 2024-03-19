using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class TextDrag : MonoBehaviour, IDragHandler, IDropHandler {

    private TMP_Text textColorComponent;
    private Color originalColor;

    private Vector3 startPosition;

    void Awake() {
        startPosition = transform.position;
    }

    private void Start() {
        textColorComponent = GetComponent<TMP_Text>();
        originalColor = textColorComponent.color; 
    }

    public void OnDrag(PointerEventData eventData){
        transform.position = eventData.position;
        textColorComponent.color = Color.yellow;
    }

    public void OnDrop(PointerEventData eventData) {
        textColorComponent.color = originalColor;
    }

}
