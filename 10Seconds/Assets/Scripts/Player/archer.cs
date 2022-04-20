using System.Collections;
using UnityEngine;

public class archer : MonoBehaviour
{
	[SerializeField] private Texture2D crossHair;
	[SerializeField] private GameObject prefab;
	[SerializeField] private Transform _pivot;

	private Vector2 cursourHotspot;

	private void Start()
	{
		cursourHotspot = new Vector2(crossHair.width / 2, crossHair.height / 2);
		Cursor.SetCursor(crossHair, cursourHotspot, CursorMode.ForceSoftware);
		StartCoroutine(Fire());
	}

	private IEnumerator Fire()
	{
		while (true)
		{
			Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
			direction.Normalize();

			GameObject arrow = Instantiate(prefab, _pivot.position, Quaternion.identity);
			arrow.GetComponent<Rigidbody2D>().velocity = direction * 7f;

			float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			arrow.transform.Rotate(0f, 0f, rotation);
			Destroy(arrow, 3f);

			yield return new WaitForSeconds(1f);
		}
	}

}
