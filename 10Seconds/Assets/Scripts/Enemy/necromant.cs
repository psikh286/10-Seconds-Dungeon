using System.Collections;
using UnityEngine;

public class necromant : MonoBehaviour, IDamagable
{
	[Header("Stats")]

	public int skeletonAmount = 2;

	[SerializeField] private float health = 10f;
	[SerializeField] private float speed = 3f;
	[SerializeField] private float minDistance = 3f;
	[SerializeField] private float coolDown = 4f;
	[SerializeField] private float delay = 0.2f;	
	[Space]

	[Header("Refernces")]
	[SerializeField] private Animator anim;
	[SerializeField] private GameObject death_prefab;
	[SerializeField] private GameObject prefab;
	[SerializeField] private waveManager waves;

	private Transform target;
	private bool can_move = true;

	private void Start()
	{
		StartCoroutine(Spawn());
		waves = FindObjectOfType<waveManager>();
		target = GameObject.FindGameObjectWithTag("Player").transform;
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
			if (can_move)
			{
				if (Vector2.Distance(transform.position, target.position) < minDistance)
				{
					transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
					anim.SetBool("Run", true);
				}
				else { anim.SetBool("Run", false); }
			}
		}
	}
	private void Animate()
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


	private IEnumerator Spawn()
	{
		while (true)
		{
			if (playerAtributes.playerAlive)
			{
				yield return new WaitForSeconds(coolDown);

				can_move = false;
				Vector2 _offset = new Vector2(transform.position.x, transform.position.y);
				anim.SetBool("Run", false);

				for (int i = 0; i < skeletonAmount; i++)
				{
					Instantiate(prefab, _offset + Random.insideUnitCircle, Quaternion.identity);
					yield return new WaitForSeconds(delay);
				}
				can_move = true;
			}
			yield return null;
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
