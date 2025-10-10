using UnityEngine;

public class CrowedSystem : MonoBehaviour
{
    public float Interval;
    [Header("Elements")]
    [SerializeField] private float angle;
    [SerializeField] private float radius;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceRunner();
    }

    private void PlaceRunner() 
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            //float x = (i + 1) * 1 + Interval * (i + 1);

            Vector3 childlocalposition=GetRunnerlocalPosition(i);

            transform.GetChild(i).localPosition = childlocalposition;
        }
    } 

    private Vector3 GetRunnerlocalPosition(int index) 
    {
        float x=  radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(x,0,z);
    }

    public float GetCrowed() 
    {
        return radius * Mathf.Sqrt(transform.childCount);
    }

}
