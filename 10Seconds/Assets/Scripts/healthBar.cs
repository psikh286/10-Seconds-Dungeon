using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;


	public void Start()
	{
		slider.value = gameManager.Instance.maxHealt;
	}
	public void Change()
	{
        slider.value = gameManager.Instance.currentHealt / gameManager.Instance.maxHealt;
	}
}
