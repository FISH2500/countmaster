using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public  enum Player_State{ Idle,Run,Battle}

    public CrowedSystem crowed;
    public float ForwardSpeed;
    public float BesideSpeed;
    public Transform Road;

    public Player_State state;

    //private Rigidbody rb;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        state = Player_State.Run;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Player_State_Management() 
    {
        switch (state)
        {
            case Player_State.Idle://スタート開始前

                break;
            case Player_State.Run://走っている
                Move();
                break;
            case Player_State.Battle://敵と対峙
                Debug.Log("戦闘中");
                break;
        }
    }

    void Move()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -Road.localScale.x/2+crowed.GetCrowed(), Road.localScale.x / 2 - crowed.GetCrowed());
        transform.position = position;
        //transform.position = new Vector3(0, transform.position.y, -ForwardSpeed);
        transform.Translate(new Vector3(0,0,-1)*ForwardSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.D)) 
        {
            

            transform.Translate(new Vector3(-1, 0, 0) * ForwardSpeed * Time.deltaTime, Space.World);

            

            

        } 

        else
        {
            if (Input.GetKey(KeyCode.A)) transform.Translate(new Vector3(1, 0, 0) * ForwardSpeed * Time.deltaTime, Space.World);
        }
        

    }





}
