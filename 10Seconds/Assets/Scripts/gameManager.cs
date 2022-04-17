using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
	#region Singleton
	public static gameManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	#endregion

	[Header("Stats")]
	public float currentHealt;
	public float maxHealt;
	public bool playerAlive = true;
	public bool gameIsPaused = false;
	[Space]

	[Header("References")]
	[SerializeField]
	private GameObject healthBar;
	[SerializeField]
	private GameObject fx;

	public void Damaged(float damage)
	{
		currentHealt -= damage;
		healthBar.GetComponent<healthBar>().Change();
		if (currentHealt <= 0)
		{
			var pl = GameObject.FindGameObjectWithTag("Player");
			Destroy(Instantiate(fx, pl.transform.position, Quaternion.identity), 1f);
			Destroy(pl);			
			playerAlive = false;
		}
	}
}
