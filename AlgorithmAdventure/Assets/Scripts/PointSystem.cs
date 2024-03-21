using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointSystem : MonoBehaviour {
    public TMP_Text points;

    public void AddPoints(int point) {
        points.text = "Points: " + point;
    }
}
