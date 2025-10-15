using UnityEngine;

public class Point : MonoBehaviour
{
    public int Count;
    public Collider Collider;

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
        Debug.Log("Hit");
        this.Collider.enabled = false;
        Collider.enabled = false;
    }
}
