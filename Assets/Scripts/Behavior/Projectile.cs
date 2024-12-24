using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 targetPosition; // מיקום המטרה
    private float speed; // מהירות התנועה

    public void SetTarget(Vector2 target, float projectileSpeed)
    {
        targetPosition = target;
        speed = projectileSpeed;
    }

    void Update()
    {
        // תנועה לכיוון המטרה
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // השמדת הירייה אם הגיעה ליעד
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // השמדת האויב
            Destroy(collision.gameObject);

            // השמדת הירייה
            Destroy(gameObject);
        }
    }
}
