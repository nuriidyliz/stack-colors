using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
	public float horizontalSpeed = 6f;
	public float forwardSpeed = 8f;
	public float forwardWalkSpeed = 4f;

	public float minInputDistance = 10f;


	Rigidbody rb;

	public InputController InputController;

	private Vector3 lastMousePosition;


	private void Awake()
	{
		SetInputController();
	}

	void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
		if(!GameManager.Instance.gameOver)
			TryMove();
	}

	void TryMove()
	{
		Vector3 movement = transform.forward * forwardSpeed;

		if (InputController.hasInput)
		{
			if (MinDistanceCheck())
			{
				if (InputController.currentX < InputController.previousX)
				{
					movement = movement - transform.right * horizontalSpeed;
				}
				if (InputController.currentX > InputController.previousX)
				{
					movement = movement + transform.right * horizontalSpeed;
				}
			}

			InputController.previousX = InputController.currentX;

		}

		rb.MovePosition(transform.position + movement * Time.fixedDeltaTime);

	}



	bool MinDistanceCheck() {
		bool result = minInputDistance < Mathf.Abs(InputController.currentX - InputController.previousX) ? true : false;

		return result;
	}

	#region Setting Up
	void SetInputController()
	{
#if UNITY_EDITOR || UNITY_STANDALONE
		InputController = GetComponent<StandaloneController>();
		InputController.enabled = true;
#elif UNITY_ANDROID && !UNITY_EDITOR
		InputController = GetComponent<MobileController>();
		InputController.enabled = true;
#endif
	}
	#endregion
}
