using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour {
    public TMP_Text timerText;
    private float startTime = 5;

    [SerializeField] private PointSystem pointSystem;

    void Start() {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown() {
        while (startTime >= 0) {
            string minutes = ((int)startTime / 60).ToString("00");
            string seconds = (startTime % 60).ToString("00");

            timerText.text = string.Format("{0}:{1}", minutes, seconds);

            yield return new WaitForSeconds(1f);

            startTime--;
        }
        Debug.Log("You ran out of time");
        pointSystem.AddPoints(6);
    }

}
