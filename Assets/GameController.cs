using System;
using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static GameController instance { get; private set; }
	public event Action<int> UpdateScore;
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
}
