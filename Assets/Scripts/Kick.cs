using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
	Rigidbody rb;

	public PowerCalculator powerCalculator;
	public float kickCoefficient = 3;

    void Start()
    {
		rb = GetComponent<Rigidbody>();

		EventManager.Instance.Kicked += ThrowKick;
    }

	public void ThrowKick()
	{
		rb.isKinematic = false;

		rb.AddForce(transform.right * powerCalculator.power * kickCoefficient, ForceMode.Impulse);
	}
}
