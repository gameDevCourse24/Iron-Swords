using UnityEngine;

public class ResourcePickup : MonoBehaviour
{
    public enum ResourceType { Intelligence, HealthKit, Ammo }
    public ResourceType resourceType;
    public int healthKitValue = 1; // כמות החיים שנוספת עבור HealthKit

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // מציאת ResourceManager
            ResourceManager resourceManager = FindObjectOfType<ResourceManager>();
            // מציאת PlayerHealth (לטיפול בחיים)
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (resourceManager != null)
            {
                switch (resourceType)
                {
                    case ResourceType.Intelligence:
                        resourceManager.AddIntelligence();
                        break;
                    case ResourceType.HealthKit:
                        if (playerHealth != null)
                        {
                            // הוספת חיים לשחקן
                            playerHealth.resourceManager.AddLife();
                        }
                        resourceManager.AddHealthKit(); // עדכון מספר ה-HealthKits במשאבים
                        break;
                    case ResourceType.Ammo:
                        resourceManager.AddAmmo();
                        break;
                }
            }

            // השמדת האובייקט שנאסף
            Destroy(gameObject);
        }
    }
}
