using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{

	public Button retryButton;

	private void Start()
	{
		EventManager.Instance.GameOver += GameOver;
	}

	public void GameOver()
	{
		StartCoroutine(GameOverAfterSeconds(GameManager.Instance.retryPanelDelay));
	}

	public void Retry()
	{
		SceneManager.LoadScene("GameScene");
	}

	IEnumerator GameOverAfterSeconds(int seconds)
	{
		yield return new WaitForSeconds(seconds);
		retryButton.gameObject.SetActive(true);

	}
}
