using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreField;

    // Update is called once per frame
    void Update()
    {
        scoreField.text = PlayerController.instance.score.ToString();
    }
}
