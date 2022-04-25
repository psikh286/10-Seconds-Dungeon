using UnityEngine.SceneManagement;
using UnityEngine;

public class restartScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			playerAtributes.playerAlive = true;			
		}
    }
}
