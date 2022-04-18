using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
	public atributes[] atributes;
}

[System.Serializable]
public class atributes
{
	public string name;
	public Sprite healthBar;
	public float speed;
	public float health;
	public float damage;
}