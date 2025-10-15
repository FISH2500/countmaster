using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PyramidSystem : MonoBehaviour
{
    int sum;
    int i=0;
    int[] num=new int[100];
    int remainingValue;
    public float upValue; 
    bool isWhileEnd=true;

    private Transform startposition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int childcount=gameObject.transform.childCount;

        while (isWhileEnd)
        {

            i++;

            for (int j = 0; j < childcount; j++)
            {
                
                sum += i;
                num[i-1] = i;
                upValue += 2.0f;
                Transform test = gameObject.transform.GetChild(i);//.transform.position += new Vector3(transform.position.x, transform.position.y + upValue, transform.position.z);
                test.position = new Vector3(transform.position.x + upValue / 2, transform.position.y + upValue, transform.position.z);
                Debug.Log("num:"+num[i-1]);

                for(int h = 0; h < i; h++) 
                {

                }
                if (childcount <= sum)
                {
                    remainingValue=childcount - sum;
                    isWhileEnd=false;
                    break;
                }
            }

        }

        Debug.Log("Žc‚è‚Í"+remainingValue+"i:"+i);

    }
}
