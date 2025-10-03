using TMPro;
using UnityEngine;

public class Point_OutPut : MonoBehaviour
{
    public Point point;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextMeshProUGUI point_text= GetComponent<TextMeshProUGUI>();

        point_text.text = ""+point.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
