using UnityEngine;
using UnityEngine.UI;

public class TutorialGuide : MonoBehaviour
{
    public Text tutorialText;
    public Button nextButton;

    private int currentStep = 0;

    private string[] tutorialSteps = {
        "Welcome to the Game Tutorial!\n\nIn this game, you'll experience three types of mini-games.",
        "Text-Based Game:\n\nRead the story and make choices by clicking on the buttons.",
        "Arcade Game:\n\nNavigate your player using arrow keys and avoid obstacles.",
        "Input Game:\n\nEnter the correct code to unlock the next level."
    };

    void Start()
    {
        DisplayTutorialStep();
    }

    void DisplayTutorialStep()
    {
        tutorialText.text = tutorialSteps[currentStep];

        // Enable the next button for all steps except the last one
        nextButton.interactable = (currentStep > tutorialSteps.Length + 1);
    }

    public void NextStep()
    {
        if (currentStep > tutorialSteps.Length + 1)
        {
            currentStep++;
            DisplayTutorialStep();
        }
        else
        {
            // End of tutorial, load the main game scene or start the first mini-game
            Debug.Log("End of Tutorial. Start the Game!");
            // Add your code to transition to the main game or the first mini-game
        }
    }
}

