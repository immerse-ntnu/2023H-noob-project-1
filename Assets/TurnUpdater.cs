using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnUpdater : MonoBehaviour
{
	private TextMeshProUGUI _text;

    void Start()
    {
	    _text = GetComponent<TextMeshProUGUI>();
        GameController.instance.UpdateTurn += OnUpdateTurn;
    }

    private void OnUpdateTurn(int turn)
    {
       _text.text = "P" + turn;
    }
}
