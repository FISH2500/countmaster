using UnityEngine;

public class EnemySearchManager : MonoBehaviour
{
    public Player player;
    public float searchRadius;
    private bool enemyFound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.state == Player.Player_State.Battle) 
        {
            EnemySearch();
        }
    }

    private void EnemySearch() 
    {
        enemyFound = false;
        Debug.Log("検索中。。。");
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, searchRadius);

        foreach (var col in detectedColliders)
        {
            
            if (col.CompareTag("Enemy"))
            {
                enemyFound = true;
                break;
            }
        }
        if (!enemyFound)//フィールドに敵がいない 
        {
            
            player.state = Player.Player_State.Run;
            player.ResetRotation();
            CheckObject.isPlayerHit = false;
            Destroy(gameObject);
        }

    }
}
