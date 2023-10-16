using System;
using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private int _playerTurn = 1;
	private int _players = 2;
	public static GameController instance { get; private set; }
	public event Action<int> UpdateScore;
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

	public void OnUpdateScore(int score)
	{
		UpdateScore?.Invoke(score);
	}

	public void ChangeTurn()
	{
		_playerTurn += 1;
		if (_playerTurn > _players)
			_playerTurn = 1;
		UpdateTurn?.Invoke(_playerTurn);
	}
}
