using UnityEngine;

public class Enemy : MonoBehaviour
{

    public enum State { Idele,Running}

    [Header("setting")]
    [SerializeField] private float searchRadius;
    [SerializeField] private float moveSpeed;

    public State state;
    public bool PlayerCheck;
    public Transform targetRunner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState() 
    {
        switch (state) 
        {
            case State.Idele:
                SearchForTarget();
                break;

            case State.Running:
                //PlayerCheck = true;
                RunTowardsTarget();
                break;
        }
    }

    private void SearchForTarget() 
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, searchRadius);

        for(int i = 0; i < detectedColliders.Length; i++) 
        {
            if (detectedColliders[i].TryGetComponent(out Runner runner)) 
            {
                if (runner.IsTarget()) continue;

                runner.SetTaregt();

                Debug.Log(gameObject.name + "‚Í" + runner.gameObject.name + "‚ð" + "Target‚É‚Æ‚ç‚¦‚½");
                

                targetRunner = runner.transform;

                StartRunningTowardsTarget();
            }
        }
    }

    public void StartRunningTowardsTarget() 
    {
        state= State.Running;
    }

    private void RunTowardsTarget() 
    {

        Debug.Log(targetRunner.gameObject.name);

        if (targetRunner == null) return;



        transform.position = Vector3.MoveTowards(transform.position, targetRunner.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetRunner.position)<0.1f) 
        {
            Destroy(targetRunner.gameObject);
            Destroy(gameObject);
        }
    }
}
