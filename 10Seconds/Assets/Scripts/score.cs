//using UnityEngine;
//using TMPro;

//public class score : MonoBehaviour
//{
//    #region Singleton
//    public static score Instance { get; private set; }

//    private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }
//    #endregion

//    [Header("Count")]
//    public int count_demon = 0;
//    public int count_warlock = 0;
//    public int count_necro = 0;
//    public int count_slime = 0;
//    public int count_mask = 0;    
//    public int count_angel = 0;

//    public int count_bosses = 0;

//    public int level_knight = 0;
//    public int level_archer = 0;
//    public int level_wizard = 0;
//    [Space]

//    [Header("Reference")]
//    [SerializeField]
//    private TextMeshProUGUI demon;
//    [SerializeField]
//    private TextMeshProUGUI warlock;
//    [SerializeField]
//    private TextMeshProUGUI necro;
//    [SerializeField]
//    private TextMeshProUGUI slime;
//    [SerializeField]
//    private TextMeshProUGUI mask;
//    [SerializeField]
//    private TextMeshProUGUI angel;
//    [SerializeField]
//    private TextMeshProUGUI boss;
//    [SerializeField]
//    private TextMeshProUGUI knight;
//    [SerializeField]
//    private TextMeshProUGUI archer;
//    [SerializeField]
//    private TextMeshProUGUI wizard;
//    [SerializeField]
//    private TextMeshProUGUI _score;


//    private int cost_demon = 2;
//    private int cost_warlock = 5;
//    private int cost_necro = 8;
//    private int cost_slime = 2;
//    private int cost_mask = 10;
//    private int cost_angel = -5;

//    private int cost_boss = 50;    

//    public void UpdateGUI()
//    {
//        demon.text = " " + count_demon + " kills x " + cost_demon + "XP";
//        warlock.text = " " + count_warlock + " kills x " + cost_warlock + "XP";
//        necro.text = " " + count_necro + " kills x " + cost_necro + "XP";
//        slime.text = " " + count_slime + " kills x " + cost_slime + "XP";
//        mask.text = " " + count_mask + " kills x " + cost_mask + "XP";
//        angel.text = " " + count_angel + " kills x " + cost_angel + "XP";

//        boss.text = " " + count_bosses + " x " + cost_boss + "XP";

//        knight.text = " " + level_knight + " level";
//        archer.text = " " + level_archer + " level";
//        wizard.text = " " + level_wizard + " level";

//        _score.text = "Score: " + count_demon*cost_demon;
//    }
//}
