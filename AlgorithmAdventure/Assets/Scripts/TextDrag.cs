using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class TextDrag : MonoBehaviour, IDragHandler, IDropHandler
{
    private Vector3 _startPos;

    void Awake()
    {
        _startPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Update the position of the UI object while dragging
        transform.position = eventData.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Handle dropping logic if needed
        // For example, snap the UI object to a specific position
        // or perform other actions when dropped
    }
}
