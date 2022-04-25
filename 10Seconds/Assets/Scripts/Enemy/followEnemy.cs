using UnityEngine;
using System.Collections;

public class followEnemy : MonoBehaviour, IDamagable
{
	[Header("Stats")]

    [SerializeField] private float speed = 5f;    
    [SerializeField] private float minDistance = 1f;
	[SerializeField] private float coolDown = 1f;
	[SerializeField] private float damage;
	[SerializeField] private float health = 10f;
	[Space]

	[Header("Refernces")]	
	[SerializeField] private Animator anim;
	[SerializeField] private GameObject death_prefab;	
	[SerializeField] private bool can_damage = true;
	[SerializeField] private waveManager waves;

	private Transform target;
	private playerAtributes _player;

	private void Start()
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
				if (can_damage)
				{
					StartCoroutine(DealDamage());
				}
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

	private IEnumerator DealDamage()
	{
		can_damage = false;
		_player.Damaged(damage);	
		yield return new WaitForSeconds(coolDown);		
		can_damage = true;		
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
