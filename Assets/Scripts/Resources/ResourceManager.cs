using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int intelligence = 0; // מתחיל מאפס
    public int healthKits = 0;  // מתחיל מאפס
    public int ammo = 0;        // מתחיל מאפס

    public int life = 3;

    public void AddIntelligence()
    {
        intelligence++;
    }

    public void AddHealthKit()
    {
        if (life < 3) // השחקן יכול להחזיר לעצמו חיים עד למקסימום של 3
        {
        life++;
        healthKits--; // הורדה ממספר ערכות העזרה
        Debug.Log("Health restored. Lives: " + life);
        }
    }


    public void AddAmmo()
    {
        ammo++;
    }

    public void AddLife()
    {
        life++;
    }

    
}
