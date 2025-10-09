using UnityEngine;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{
    public enum Player_State{ Idle,Run,Battle}

    public CrowedSystem crowed;
    
    [Header("���s��Ԃ̐ݒ�")]
    public float ForwardSpeed;
    public float BesideSpeed;
    
    public Transform Road;

    [Header("�퓬���̐ݒ�")]
    public float BattleSpeed;
    [Header("��ԊǗ�")]
    public Player_State state;

    private Transform Target;
    //private Rigidbody rb;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        state = Player_State.Run;
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
            case Player_State.Idle://�X�^�[�g�J�n�O

                break;
            case Player_State.Run://�����Ă���
                Move();
                break;
            case Player_State.Battle://�G�ƑΛ�
                Debug.Log("�퓬��");
                BattleMove();
                break;
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
        Debug.Log("start");
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
    }





}
