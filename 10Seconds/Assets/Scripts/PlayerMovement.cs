using UnityEngine;

public class playerMovement : MonoBehaviour
{
	private float moveSpeed;	
	private Rigidbody2D rb;	
	private Animator anim;
	private Vector2 movement;

	private void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		moveSpeed = gameObject.GetComponent<player>().atributes[0].speed;
	}

	private void Update()
	{		
		movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		//animation
		if (movement != Vector2.zero)
		{
			anim.SetBool("Run", true);
		}
		else
		{
			anim.SetBool("Run", false);
		}
		if (movement.x != 0)
		{
			transform.localScale = new Vector3(movement.x, 1f, 1f);
		}		
	}

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
	}

}
