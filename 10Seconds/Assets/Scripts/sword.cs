using UnityEngine;

public class sword : MonoBehaviour
{
	[SerializeField]
	private Transform player;

	private void Update()
	{
		Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
		float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.eulerAngles = new Vector3(0f, 0f, rotation);

		if (player.localScale.x == 1)
		{
			if (rotation < -90 || rotation > 90)
			{
				transform.localScale = new Vector3(1f, -1f, 1f);
			}else
			{
				transform.localScale = new Vector3(1f, 1f, 1f);
			}			
		}
		else if (player.localScale.x == -1)
		{
			if (rotation < -90 || rotation > 90)
			{
				transform.localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				transform.localScale = new Vector3(-1f, -1f, 1f);
			}
		}

		
	}
}
