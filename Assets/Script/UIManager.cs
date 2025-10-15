using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    public static UIManager Instance { get; private set; }

    public TextMeshProUGUI PlayerCount;
    public GameObject GameOverWindow;
    public GameObject GameClearWindow;
    public GameObject StartButton;
    public TextMeshProUGUI Score;

    [Header("êiíªÉQÅ[ÉW")]
    public Transform Goal;
    public Transform Player;
    public Image Gage;

    private GameObject RespawnObj;
    private int count;
    private float distance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        RespawnObj = GameObject.Find("Respawn");
        distance=Goal.position.z-Player.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        count = RespawnObj.transform.childCount;
        
        PlayerCount.text = ""+count;


        float perGage = (Player.position.z-29.3f) / distance;

        Debug.Log(perGage+"%");

        Gage.fillAmount = perGage;


    }

    public void SetGameOverWindow() 
    {
        GameOverWindow.SetActive(true);
    }

    public void UnSetStartButton() 
    {
        StartButton.SetActive(false);
    }
    public void SetGameClearWindow()
    {
        GameClearWindow.SetActive(true);
    }

    public void SetScore(int count)
    {
        Score.text = "Score:" + count;
    }

}
