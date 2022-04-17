using UnityEngine;
using UnityEngine.SceneManagement;

public class deathMenu : MonoBehaviour
{


	private void Score()
	{

	}

    public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Menu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
