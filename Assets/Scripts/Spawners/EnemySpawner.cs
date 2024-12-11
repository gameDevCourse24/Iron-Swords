using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;  // מערך של Prefabs של אויבים
    public float spawnInterval = 10f;  // מרווח זמן בין יצירת אויבים
    public float spawnRangeY = 3f;     // טווח ה-Y שבו יופיעו האויבים
    public Transform player;   // רפרנס לשחקן

    private float nextSpawnTime;  // הזמן הבא שבו אויב ייווצר

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;  // עדכון הזמן הבא
        }
    }

    void SpawnEnemy()
    {
        if (enemies.Length == 0) return;

        // בחירת אויב אקראי מתוך המערך
        GameObject enemyToSpawn = enemies[Random.Range(0, enemies.Length)];

        // מיקום יצירת האויב (קדימה לשחקן, בטווח Y אקראי)
        Vector3 spawnPosition = new Vector3(player.position.x + 10f, Random.Range(-spawnRangeY, spawnRangeY), 0);

        // יצירת האויב
        GameObject newEnemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);

        // חיבור השחקן לאויב החדש (אם יש צורך)
        EnemyBehavior enemyBehavior = newEnemy.GetComponent<EnemyBehavior>();
        if (enemyBehavior != null)
        {
            enemyBehavior.player = player;
        }
    }
}
