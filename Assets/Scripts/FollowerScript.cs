using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour
{
	public Transform player;

	Vector3 offset;
	public Vector3 normalOffset;
	public Vector3 zoomOffset;
	public float smoothSpeed = 5f;

	bool zoomed = false;

	private void Start()
	{
		EventManager.Instance.Walk += ZoomIn;
		EventManager.Instance.Kicked += ZoomOut;
	}

	private void FixedUpdate()
	{
		offset = zoomed ? zoomOffset : normalOffset;

		Vector3 nextPosition = player.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, nextPosition, Time.fixedDeltaTime * smoothSpeed);
		transform.position = smoothedPosition;
	}

	public void ZoomIn()
	{
		zoomed = true;
	}

	public void ZoomOut()
	{
		zoomed = false;
	}
}
