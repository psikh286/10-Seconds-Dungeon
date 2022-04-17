using UnityEngine;

public class playerMovement : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed = 5f;

	[SerializeField]
	private Rigidbody2D rb;
	[SerializeField]
	private Animator anim;
	private Vector2 movement;

	private void Update()
	{
		movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		if (movement != Vector2.zero)
		{
			anim.SetBool("Run", true);
		}else
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
