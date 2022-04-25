using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void NextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
	}

	public void Credits()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
	}

	public void Mainmeu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
