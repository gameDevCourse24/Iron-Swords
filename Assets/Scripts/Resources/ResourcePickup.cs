using UnityEngine;

public class ResourcePickup : MonoBehaviour
{
    public enum ResourceType { Intelligence, HealthKit, Ammo }
    public ResourceType resourceType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // מציאת ResourceManager
            ResourceManager resourceManager = FindObjectOfType<ResourceManager>();
            // מציאת ResourceUI
            ResourceUI resourceUI = FindObjectOfType<ResourceUI>();

            if (resourceManager != null)
            {
                switch (resourceType)
                {
                    case ResourceType.Intelligence:
                        resourceManager.AddIntelligence();
                        break;
                    case ResourceType.HealthKit:
                        resourceManager.AddHealthKit(); // עדכון מספר ערכות העזרה הראשונית
                        break;
                    case ResourceType.Ammo:
                        resourceManager.AddAmmo();
                        break;
                }
                // עדכון ה-UI כדי לשקף את השינויים
                if (resourceUI != null)
                {
                    resourceUI.Update(); // מעדכן את הטקסטים במסך
                }
            }

            // השמדת האובייקט שנאסף
            Destroy(gameObject);
        }
    }
}
