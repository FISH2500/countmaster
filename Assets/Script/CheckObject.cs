using UnityEngine;

public class CheckObject : MonoBehaviour
{
    public static bool isHit;
    public static float NowTime;

    public static bool isPlayerHit;
    private Player playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerobj=GameObject.Find("Respawn");
        playerScript=playerobj.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Plus")
       {
            other.enabled = false;
           Debug.Log("Blue");
           isHit = true;
           Point p = other.GetComponent<Point>();

           ScoreManager.instance.SetPlayer(p.Count);
           Destroy(other.gameObject);

       }
       else if (other.tag == "Minus")
       {
            other.enabled = false;
            Debug.Log("Red");
            isHit = true;
            Point p = other.GetComponent<Point>();

            ScoreManager.instance.DestroyPlayer(p.Count);
            Destroy(other.gameObject);
       }
       else if (other.tag == "EnemyField") 
       {
            Debug.Log("Hit!"+other.gameObject.name);
            isPlayerHit = true;
            playerScript.state = Player.Player_State.Battle;
            Debug.Log("親オブジェクト"+other.transform.GetChild(0));
            playerScript.SetTargetObj(other.transform.GetChild(0));
       }
        else if (other.tag == "Multiply")
        {
            other.enabled = false;
            Debug.Log("Blue_Multiply");
            isHit = true;
            Point p = other.GetComponent<Point>();

            ScoreManager.instance.MultiplySetPlayer(p.Count);
            Destroy(other.gameObject);
        }
       else if (other.tag == "Goal") 
        {
            playerScript.ForwardSpeed=0;
            UIManager.Instance.SetGameClearWindow();
            UIManager.Instance.SetScore(gameObject.transform.parent.childCount);
        }

    }
    //private void OnTriggerExit(Collider other)
    //{

    //}

}
