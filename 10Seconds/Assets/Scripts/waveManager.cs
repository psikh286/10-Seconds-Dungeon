using System.Collections;
using UnityEngine;

public class waveManager : MonoBehaviour
{
	public enemies[] packs;

	[SerializeField] private BoxCollider2D gridArea;

	private void Start()
	{
		StartCoroutine(Spawn());
	}



	private IEnumerator Spawn()
	{
		int wavecount = 0;
		while (true)
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
			wavecount++;
			Debug.Log(wavecount);
			
			yield return new WaitForSeconds(10f);
		}		
	}
}

[System.Serializable]
public class enemies
{
	public GameObject[] pack;
}