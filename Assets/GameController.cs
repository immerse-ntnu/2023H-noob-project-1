using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static GameController instance { get; private set; }

	public event Action<int> UpdateScore;

	private void Awake()
	{
		instance = this;
	}

	public void OnUpdateScore(int score)
	{
		UpdateScore?.Invoke(score);
	}
}
