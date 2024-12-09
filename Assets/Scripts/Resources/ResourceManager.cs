using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int intelligence = 0; // מתחיל מאפס
    public int healthKits = 0;  // מתחיל מאפס
    public int ammo = 0;        // מתחיל מאפס

    public void AddIntelligence()
    {
        intelligence++;
    }

    public void AddHealthKit()
    {
        healthKits++;
    }

    public void AddAmmo()
    {
        ammo++;
    }
}
