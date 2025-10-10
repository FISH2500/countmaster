using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI PlayerCount;
    private GameObject RespawnObj;
    private int count;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    
}
