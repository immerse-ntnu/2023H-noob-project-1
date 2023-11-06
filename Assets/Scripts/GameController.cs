using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
	public static GameController instance { get; private set; }

	private int _currentPlayerIndex;
	private List<int> _playerScores = new() { 0, 0 };
	private Rigidbody[] _ballBodies;
	public event Action<int> UpdateCurrentPlayerScore;
	public event Action<int> UpdateTurn;
    public bool Active {get; private set;}

	private void Awake()
	{
		instance = this;
	}

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);
		var balls = GameObject.FindGameObjectsWithTag("Ball");
        _ballBodies = balls.Select(ball => ball.GetComponent<Rigidbody>()).ToArray();
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
		yield return new WaitForSeconds(0.3f);
		while (BallsAreMoving())
			yield return new WaitForSeconds(0.15f);

		_currentPlayerIndex = (_currentPlayerIndex + 1) % _playerScores.Count;
		UpdateTurn?.Invoke(_currentPlayerIndex + 1);
		UpdateCurrentPlayerScore?.Invoke(_playerScores[_currentPlayerIndex]);
		Active = true;
	}

	private bool BallsAreMoving()
	{
		foreach (var ball in _ballBodies)
		{
			if (ball == null || ball.velocity.magnitude < 0.01f)
				continue;
			return true;
		}
		return false;
	}

	public void ChangeTurn()
	{
		StartCoroutine(WaitForMovingBalls());
	}
}
