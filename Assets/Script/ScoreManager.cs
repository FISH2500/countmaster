using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }

    public GameObject Player;

    private GameObject respawn_obj;
    
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        respawn_obj = GameObject.Find("Respawn");
    }

    public void SetPlayer(int count) 
    {
        for(int i = 0; i < count; i++) 
        {
            float x = i;

            GameObject player =Instantiate(Player, Vector3.zero, Quaternion.identity, respawn_obj.transform);
            
            player.transform.localPosition = Vector3.right * x;

            

        }
    }

    public void DestroyPlayer(int count)
    {
        int childcount = respawn_obj.transform.childCount-1;

        for (int i = childcount; i > childcount-count; i--)
        {
            Debug.Log(i);


            Transform destroyobj = respawn_obj.transform.GetChild(i);
            
            Destroy(destroyobj.gameObject);
            if (i <= 0)
            {
                GameOver();
                break;
            }

        }
    }
    public void MultiplySetPlayer(int count)
    {
        int childcount = respawn_obj.transform.childCount;

        for (int i = 0; i < childcount*count-childcount; i++)
        {
            float x = i;

            GameObject player = Instantiate(Player, Vector3.zero, Quaternion.identity, respawn_obj.transform);

            player.transform.localPosition = Vector3.right * x;



        }
    }

    public void GameOver() 
    {
        Debug.Log("ゲームオーバー！");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
