using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum State { Idle, Running }

    [Header("Setting")]
    [SerializeField] private float searchRadius = 5f;
    [SerializeField] private float moveSpeed = 3f;

    public State state = State.Idle;
    public Transform targetRunner;

    private Runner targetRunnerScript; // ← Runnerスクリプトを保持

    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        switch (state)
        {
            case State.Idle:
                SearchForTarget();
                break;

            case State.Running:
                RunTowardsTarget();
                break;
        }
    }

    private void SearchForTarget()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, searchRadius);

        foreach (var col in detectedColliders)
        {
            //if (!col.CompareTag("Runner")) continue;
            Debug.Log("Check"+CheckObject.isPlayerHit);
            if (col.TryGetComponent(out Runner runner)&&CheckObject.isPlayerHit)
            {
                if (runner.IsTarget()) continue;

                // ターゲット設定
                runner.SetTaregt();
                targetRunner = runner.transform;
                targetRunnerScript = runner;
                Debug.Log($"{name} は {runner.name} をターゲットにとらえた");
                StartRunningTowardsTarget();
                break;
            }
        }
    }

    public void StartRunningTowardsTarget()
    {
        state = State.Running;
    }

    private void RunTowardsTarget()
    {
        if (targetRunner == null)
        {
            ResetTarget(); // ← 追跡対象を解除
            return;
        }

        transform.LookAt(targetRunner.position);
        transform.position = Vector3.MoveTowards(transform.position, targetRunner.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetRunner.position) < 0.1f)
        {
            // 衝突時の処理
            Destroy(targetRunner.gameObject);
            ResetTarget(); // ← Runner破壊前に解除（安全）
            Destroy(gameObject);
        }
    }

    private void ResetTarget()
    {
        if (targetRunnerScript != null)
        {
            targetRunnerScript.UnSetTaregt(); // ← ターゲット解除
            targetRunnerScript = null;
        }
        targetRunner = null;
        state = State.Idle;
    }

    private void OnDestroy()
    {
        // 敵が消えるときに、追跡してたRunnerを解除
        ResetTarget();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }
}
