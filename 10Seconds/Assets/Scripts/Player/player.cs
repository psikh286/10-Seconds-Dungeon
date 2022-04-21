using UnityEngine;

public class player : MonoBehaviour
{
	public atributes[] atributes;
}

[System.Serializable]
public class atributes
{
	public string name;
	public float speed;
	public float health;
	public float damage;

	public Sprite healthBar;
	public Sprite abilityFill;
}