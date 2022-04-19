using UnityEngine;

public class archer : MonoBehaviour
{
	[SerializeField] private Texture2D crossHair;

	private Vector2 cursourHotspot;

	private void Start()
	{
		cursourHotspot = new Vector2(crossHair.width / 2, crossHair.height / 2);
		Cursor.SetCursor(crossHair, cursourHotspot, CursorMode.ForceSoftware);
	}

}
