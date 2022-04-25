using UnityEngine;

public class skeleton : MonoBehaviour, IDamagable
{
	[Header("Stats")]

	[SerializeField] private float speed = 4f;
	[SerializeField] private float minDistance = 2f;
	[SerializeField] private float damage;
	[SerializeField] private float health = 5f;
	[Space]

	[Header("Refernces")]
	[SerializeField] private Animator anim;
	[SerializeField] private GameObject death_prefab;
	[SerializeField] private waveManager waves;

	private Transform target;
	private playerAtributes _player;

	private void OnEnable()
	{
		_player = FindObjectOfType<playerAtributes>();
		waves = FindObjectOfType<waveManager>();
		health += 0.4f * waves.waveCount;
	}	

	private void Update()
	{
		if (target != null)
		{
			Move();
			Animate();
		}
		else
		{
			target = FindObjectOfType<player>().transform;
		}
	}

	private void Move()
	{
		if (playerAtributes.playerAlive)
		{
			if (Vector2.Distance(transform.position, target.position) > minDistance)
			{
				transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
				anim.SetBool("Run", true);
			}
			else
			{
				anim.SetBool("Run", false);
				_player.Damaged(damage);
				Destroy(gameObject);
			}
		}
	}
	private void Animate()
	{
		if (playerAtributes.playerAlive)
		{
			if ((transform.position.x - target.position.x) < 0)
			{
				transform.localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				transform.localScale = new Vector3(-1f, 1f, 1f);
			}
		}
	}

	private void Hit(float damageAmount)
	{
		health -= damageAmount;

		if (health <= 0)
		{
			Destroy(Instantiate(death_prefab, transform.position, Quaternion.identity), 1f);
			Destroy(gameObject);
		}
	}
	public void Damage(float damageAmount)
	{
		Hit(damageAmount);
	}
}
