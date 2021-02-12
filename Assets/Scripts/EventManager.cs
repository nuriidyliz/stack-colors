using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	#region Singleton
	public static EventManager Instance;

	private void Awake()
	{
		Instance = this;
	}
	#endregion

	public event Action Kicked;
	public event Action Walk;
	public event Action GameOver;

	public void KickedAction()
	{
		Kicked?.Invoke();
	}

	public void WalkAction()
	{
		Walk?.Invoke();
	}

	public void GameOverAction()
	{
		GameOver?.Invoke();
	}

}
