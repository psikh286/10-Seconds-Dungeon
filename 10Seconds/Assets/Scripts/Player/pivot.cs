using UnityEngine;

public class pivot : MonoBehaviour
{
	[SerializeField]
	private Transform _player;

	private void LateUpdate()
	{		
		Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
		direction.Normalize();
		float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.localRotation = Quaternion.Euler(0f, 0f, rotation);

		if (_player.eulerAngles.y == 0f)
		{
			if (rotation < -90 || rotation > 90)
			{				
				transform.localRotation = Quaternion.Euler(180f, 0f, -rotation);
			}
			else
			{				
				transform.localRotation = Quaternion.Euler(0f, 0f, rotation);
			}
		}
		else if (_player.eulerAngles.y == 180f)
		{
			if (rotation < -90 || rotation > 90)
			{				
				transform.localRotation = Quaternion.Euler(180f, 180f, -rotation);
			}
			else
			{				
				transform.localRotation = Quaternion.Euler(0f, 180f, rotation);
			}			
		}
	}
}
