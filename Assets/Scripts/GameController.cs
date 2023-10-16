using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
	public static GameController instance { get; private set; }

	private int _currentPlayerIndex = 0;
	private List<int> _playerScores = new() { 0, 0 };
	public event Action<int> UpdateCurrentPlayerScore;
	public event Action<int> UpdateTurn;
    public bool Active {get; private set;}

	private void Awake()
	{
		instance = this;
	}

    private IEnumerator Start()
    {
        // wait for 5 seconds
        yield return new WaitForSeconds(5f);
        Active = true;
    }

	public void OnAddCurrentPlayerScore(int score)
	{
		_playerScores[_currentPlayerIndex] += score;
		UpdateCurrentPlayerScore?.Invoke(_playerScores[_currentPlayerIndex]);
	}

	private IEnumerator WaitForMovingBalls()
	{
		var balls = GameObject.FindGameObjectsWithTag("Ball");
		foreach (var ball in balls)
		{
			if (ball.GetComponent<Rigidbody>().velocity.magnitude > 0.1f)
			{
				yield return new WaitForSeconds(0.1f);
			}
		}

		_currentPlayerIndex = (_currentPlayerIndex + 1) % _playerScores.Count;
		UpdateTurn?.Invoke(_currentPlayerIndex + 1);
		UpdateCurrentPlayerScore?.Invoke(_playerScores[_currentPlayerIndex]);
	}

	public void ChangeTurn()
	{
		StartCoroutine(WaitForMovingBalls());
	}
}
