using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followEnemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;    
    [SerializeField]
    private float minDistance = 1f;
	[SerializeField]
	private int health = 10;

	[SerializeField]
	private Transform target;
	[SerializeField]
	private Animator anim;
	[SerializeField]
	private GameObject death_prefab;

	private void Update()
	{
		if (Vector2.Distance(transform.position, target.position) > minDistance)
		{
			transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
			anim.SetBool("Run", true);
		}
		else
		{
			anim.SetBool("Run", false);
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

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Finish")
		{
			health -= 5;
			if (health <= 0)
			{ 
				GameObject fx = Instantiate(death_prefab, transform.position, Quaternion.identity);
				Destroy(fx, 1f);
				Destroy(gameObject);
			}
		}
	}	
}
