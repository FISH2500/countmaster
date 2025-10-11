using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance { get; private set; }

    public TextMeshProUGUI PlayerCount;
    public GameObject GameOverWindow;
    public GameObject StartButton;
    private GameObject RespawnObj;
    private int count;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        RespawnObj = GameObject.Find("Respawn");

    }

    // Update is called once per frame
    void Update()
    {
        count = RespawnObj.transform.childCount;
        
        PlayerCount.text = ""+count;
    }

    public void SetGameOverWindow() 
    {
        GameOverWindow.SetActive(true);
    }

    public void UnSetStartButton() 
    {
        StartButton.SetActive(false);
    }

    
}
