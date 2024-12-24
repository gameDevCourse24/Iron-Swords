using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;

    void Start()
    {
        tutorialText.text = "Welcome! Use the arrow keys to move.";
    }

    public void UpdateInstruction(string newInstruction)
    {
        tutorialText.text = newInstruction;
    }
}
