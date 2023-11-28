using UnityEngine;
using UnityEngine.UI;

public class PretextingAwarenessGame : MonoBehaviour
{
    public Text riddleText;
    public InputField userInputField;
    public Button submitButton;
    public Text feedbackText;

    private string[] riddles = {
        "What has keys but can't open locks?",
        "I speak without a mouth and hear without ears. I have no body, but I come alive with the wind. What am I?",
        "The more you take, the more you leave behind. What am I?"
    };

    private string[] answers = {
        "Piano",
        "Echo",
        "Footsteps"
    };

    private int currentRiddleIndex = 0;

    void Start()
    {
        DisplayRiddle();
        submitButton.onClick.AddListener(CheckAnswer);
     
    }
    void DisplayRiddle()
    {
        riddleText.text = "Riddle: " + riddles[currentRiddleIndex];
        userInputField.text = "";
        feedbackText.text = "";
    }

    void CheckAnswer()
    {
        string userAnswer = userInputField.text;

        if (userAnswer.ToLower() == answers[currentRiddleIndex].ToLower())
        {
            feedbackText.text = "Correct! On to the next mystery...";
            currentRiddleIndex++;

            if (currentRiddleIndex < riddles.Length)
            {
                DisplayRiddle();
            }
            else
            {
                feedbackText.text = "Congratulations! You've successfully navigated the Carnival Riddles of Secrecy!";
                submitButton.interactable = false;
            }
        }
        else
        {
            feedbackText.text = "Oops! That's not the answer. Keep trying!";
        }
    }
}
