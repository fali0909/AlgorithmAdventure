using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Tilemaps.TilemapRenderer;

public class QuickSortAlgorithm : MonoBehaviour {

    //ranNum variables
    [Header("Random Numbers")]
    [SerializeField] private TMP_Text[] ranNum;

    //box variables
    [Header("Boxes")]
    [SerializeField] private Image[] boxes;

    //invisible variables
    [Header("Invisible boxes")]
    [SerializeField] private Image[] invisibleBoxes;

    private bool[] hasBeenLogged;

    private int filledBoxesCount;

    private List<int> numbersList;

    private bool isInOrder;
    private List<int> sortedOrder;

    private void Start() {
        hasBeenLogged = new bool[ranNum.Length];
        filledBoxesCount = 0;
        numbersList = new List<int>();
        isInOrder = true;
        sortedOrder = new List<int>();

    }

    private void Update() {
        for (int i = 0; i < ranNum.Length; i++) {
            if (Input.GetMouseButtonUp(0) && !hasBeenLogged[i]) {
                foreach (Image box in boxes) {
                    if (IsOverlapping(ranNum[i].rectTransform, box.rectTransform)) {
                        if (int.TryParse(ranNum[i].text, out int number)) {
                            Debug.Log("Integer Value: " + number);
                            hasBeenLogged[i] = true;
                            numbersList.Add(number);
                            sortedOrder.Add(i); 
                            filledBoxesCount++;

                            if (!IsInAscendingOrder(numbersList)) {
                                isInOrder = false;
                            }

                            if (filledBoxesCount == boxes.Length) {
                                if (!isInOrder) {
                                    Debug.Log("All boxes have been filled. The numbers are not in order.");

                                    for (int j = 0; j < sortedOrder.Count; j++) {
                                        int index = sortedOrder[j];
                                        ranNum[index].transform.position = invisibleBoxes[j].transform.position;
                                    }
                                    ResetState();
                                } else {
                                    Debug.Log("All boxes have been filled. Numbers are in order");
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private bool IsInAscendingOrder(List<int> list) {
        for (int i = 1; i < list.Count; i++) {
            if (list[i] < list[i - 1]) {
                return false;
            }
        }
            return true;
    }

    private void ResetState() {
    hasBeenLogged = new bool[ranNum.Length];
    filledBoxesCount = 0;
    numbersList.Clear();
    sortedOrder.Clear();
    isInOrder = true;

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

