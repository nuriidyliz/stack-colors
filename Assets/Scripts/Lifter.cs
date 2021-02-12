using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Lifter : MonoBehaviour
{
	public StreakCalculator streakCalculator;

	public List<GameObject> pickupList;

	public float distanceOffset = 0.1f;
	public Vector3 basePosition = new Vector3(0f, 0.8f, 0.6f);
	public string colorName;
	public bool end = false;

	void Start()
	{
		pickupList = new List<GameObject>();
		colorName = gameObject.GetComponent<Renderer>().material.name;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals("Pickup") && !end)
		{
			if (other.GetComponent<Renderer>().material.name.Contains(colorName))
			{
				Pick(other.gameObject);
			}
			else
				Drop(other.gameObject);
		}
		else if (other.tag.Equals("Obstacle"))
		{
			GameManager.Instance.CollideWithObstacle();
		}
		else if (other.tag.Equals("WalkArea"))
		{
			EventManager.Instance.WalkAction();
		}
		else if (other.tag.Equals("KickPoint"))
		{
			EventManager.Instance.KickedAction();
		}

	}

	void Pick(GameObject pickup)
	{
		pickup.transform.parent = gameObject.transform;
		pickup.transform.localPosition = basePosition + new Vector3(0f, pickup.transform.localScale.y/2f, 0);

		Vector3 heightToAdd = new Vector3(0f, pickup.transform.localScale.y + distanceOffset, 0f);
		SetPickupsPosition(heightToAdd);

		pickupList.Add(pickup);
		streakCalculator.IncrementStreak();

	}

	void Drop(GameObject incompatiblePickup)
	{

		if (pickupList.Count != 0)
		{
			Destroy(incompatiblePickup);

			GameObject objectToDestroy = pickupList.Last<GameObject>();

			Vector3 heightToSubtract = new Vector3(0f, objectToDestroy.transform.localScale.y * -1f, 0f);
			SetPickupsPosition(heightToSubtract);

			pickupList.Remove(objectToDestroy);
			Destroy(objectToDestroy);
		}
		else
			EventManager.Instance.GameOverAction();
	}

	void SetPickupsPosition(Vector3 pos)
	{
		pickupList?.ForEach(item => item.transform.localPosition += pos);
	}

	public void ChangePickupsColor(Material material)
	{
		colorName = material.name;
		gameObject.GetComponent<Renderer>().material = material;
		pickupList?.ForEach(item => item.GetComponent<Renderer>().material = material);
	}

	public IEnumerator ExpandLifter()
	{
		pickupList?.ForEach(item => item.transform.parent = null);
		transform.localScale = new Vector3(8, transform.localScale.y, transform.localScale.z);
		pickupList?.ForEach(item => item.transform.SetParent(transform));

		yield return new WaitForSeconds(3);
		NormalizeLifter();
	}

	public void NormalizeLifter()
	{
		pickupList?.ForEach(item => item.transform.parent = null);
		transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
		pickupList?.ForEach(item => item.transform.SetParent(transform));

	}
}
