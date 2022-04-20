using System.Collections;
using UnityEngine;

public class wizard : MonoBehaviour
{
	[SerializeField] private Texture2D crossHair;
	[SerializeField] private GameObject prefab;

	[SerializeField] private float delay = 0.5f;
	[SerializeField] private float coolDown = 1.5f;

	private Vector2 cursourHotspot;
	private bool can_fire = true;

	private void Start()
	{
		cursourHotspot = new Vector2(crossHair.width / 2, crossHair.height / 2);
		Cursor.SetCursor(crossHair, cursourHotspot, CursorMode.ForceSoftware);		
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0) && can_fire)
		{
			StartCoroutine(Fire());
		}
	}

	private IEnumerator Fire()
	{
		can_fire = false;
		Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		yield return new WaitForSeconds(delay);
		GameObject spell = Instantiate(prefab, direction, Quaternion.identity);
		Destroy(spell, 0.6f);
		yield return new WaitForSeconds(coolDown);
		can_fire = true;
	}

}
