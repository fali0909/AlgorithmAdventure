using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuickSortAlgorithm : MonoBehaviour{

    [SerializeField] private TMP_Text ran1;
    [SerializeField] private TMP_Text ran2;
    [SerializeField] private TMP_Text ran3;
    [SerializeField] private TMP_Text ran4;
    [SerializeField] private TMP_Text ran5;
    [SerializeField] private TMP_Text ran6;
    [SerializeField] private TMP_Text ran7;
    [SerializeField] private TMP_Text ran8;

    private Vector3 mOffset;
    private float mZCoord;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }
}
