using System.Collections;
using UnityEngine;

public class necromant : MonoBehaviour, IDamagable
{
	[Header("Stats")]

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

	private Transform target;
	private bool can_move = true;

	private void Start()
	{
		StartCoroutine(Spawn());
	}

	private void Update()
	{
		if (playerAtributes.playerAlive)
		{
			if (target != null)
			{
				if (can_move)
				{
					if (Vector2.Distance(transform.position, target.position) < minDistance)
					{
						transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
						anim.SetBool("Run", true);
					}
					else { anim.SetBool("Run", false); }

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
			}
			else
			{
				target = GameObject.FindGameObjectWithTag("Player").transform;
			}
		}
	}

	private IEnumerator Spawn()
	{
		while (true)
		{
			yield return new WaitForSeconds(coolDown);

			can_move = false;
			Vector2 _offset = new Vector2(transform.position.x, transform.position.y);
			anim.SetBool("Run", false);

			for (int i = 0; i < 3; i++)
			{				
				Instantiate(prefab, _offset + Random.insideUnitCircle, Quaternion.identity);
				yield return new WaitForSeconds(delay);
			}
			can_move = true;
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
