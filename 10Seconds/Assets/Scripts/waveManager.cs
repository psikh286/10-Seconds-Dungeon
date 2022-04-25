using System.Collections;
using UnityEngine;

public class waveManager : MonoBehaviour
{
	public enemies[] packs;
	public int waveCount = 0;

	[SerializeField] private BoxCollider2D gridArea;

	private void Start()
	{
		StartCoroutine(Spawn());
	}



	private IEnumerator Spawn()
	{
		while (true)
		{
			if (playerAtributes.playerAlive)
			{
				GameObject[] _pack = packs[Random.Range(0, packs.Length)].pack;

				foreach (GameObject i in _pack)
				{
					Bounds bounds = gridArea.bounds;

					float x = Random.Range(bounds.min.x, bounds.max.x);
					float y = Random.Range(bounds.min.y, bounds.max.y);
					Vector2 spawnPosition = new Vector2(x, y);

					Instantiate(i, spawnPosition, Quaternion.identity);
				}
				waveCount++;

				yield return new WaitForSeconds(10f);
			}
			yield return null;
		}		
	}
}

[System.Serializable]
public class enemies
{
	public GameObject[] pack;
}