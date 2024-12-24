using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsScene : MonoBehaviour
{
    public float timer = 25f; // זמן ההוראות ב-25 שניות

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene("TutorialScene");        }
    }
}
