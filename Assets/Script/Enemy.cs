using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum State { Idle, Running }

    [Header("Setting")]
    [SerializeField] private float searchRadius = 5f;
    [SerializeField] private float moveSpeed = 3f;

    public State state = State.Idle;
    public Transform targetRunner;

    private Runner targetRunnerScript; // �� Runner�X�N���v�g��ێ�
    private Animator animator;

    public float boxLength = 5f;     // �O�����ւ̒���
    public float boxWidth = 1f;      // ���̕�
    public float boxHeight = 1f;     // ����
    public LayerMask targetLayer;    // ���o�Ώۂ̃��C���[
    Vector3 boxCenter;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

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
                animator.SetBool("Run", false);
                break;

            case State.Running:
                RunTowardsTarget();
                animator.SetBool("Run", true);
                break;
        }
    }

    private void SearchForTarget()
    {
        Vector3 boxCenter = transform.position + transform.forward * (boxLength / 2f);
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, searchRadius);

        foreach (var col in detectedColliders)
        {
            //if (!col.CompareTag("Runner")) continue;
            
            if (col.TryGetComponent(out Runner runner)&&CheckObject.isPlayerHit)
            {
                if (runner.IsTarget()) continue;

                // �^�[�Q�b�g�ݒ�
                runner.SetTaregt();
                targetRunner = runner.transform;
                targetRunnerScript = runner;
                Debug.Log($"{name} �� {runner.name} ���^�[�Q�b�g�ɂƂ炦��");
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
            ResetTarget(); // �� �ǐՑΏۂ�����
            return;
        }

        transform.LookAt(targetRunner.position);
        transform.position = Vector3.MoveTowards(transform.position, targetRunner.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetRunner.position) < 0.1f)// �Փˎ��̏���
        {
            
            Destroy(targetRunner.gameObject);
            ResetTarget(); // �� Runner�j��O�ɉ����i���S�j
            Destroy(gameObject);
        }
    }

    private void ResetTarget()
    {
        if (targetRunnerScript != null)
        {
            targetRunnerScript.UnSetTaregt(); // �� �^�[�Q�b�g����
            targetRunnerScript = null;
        }
        targetRunner = null;
        state = State.Idle;
    }

    private void OnDestroy()
    {
        // �G��������Ƃ��ɁA�ǐՂ��Ă�Runner������
        ResetTarget();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }
}
