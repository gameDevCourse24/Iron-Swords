using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int intelligence = 0; // מודיעין
    public int healthKits = 0;   // ערכות עזרה ראשונה
    public int ammo = 0;         // תחמושת

    public void AddResource(string resourceType, int amount)
    {
        switch (resourceType)
        {
            case "Intelligence":
                intelligence += amount;
                Debug.Log("Intelligence collected: " + intelligence);
                break;
            case "HealthKit":
                healthKits += amount;
                Debug.Log("Health Kits collected: " + healthKits);
                break;
            case "Ammo":
                ammo += amount;
                Debug.Log("Ammo collected: " + ammo);
                break;
            default:
                Debug.LogWarning("Unknown resource type: " + resourceType);
                break;
        }
    }
}
