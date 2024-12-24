using System.Collections;
using UnityEngine;
using TMPro;

public class TutorialTextManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText; // רכיב ה-TMP להצגת הטקסט
    public float displayDuration = 3f; // משך הזמן שבו כל טקסט מוצג
    private string[] instructions = // רשימת ההוראות
    {
        "Welcome!",
        "Use the arrow keys to move.",
        "Press the space bar to kill Hamasnik",
        "Take intelligence to discover more parts of the map!",
        "Take HealthKit to get more lives!",
        "Avoid enemies to stay alive!"
    };

    void Start()
    {
        StartCoroutine(DisplayInstructions());
    }

    IEnumerator DisplayInstructions()
{
    foreach (string instruction in instructions)
    {
        tutorialText.text = instruction;

        // Fade In
        yield return StartCoroutine(FadeTextToFullAlpha(1f, tutorialText));

        // המתנה
        yield return new WaitForSeconds(displayDuration);

        // Fade Out
        yield return StartCoroutine(FadeTextToZeroAlpha(1f, tutorialText));
    }

    tutorialText.text = "GOOD LUCK...";
}

IEnumerator FadeTextToFullAlpha(float duration, TextMeshProUGUI text)
{
    text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    while (text.color.a < 1.0f)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / duration));
        yield return null;
    }
}

IEnumerator FadeTextToZeroAlpha(float duration, TextMeshProUGUI text)
{
    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    while (text.color.a > 0.0f)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / duration));
        yield return null;
    }
}

}
