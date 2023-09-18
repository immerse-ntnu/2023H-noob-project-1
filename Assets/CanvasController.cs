using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreField;

    private void Start()
    {
        GameController.instance.UpdateScore += UpdateScore;
    }

    private void UpdateScore(int score)
    {
        scoreField.text = score.ToString();
    }


}
