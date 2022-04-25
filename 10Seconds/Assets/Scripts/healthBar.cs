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

		border.sprite = playerAtributes.currentPlayer.GetComponent<player>().atributes[0].healthBar;
		fill.sprite = playerAtributes.currentPlayer.GetComponent<player>().atributes[0].abilityFill;
				
		slider.value = playerAtributes.currentHealt / playerAtributes.maxHealt;		
	}
}
