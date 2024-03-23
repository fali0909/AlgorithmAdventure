using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuickSortAlgorithm : MonoBehaviour {

    //guidance variable
    [Header("Guidance")]
    [SerializeField] private TMP_Text guidance;

    //ranNum variables
    [Header("Random Numbers")]
    [SerializeField] private TMP_Text[] ranNum;

    //box variables
    [Header("Boxes")]
    [SerializeField] private Image[] boxes;

    private bool[] hasBeenLogged;

    private int filledBoxesCount;

    private int[] numbersList;



    private void Start() {
        hasBeenLogged = new bool[ranNum.Length];
        filledBoxesCount = 0;
        numbersList = new int[boxes.Length];
    }

    private void Update() {
        for (int i = 0; i < ranNum.Length; i++) {
            if (Input.GetMouseButtonUp(0) && !hasBeenLogged[i]) {
                for (int j = 0; j < boxes.Length; j++) {
                    Image box = boxes[j];
                    if (IsOverlapping(ranNum[i].rectTransform, box.rectTransform)) {
                        if (int.TryParse(ranNum[i].text, out int number)) {
                            Debug.Log("Integer Value: " + number);
                            hasBeenLogged[i] = true;
                            numbersList[j] = number; 
                            filledBoxesCount++;

                            if (filledBoxesCount == boxes.Length) {
                                if (IsInOrder(numbersList)) {
                                    guidance.text = "Numbers are in order! Well done!";
                                }
                                else {
                                    guidance.text = "The numbers are not in order";
                                    ResetState();
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private bool IsInOrder(int[] array) {
        for (int i = 1; i < array.Length; i++) {
            if (array[i] < array[i - 1]) {
                return false;
            }
        }
        return true;
    }
    private void ResetState() {
        float yOffset = 100f; 

        for (int i = 0; i < ranNum.Length; i++) {
            Vector3 newPosition = ranNum[i].transform.position;
            newPosition.y += yOffset;
            ranNum[i].transform.position = newPosition;
        }

        hasBeenLogged = new bool[ranNum.Length];
        filledBoxesCount = 0;
        numbersList = new int[boxes.Length];
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

