using System.Collections;
using UnityEngine;

public class playerSwap : MonoBehaviour
{

	[SerializeField]
	private GameObject[] classes;

	[SerializeField]
	private healthBar _healthBar;

	private playerAtributes _player;
	private int oldIndex;

	public void Start()
	{
		_player = GetComponent<playerAtributes>();
		oldIndex = Random.Range(0, classes.Length);
		StartCoroutine(Swap());		
	}

    private IEnumerator Swap()
	{
		while (true)
		{
			int index = Random.Range(0, classes.Length);
			if (index == oldIndex){
				StartCoroutine(Swap());
				yield break;
			}
			oldIndex = index;

			GameObject oldPlayer = GameObject.FindGameObjectWithTag("Player");
			GameObject newPlayer = Instantiate(classes[index], oldPlayer.transform.position, Quaternion.identity);

			playerAtributes.healthFactor = playerAtributes.currentHealt / playerAtributes.maxHealt;
			playerAtributes.maxHealt = newPlayer.GetComponent<player>().atributes[0].health;
			_player.UpdateHealth();	

			Destroy(oldPlayer);
			playerAtributes.currentPlayer = newPlayer;
			yield return null;			
			_healthBar.Change();
			yield return new WaitForSeconds(10f);
		}		
	}
}
