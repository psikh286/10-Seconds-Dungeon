using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class wizard : MonoBehaviour
{
	[SerializeField] private Texture2D crossHair;
	[SerializeField] private GameObject prefab;	

	[SerializeField] private float coolDown = 1.5f;

	private Vector2 cursourHotspot;
	private bool can_fire = true;
	private Slider slider;	

	private void Start()
	{
		cursourHotspot = new Vector2(crossHair.width / 2, crossHair.height / 2);
		Cursor.SetCursor(crossHair, cursourHotspot, CursorMode.ForceSoftware);	
		
		
		if (slider == null)
			return;
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
		slider = GameObject.FindGameObjectWithTag("Finish").GetComponent<Slider>();
		can_fire = false;

		Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		slider.value = 0;
		var _fillUI = StartCoroutine(FillAbility());

		GameObject spell = Instantiate(prefab, direction, Quaternion.identity);
		Destroy(spell, 0.6f);
		yield return new WaitForSeconds(coolDown);

		StopCoroutine(_fillUI);
		can_fire = true;
	}

	private IEnumerator FillAbility()
	{
		while (true)
		{
			slider.value += Time.deltaTime;
			yield return null;
		}
	}

}
