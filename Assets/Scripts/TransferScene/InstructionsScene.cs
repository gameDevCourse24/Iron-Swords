using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsScene : MonoBehaviour
{
    public float timer = 30f; // זמן ההוראות ב-30 שניות

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene("MainScene"); // שם הסצנה הראשית
        }
    }
}
