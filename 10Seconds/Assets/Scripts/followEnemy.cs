using UnityEngine;
using System.Collections;

public class followEnemy : MonoBehaviour
{
	[Header("Stats")]

    [SerializeField]
    private float speed = 5f;    
    [SerializeField]
    private float minDistance = 1f;
	[SerializeField]
	private float coolDown = 1f;
	[SerializeField]
	private float damage = 40f;
	[SerializeField]
	private float health = 10f;
	[Space]

	[Header("Refernces")]
	[SerializeField]
	private Transform target;
	[SerializeField]
	private Animator anim;
	[SerializeField]
	private GameObject death_prefab;

	private bool can_damage = true;

	private void Update()
	{
		if (gameManager.Instance.playerAlive)
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

	private IEnumerator DealDamage()
	{
		can_damage = false;
		gameManager.Instance.Damaged(damage);
		yield return new WaitForSeconds(coolDown);		
		can_damage = true;		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Finish")
		{
			health -= 5f;
			if (health <= 0)
			{ 				
				Destroy(Instantiate(death_prefab, transform.position, Quaternion.identity), 1f);
				Destroy(gameObject);
			}
		}
	}	
}
