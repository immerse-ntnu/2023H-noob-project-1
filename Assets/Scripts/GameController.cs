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
        var balls = FindObjectsOfType<CubeScript>();
        foreach (var ball in balls)
	        if (ball.transform.position.y < -1)
		        Destroy(ball.gameObject);
        Active = true;
    }

	public void OnAddCurrentPlayerScore(int score)
	{
		_playerScores[_currentPlayerIndex] += score;
		UpdateCurrentPlayerScore?.Invoke(_playerScores[_currentPlayerIndex]);
	}

	private IEnumerator WaitForMovingBalls()
	{
		Active = false;
		var balls = GameObject.FindGameObjectsWithTag("Ball");
		Debug.Log($"Balls count: {balls.Length}");
		yield return new WaitForSeconds(0.3f);
		while (AreBallsMoving(balls))
			yield return new WaitForSeconds(0.1f);

		_currentPlayerIndex = (_currentPlayerIndex + 1) % _playerScores.Count;
		UpdateTurn?.Invoke(_currentPlayerIndex + 1);
		UpdateCurrentPlayerScore?.Invoke(_playerScores[_currentPlayerIndex]);
		Active = true;
	}

	private static bool AreBallsMoving(GameObject[] balls)
	{
		foreach (var ball in balls)
		{
			if (ball == null)
				continue;
			var mag = ball.GetComponent<Rigidbody>().velocity.magnitude;
			if (mag > 0.01f)
			{
				Debug.Log(ball.name + " is moving" + mag);
				return true;
			}
		}
		return false;
	}

	public void ChangeTurn()
	{
		StartCoroutine(WaitForMovingBalls());
	}
}
