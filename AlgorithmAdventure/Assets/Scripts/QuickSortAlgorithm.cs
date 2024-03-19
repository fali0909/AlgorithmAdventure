using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuickSortAlgorithm : MonoBehaviour
{

    //ranNum variables
    [Header("Random Numbers")]
    [SerializeField] private TMP_Text[] ranNum;

    //box variables
    [Header("Boxes")]
    [SerializeField] private Image[] boxes;

    // Store the last text that was dragged onto each box
    private TMP_Text[] lastDraggedText;

    private void Start()
    {
        lastDraggedText = new TMP_Text[boxes.Length];
    }

    private void Update()
    {
        for (int i = 0; i < Mathf.Min(ranNum.Length, boxes.Length); i++)
        {
            if (IsOverlapping(ranNum[i].rectTransform, boxes[i].rectTransform) && Input.GetMouseButtonUp(0))
            {
                // Only log the text if it's the first one being dragged onto the box
                if (lastDraggedText[i] == null || lastDraggedText[i] != ranNum[i])
                {
                    Debug.Log("UI Text is overlapping with UI Image");
                    Debug.Log("Text Content: " + ranNum[i].text);
                    lastDraggedText[i] = ranNum[i];
                }
            }
        }
    }


    bool IsOverlapping(RectTransform rectTransform1, RectTransform rectTransform2)
    {
        Rect rect1 = GetWorldRect(rectTransform1);
        Rect rect2 = GetWorldRect(rectTransform2);

        return rect1.Overlaps(rect2);
    }
    Rect GetWorldRect(RectTransform rectTransform)
    {
        Vector2 size = Vector2.Scale(rectTransform.rect.size, rectTransform.lossyScale);
        Rect rect = new Rect(rectTransform.position.x, rectTransform.position.y, size.x, size.y);
        rect.x -= rectTransform.sizeDelta.x * 0.5f;
        rect.y -= rectTransform.sizeDelta.y * 0.5f;

        return rect;
    }

}
