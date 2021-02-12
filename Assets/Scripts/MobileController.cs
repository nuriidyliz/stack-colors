using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : InputController
{
	Touch touch;

	private void Update()
	{
		GetInput();
	}

	public override void GetInput()
	{
		if(Input.touchCount > 0 && !GameManager.Instance.gameOver)
		{
			GameManager.Instance.StartRun();

			hasInput = true;

			touch = Input.GetTouch(0);

			if(touch.phase == TouchPhase.Began)
			{
				firstX = touch.position.x;
			}

			currentX = touch.position.x;

		}
		else
			hasInput = false;

	}
}
