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
    private List<TMP_Text>[] lastDraggedTexts;

    private void Start()
    {
        lastDraggedTexts = new List<TMP_Text>[boxes.Length];
        for (int i = 0; i < boxes.Length; i++)
        {
            lastDraggedTexts[i] = new List<TMP_Text>();
        }
    }

    private void Update()
    {
        for (int i = 0; i < Mathf.Min(ranNum.Length, boxes.Length); i++)
        {
            if (IsOverlapping(ranNum[i].rectTransform, boxes[i].rectTransform) && Input.GetMouseButtonUp(0))
            {
                // Only log the text if it's the first one being dragged onto the box
                if (!lastDraggedTexts[i].Contains(ranNum[i]))
                {
                    Debug.Log("UI Text is overlapping with UI Image");
                    Debug.Log("Text Content: " + ranNum[i].text);
                    lastDraggedTexts[i].Add(ranNum[i]);
                }
            }
        }

        // Check if the numbers are sorted
        for (int i = 0; i < boxes.Length; i++)
        {
            if (!IsSorted(lastDraggedTexts[i]))
            {
                Debug.Log("The numbers in box " + i + " are not sorted.");
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

    bool IsSorted(List<TMP_Text> texts)
    {
        for (int i = 1; i < texts.Count; i++)
        {
            int currentNumber = int.Parse(texts[i].text);
            int previousNumber = int.Parse(texts[i - 1].text);

            if (currentNumber < previousNumber)
            {
                return false;
            }
        }

        return true;
    }
}
