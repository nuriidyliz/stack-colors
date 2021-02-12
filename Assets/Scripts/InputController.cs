using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : MonoBehaviour
{
	public float currentX;
	public float previousX;
	public float firstX;
	public bool hasInput;

	public abstract void GetInput();
}
