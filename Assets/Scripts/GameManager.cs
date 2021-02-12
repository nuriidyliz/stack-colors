using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	public GameObject Player;
	public GameObject walkArea;
	public Animator PlayerAnimator;

	public float pickupMass = 0.5f;
	public int retryPanelDelay = 2;

	public bool gameOver = false;
	Lifter lifter;


	private void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		lifter = Player.transform.Find("Lifter").GetComponent<Lifter>();

		EventManager.Instance.Walk += StartWalk;
		EventManager.Instance.Kicked += KickPickups;
		EventManager.Instance.GameOver += GameOver;
	}

	public void StartRun()
	{
		PlayerAnimator.SetBool("isRunning", true);
		Player.GetComponent<PlayerMovement>().enabled = true;
	}

	public void StartWalk()
	{
		PlayerAnimator.SetBool("isWalking", true);
		Player.GetComponent<PlayerMovement>().forwardSpeed = Player.GetComponent<PlayerMovement>().forwardWalkSpeed;
		Player.GetComponent<PlayerMovement>().horizontalSpeed = 0;

		walkArea.GetComponent<PowerCalculator>().enabled = true;
	}

	public void StopRun()
	{
		PlayerAnimator.SetBool("isRunning", false);
		Player.GetComponent<PlayerMovement>().enabled = false;
	}

	public void ChangeColor(Material material)
	{
		Player.transform.Find("PlayerMesh").GetComponent<Renderer>().material = material;
		lifter.ChangePickupsColor(material);
	}

	public void CollideWithObstacle()
	{
		StopRun();
		AddRigidbodyToPickups();
		EventManager.Instance.GameOverAction();
	}

	public void KickPickups()
	{
		PlayerAnimator.SetTrigger("isKicking");
		StopRun();
		AddRigidbodyToPickups();
		EventManager.Instance.GameOverAction();
	}

	public void AddRigidbodyToPickups()
	{
		lifter.end = true;
		lifter.GetComponent<Collider>().enabled = false;


		foreach (GameObject item in lifter.pickupList)
		{
			Rigidbody rb = item.AddComponent<Rigidbody>();

			item.GetComponent<Collider>().isTrigger = false;
			rb.mass = pickupMass;
			rb.useGravity = true;
			item.transform.parent = null;

		}
	}

	public void GameOver()
	{
		StopRun();
		gameOver = true;
	}
}