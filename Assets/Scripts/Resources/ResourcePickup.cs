using UnityEngine;

public class ResourcePickup : MonoBehaviour
{
    public enum ResourceType { Intelligence, HealthKit, Ammo }
    public ResourceType resourceType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ResourceManager resourceManager = FindObjectOfType<ResourceManager>();

            if (resourceManager != null)
            {
                switch (resourceType)
                {
                    case ResourceType.Intelligence:
                        resourceManager.AddIntelligence();
                        break;
                    case ResourceType.HealthKit:
                        resourceManager.AddHealthKit();
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
