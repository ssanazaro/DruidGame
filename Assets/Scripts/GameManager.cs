using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public void WinGame()
	{
		//FindObjectOfType<EndOfGame>().Victory();
		StartCoroutine(RestartLevel());
	}

	public void LoseGame()
	{
		//FindObjectOfType<EndOfGame>().Defeat();
		StartCoroutine(RestartLevel());
	}

	IEnumerator RestartLevel()
	{
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
