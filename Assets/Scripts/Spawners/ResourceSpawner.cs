using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public GameObject[] resources; // מערך של Prefabs של המשאבים (HealthKit, Ammo וכו')
    public float spawnInterval = 6f; // מרווח זמן בין יצירות
    public float spawnRangeY = 3f; // טווח ה-Y שבו נוצרים המשאבים
    public Transform player; // רפרנס לשחקן

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnResource();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnResource()
    {
        if (resources.Length == 0) return;

        // בחירת משאב אקראי
        GameObject resourceToSpawn = resources[Random.Range(0, resources.Length)];

        // מיקום יצירת המשאב (קדימה לשחקן, בטווח Y אקראי)
        Vector3 spawnPosition = new Vector3(player.position.x + 10f, Random.Range(-spawnRangeY, spawnRangeY), 0);

        // יצירת המשאב
        Instantiate(resourceToSpawn, spawnPosition, Quaternion.identity);
    }
}
