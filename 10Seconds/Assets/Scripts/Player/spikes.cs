using UnityEngine;

public class spikes : MonoBehaviour
{
	[SerializeField] private Vector2 radius;	
	private float weaponDamage;

	private void Start()
	{
		weaponDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<player>().atributes[0].damage;
		Hit();
	}

	private void Hit()
	{
		Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, radius, 0f);

		foreach (Collider2D i in hits)
		{
			IDamagable _damagable = i.GetComponent<IDamagable>();
			if (_damagable != null)
			{
				_damagable.Damage(weaponDamage);
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireCube(transform.position, radius);
	}
}
