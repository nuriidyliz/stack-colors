using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerCalculator : MonoBehaviour
{
	public float power = 1;
	public float decreasingValue = 0.1f;
	public float increasingValue = 5f;

	public bool clicked = false;
	public PlayerMovement playerMovement;
	public Text powerText;


	InputController InputController;

    void Start()
    {
		InputController = playerMovement.InputController;
    }

    void Update()
    {
		CountClick();
		SetPower();
		powerText.text = power.ToString();
    }

	void CountClick()
	{
		if (InputController.hasInput)
		{
			if (!clicked)
			{
				power += increasingValue;
				clicked = true;
			}
		}
		else
			clicked = false;
	}

	void SetPower()
	{
		power -= decreasingValue;

		if (power < 1)
			power = 1;
		else if (power > 100)
			power = 100;

	}
}
