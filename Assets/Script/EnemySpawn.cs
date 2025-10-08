using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [Header("�X�|�[���ݒ�")]
    [SerializeField] public float count;
    [SerializeField] public GameObject SpawnObject;
    [SerializeField] public Transform SpawnParent;

    [SerializeField] private float angle;
    [SerializeField] private float radius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn();
        PlaceRunner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn() 
    {
        for(int i = 0; i < count; i++) 
        {
            Instantiate(SpawnObject, transform);
        }
    }

    private void PlaceRunner()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            //float x = (i + 1) * 1 + Interval * (i + 1);

            Vector3 childlocalposition = GetRunnerlocalPosition(i);

            transform.GetChild(i).localPosition = childlocalposition;
        }
    }

    private Vector3 GetRunnerlocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(x, 0, z);
    }
}
