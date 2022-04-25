using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class deathMenu : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _score;
	[SerializeField] private waveManager waves;

	private void OnEnable()
	{
		_score.text = "Waves: " + waves.waveCount;
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		playerAtributes.playerAlive = true;
	}

	public void Menu()
	{
		playerAtributes.playerAlive = true;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
