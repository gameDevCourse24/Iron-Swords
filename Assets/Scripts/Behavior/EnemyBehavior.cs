using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int damage = 1; // כמות הנזק שהאויב גורם
    public float detectionRadius = 5f; // טווח שבו האויב מזהה את השחקן
    public Transform player;
    public float speed = 2f; // מהירות התנועה של האויב

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRadius)
        {
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // קבלת PlayerHealth
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
