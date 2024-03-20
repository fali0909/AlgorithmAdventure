using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuickSortAlgorithm : MonoBehaviour {

    //ranNum variables
    [Header("Random Numbers")]
    [SerializeField] private TMP_Text[] ranNum;

    //box variables
    [Header("Boxes")]
    [SerializeField] private Image[] boxes;

    private bool[] hasBeenLogged;

    private int filledBoxesCount;

    private List<int> numbersList;

    private bool isInOrder;

    private void Start() {
        hasBeenLogged = new bool[ranNum.Length];
        filledBoxesCount = 0;
        numbersList = new List<int>();
        isInOrder = true;
    }

    private void Update() {
        for (int i = 0; i < Mathf.Min(ranNum.Length, boxes.Length); i++) {
            if (Input.GetMouseButtonUp(0) && !hasBeenLogged[i]) {
                foreach (Image box in boxes) {
                    if (IsOverlapping(ranNum[i].rectTransform, box.rectTransform)) {
                        if (int.TryParse(ranNum[i].text, out int number)) {
                            Debug.Log("Integer Value: " + number);
                            hasBeenLogged[i] = true;
                            numbersList.Add(number);
                            filledBoxesCount++;

                            if (numbersList.Count > 1 && number < numbersList[numbersList.Count - 2]) {
                                isInOrder = false;
                            }

                            if (filledBoxesCount == boxes.Length) {
                                if (isInOrder) {
                                    Debug.Log("All boxes have been filled. Numbers are in order");
                                } else {
                                    Debug.Log("All boxes have been filled. The numbers are not in order.");
                                }
                            }
                        }
                    }
                }               
            }
        }


    bool IsOverlapping(RectTransform rectTransform1, RectTransform rectTransform2) {
        Rect rect1 = GetWorldRect(rectTransform1);
        Rect rect2 = GetWorldRect(rectTransform2);

        return rect1.Overlaps(rect2);
    }

    Rect GetWorldRect(RectTransform rectTransform) {
        Vector2 size = Vector2.Scale(rectTransform.rect.size, rectTransform.lossyScale);
        Rect rect = new Rect(rectTransform.position.x, rectTransform.position.y, size.x, size.y);
        rect.x -= rectTransform.sizeDelta.x * 0.5f;
        rect.y -= rectTransform.sizeDelta.y * 0.5f;

        return rect;

        }
    }

}
