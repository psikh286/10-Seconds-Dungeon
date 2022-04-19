using UnityEngine;

public class playerAtributes : MonoBehaviour
{
	[Header("Stats")]	
	public static float currentHealt;
	public static float maxHealt = 40f;
	public static bool playerAlive = true;
	public static float healthFactor;
	[Space]

	[Header("References")]
	[SerializeField]
	private GameObject healthBar;
	[SerializeField]
	private GameObject deathMenu;
	[SerializeField]
	private GameObject fx;

	private void Start()
	{
		currentHealt = maxHealt;
	}

	public void UpdateHealth()
	{
		currentHealt = healthFactor * maxHealt;
	}

	public void Damaged(float damage)
	{
		currentHealt -= damage;
		healthBar.GetComponent<healthBar>().Change();
		if (currentHealt <= 0)
		{
			deathMenu.SetActive(true);
			var pl = GameObject.FindGameObjectWithTag("Player");
			Destroy(Instantiate(fx, pl.transform.position, Quaternion.identity), 1f);
			Destroy(pl);			
			playerAlive = false;
		}
	}
}
