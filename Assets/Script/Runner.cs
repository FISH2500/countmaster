using UnityEngine;

public class Runner : MonoBehaviour
{
    [Header("settings")]
    [SerializeField] private bool isTarget;

    public Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsTarget() 
    {
        return isTarget;
    }

    public void SetTaregt() 
    {
        isTarget = true;
        
        //player.state = Player.Player_State.Battle;
    }
}
