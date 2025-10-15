using UnityEngine;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{
    public enum Player_State{ Idle,Run,Battle,GameOver}

    public CrowedSystem crowed;
    
    [Header("走行状態の設定")]
    public float ForwardSpeed;
    public float BesideSpeed;
    
    public Transform Road;

    [Header("戦闘中の設定")]
    public float BattleSpeed;
    [Header("状態管理")]
    public Player_State state;

    private Transform Target;

    private Animator animator;
    //private Rigidbody rb;

    void Start()
    {

        state = Player_State.Idle;
        animator= GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        Player_State_Management();
    }
    private void Player_State_Management() 
    {
        switch (state)
        {
            case Player_State.Idle://スタート開始前
                animator.SetBool("Run", false);
                break;
            case Player_State.Run://走っている
                Move();
                animator.SetBool("Run", true);
                break;
            case Player_State.Battle://敵と対峙
                BattleMove();
                break;
        }

        

        if (gameObject.transform.childCount <= 0) 
        {
            state = Player_State.GameOver;
            UIManager.Instance.SetGameOverWindow();
        }

    }

    void Move()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -Road.localScale.x/2+crowed.GetCrowed(), Road.localScale.x / 2 - crowed.GetCrowed());
        transform.position = position;
        //transform.position = new Vector3(0, transform.position.y, -ForwardSpeed);
        transform.Translate(new Vector3(0,0,1)*ForwardSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.D)) 
        {
            transform.Translate(new Vector3(1, 0, 0) * ForwardSpeed * Time.deltaTime, Space.World);
        } 

        else
        {
            if (Input.GetKey(KeyCode.A)) transform.Translate(new Vector3(-1, 0, 0) * ForwardSpeed * Time.deltaTime, Space.World);
        }
        
    }
    public void BattleMove() 
    {
        transform.position=Vector3.MoveTowards(transform.position, Target.position, BattleSpeed * Time.deltaTime);

        transform.LookAt(Target.position);

    }
    public void SetTargetObj(Transform Istarget) 
    {
        Target = Istarget;
    }
    
    public void ResetRotation() 
    {
        transform.eulerAngles = Vector3.zero;
        Vector3 pos = transform.position;
        pos.y = 0.48f;
        transform.position = pos;
    }

    public void StartButton() 
    {
        UIManager.Instance.UnSetStartButton();
        state = Player_State.Run;
    }





}
