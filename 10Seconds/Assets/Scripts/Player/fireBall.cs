using UnityEngine;

public class fireBall : MonoBehaviour
{    
	[SerializeField] private float speed;
	[SerializeField] private float radius;
	private Vector2 target;
	private float weaponDamage;
	private bool _exploded = false;

	private void Start()
	{
		target = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
		weaponDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<player>().atributes[0].damage;
	}

	private void FixedUpdate()
	{
		if (Vector2.Distance(transform.position, target) > 0.1f)
		{
			transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);			
		}
		else
		{
			if (!_exploded)
			{
				Hit();
				Destroy(gameObject);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		int _entered = 0;
		Debug.Log(collision.name);
		if (collision.tag == "Enemy")
		{
			_entered++;
		}
	}

	private void Hit()
	{
		_exploded = true;

		Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

		foreach(Collider2D i in hits){
			IDamagable _damagable = i.GetComponent<IDamagable>();
			if (_damagable != null)
			{
				_damagable.Damage(weaponDamage);
			}
		}

	}
	
}
