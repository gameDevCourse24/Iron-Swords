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
            resourceManager.life = 3;  // הגדרת החיים ל-3
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
        if (resourceManager != null)
        {
            resourceManager.life += amount; // הוספת חיים
            Debug.Log("Player healed! Lives: " + resourceManager.life);
        }
    }

    private void Die()
    {
        Debug.Log("Player is dead!");
        Time.timeScale = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1); // נזק קבוע מאויבים
        }
    }
}
