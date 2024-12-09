using UnityEngine;

public class ResourcePickup : MonoBehaviour
{
    public string resourceType; // סוג המשאב (Intelligence, HealthKit, Ammo)
    public int amount = 1;      // כמות המשאב

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ResourceManager resourceManager = other.GetComponent<ResourceManager>();
            if (resourceManager != null)
            {
                resourceManager.AddResource(resourceType, amount);
                Destroy(gameObject); // השמדת המשאב לאחר האיסוף
            }
        }
    }
}
