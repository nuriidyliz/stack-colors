using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StreakCalculator : MonoBehaviour
{

	public int requiredStreak=15;
	public int streakNumber=0;
	public Text streakText;

	public Lifter lifter;
	public GameObject pickupsPool;
	public GameObject changerPool;
	public GameObject obstaclePool;

	public void IncrementStreak()
	{
		streakNumber++;

		streakText.text = streakNumber + "/" + requiredStreak;

		if (streakNumber >= requiredStreak)
		{
			streakText.text = "STREAK!";

			ChangeAllPickupsColor();
			DisableChangers();
			DestroyObstacles();
			StartCoroutine(lifter.ExpandLifter());
			streakNumber = 0;
		}

	}

	public void BreakStreak()
	{
		streakNumber = 0;
		streakText.text = streakNumber + "/" + requiredStreak;
	}

	public void ChangeAllPickupsColor()
	{
		Material lifterMaterial = lifter.GetComponent<Renderer>().material;

		pickupsPool.GetComponentsInChildren<Renderer>().ToList()
			.ForEach(item => item.material = lifterMaterial);
	}

	public void DisableChangers()
	{

		changerPool.GetComponentsInChildren<Transform>().ToList()
			.ForEach(item => item.gameObject.SetActive(false));
	}

	public void DestroyObstacles()
	{
		obstaclePool.GetComponentsInChildren<Transform>().ToList()
			.ForEach(item => Destroy(item.gameObject));
	}

}
