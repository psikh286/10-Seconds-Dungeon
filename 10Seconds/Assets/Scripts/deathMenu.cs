using UnityEngine;
using UnityEngine.SceneManagement;

public class deathMenu : MonoBehaviour
{
	private void OnEnable()
	{
		//score.Instance.UpdateGUI();
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		playerAtributes.playerAlive = true;
	}

	public void Menu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
