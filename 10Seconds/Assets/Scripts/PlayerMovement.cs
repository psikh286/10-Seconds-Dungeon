using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
		if (movement.x != 0)
		{
			transform.localScale = new Vector3(movement.x, 1, 1);
			anim.SetBool("Run", true);
		}else
		{
			anim.SetBool("Run", false);
		}
	}

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
	}

}
