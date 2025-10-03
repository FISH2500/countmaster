using UnityEngine;

public class PlayerSoawn : MonoBehaviour
{
    public Transform Player;

    private bool isHit;
    private float NowTime;
    private float interval=3f;

    void Start()
    {
        
    }


    

    void Update()
    {
        if (Player != null) transform.position = Player.position;

        SetTime();
    }

    void SetTime()
    {
        if (isHit)
        {

            NowTime += Time.deltaTime;

            if (NowTime >= interval)
            {
                NowTime = 0;

                isHit = false;

            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isHit)
        {
            if (other.tag == "Plus")
            {
                Debug.Log("Blue");
                isHit = true;
                Destroy(other.gameObject);
            }
            else if (other.tag == "Minus")
            {
                Debug.Log("Red");
                isHit = true;
                Destroy(other.gameObject);
            }
        }
    }
}
