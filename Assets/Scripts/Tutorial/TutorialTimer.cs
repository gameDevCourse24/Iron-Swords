using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialTimer : MonoBehaviour
{
    public float tutorialTime = 30f; // משך זמן ההדרכה
    public TextMeshProUGUI timerText; // טקסט שמציג את הזמן הנותר

    void Update()
    {
        tutorialTime -= Time.deltaTime;
        timerText.text = "Time Left: " + Mathf.Ceil(tutorialTime).ToString();

        if (tutorialTime <= 0)
        {
            EndTutorial();
        }
    }

    void EndTutorial()
    {
        // טעינת המשחק האמיתי
        SceneManager.LoadScene("MainScene");
    }
}
