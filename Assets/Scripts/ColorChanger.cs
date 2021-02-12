using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		GameManager.Instance.ChangeColor(gameObject.GetComponent<Renderer>().material);
	}
}
