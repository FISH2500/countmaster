using UnityEngine;

public class PlayerCheckScr : MonoBehaviour
{
    [SerializeField] private float searchRadius;
    [SerializeField] public Enemy enemy;
    private Transform targetRunner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.state == Enemy.State.Idele) { }

        SearchForTarget();
    }


    private void SearchForTarget()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, searchRadius);

        for (int i = 0; i < detectedColliders.Length; i++)
        {
            if (detectedColliders[i].TryGetComponent(out Runner runner))
            {
                if (runner.IsTarget()) continue;

                runner.SetTaregt();



                targetRunner = runner.transform;

                enemy.StartRunningTowardsTarget();
            }
        }
    }
}
