using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public ResourceManager resourceManager;

    private void Start()
    {
        if (resourceManager == null)
        {
            resourceManager = FindObjectOfType<ResourceManager>();
        }

        if (resourceManager != null)
        {
            resourceManager.life = 3; // הגדרת החיים ל-3 בתחילת המשחק
        }
    }

    private void Update()
    {
        // שימוש במשאב של ערכת עזרה ראשונה בלחיצה על מקש H
        if (Input.GetKeyDown(KeyCode.H))
        {
            UseHealthKit();
        }
    }

    public void TakeDamage(int damage)
    {
        if (resourceManager != null)
        {
            resourceManager.life -= damage; // הפחתת חיים
            Debug.Log("Player took damage! Lives remaining: " + resourceManager.life);

            if (resourceManager.life <= 0)
            {
                Die();
            }
        }
    }

    public void Heal(int amount)
    {
        if (resourceManager != null && resourceManager.life < 3)
        {
            resourceManager.life += amount; // הוספת חיים עד מקסימום של 3
            Debug.Log("Player healed! Lives: " + resourceManager.life);
        }
    }

    private void UseHealthKit()
    {
        if (resourceManager != null && resourceManager.healthKits > 0)
        {
            Heal(1); // הוספת חיים
            resourceManager.healthKits--; // הורדה ממספר ערכות העזרה
            Debug.Log("Used a HealthKit! Remaining HealthKits: " + resourceManager.healthKits);
        }
        else
        {
            Debug.Log("No HealthKits available!");
        }
    }

    private void Die()
    {
        Debug.Log("Player is dead!");
        Time.timeScale = 0f; // עצירת המשחק
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1); // הפחתת חיים כאשר יש התנגשות עם אויב
        }
    }
}
