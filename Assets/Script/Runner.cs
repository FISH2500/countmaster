using UnityEngine;

public class Runner : MonoBehaviour
{
    [Header("settings")]
    [SerializeField] private bool isTarget;

    public Player player;

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject respawn=GameObject.Find("Respawn");

        if(respawn != null ) 
        {
            player=respawn.GetComponent<Player>();
        }

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StateManager();
    }

    void StateManager() 
    {
        switch (player.state)
        {
            case Player.Player_State.Idle:
                animator.SetBool("Run", false);
                break;

            case Player.Player_State.Run:
                animator.SetBool("Run", true);
                break;
        }
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

    public void UnSetTaregt()
    {
        isTarget = false;

        //player.state = Player.Player_State.Battle;
    }
}
