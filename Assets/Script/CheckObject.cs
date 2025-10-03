using UnityEngine;

public class CheckObject : MonoBehaviour
{
    public static bool isHit;
    public static float NowTime;
    private  float interval = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        
        
            if (other.tag == "Plus")
            {
                Debug.Log("Blue");
                isHit = true;
                Point p = other.GetComponent<Point>();

                ScoreManager.instance.SetPlayer(p.Count);
                Destroy(other.gameObject);

            }
            else if (other.tag == "Minus")
            {
                Debug.Log("Red");
                isHit = true;
                Point p = other.GetComponent<Point>();

                ScoreManager.instance.DestroyPlayer(p.Count);
                Destroy(other.gameObject);
            }
        
    }
}
