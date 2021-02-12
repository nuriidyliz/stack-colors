using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandaloneController : InputController
{
	void Update()
	{
		GetInput();
	}

	public override void GetInput()
	{

		if (Input.GetMouseButtonDown(0) && !GameManager.Instance.gameOver)
		{
			GameManager.Instance.StartRun();

			firstX = Input.mousePosition.x;
			hasInput = true;
		}

		if (Input.GetMouseButton(0))
		{
			currentX = Input.mousePosition.x;
		}

		if (Input.GetMouseButtonUp(0))
			hasInput = false;
		
	}

}
