using UnityEngine;

public class weapon : MonoBehaviour
{
	private float weaponDamage;

	private void Start()
	{
		weaponDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<player>().atributes[0].damage;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		IDamagable _damagable = collision.GetComponent<IDamagable>();
		if (_damagable != null)
		{
			_damagable.Damage(weaponDamage);
		}
	}
}
