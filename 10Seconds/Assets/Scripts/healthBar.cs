using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
	[SerializeField]
	private Image fill;
	[SerializeField]
	private Image border;


	public void Start()
	{
		Change();
	}
	public void Change()
	{
		RectTransform rt = GetComponent<RectTransform>();
		rt.sizeDelta = new Vector2(10f * playerAtributes.maxHealt, 75f);		

		border.sprite = GameObject.FindGameObjectWithTag("Player").GetComponent<player>().atributes[0].healthBar;	

		slider.value = playerAtributes.currentHealt / playerAtributes.maxHealt;
	}
}
