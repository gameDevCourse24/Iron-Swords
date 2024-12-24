using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // ה-Prefab של הירייה
    public Transform shootPoint; // נקודת הירייה
    public float projectileSpeed = 10f; // מהירות הירייה
    public float shootingRadius = 5f; // רדיוס לירי

    void Update()
    {
        // בדיקת רדיוס האויבים
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, shootingRadius);
        Collider2D closestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (Collider2D col in enemiesInRange)
        {
            if (col.CompareTag("Enemy"))
            {
                float distance = Vector2.Distance(transform.position, col.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = col;
                }
            }
        }

        // קליטת לחיצה על מקש ירייה
        if (closestEnemy != null && Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(closestEnemy.transform.position);
        }
    }

    void Shoot(Vector2 targetPosition)
    {
        // יצירת הירייה
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        Projectile projectileScript = projectile.GetComponent<Projectile>();

        // שליחת המידע על המטרה לירייה
        if (projectileScript != null)
        {
            projectileScript.SetTarget(targetPosition, projectileSpeed);
        }
    }

    // להציג את רדיוס הירי בגיזמוס
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRadius);
    }
}
