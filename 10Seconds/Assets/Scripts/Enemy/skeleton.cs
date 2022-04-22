using UnityEngine;

public class skeleton : MonoBehaviour, IDamagable
{
	[Header("Stats")]

	[SerializeField] private float speed = 4f;
	[SerializeField] private float minDistance = 1.5f;
	[SerializeField] private float damage;
	[SerializeField] private float health = 5f;
	[Space]

	[Header("Refernces")]
	[SerializeField] private Animator anim;
	[SerializeField] private GameObject death_prefab;

	private Transform target;
	private playerAtributes _player;

	private void Start()
	{
		_player = FindObjectOfType<playerAtributes>();
	}

	private void Update()
	{
		if (playerAtributes.playerAlive)
		{
			if (target != null)
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

				//animation
				if ((transform.position.x - target.position.x) < 0)
				{
					transform.localScale = new Vector3(1f, 1f, 1f);
				}
				else
				{
					transform.localScale = new Vector3(-1f, 1f, 1f);
				}
			}
			else
			{
				target = GameObject.FindGameObjectWithTag("Player").transform;
				return;
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
