using UnityEngine;
using UnityEngine.UI;

public class PretextingGame : MonoBehaviour
{
    public Text instructionText;
    public InputField userInputField;
    public Button submitButton;

    private string targetInformation = "Secret Code123";
    private string pretextMessage = "Welcome to the Magical Code Carnival! To unlock the enchanted VIP area, you must whisper the secret incantation:";
    private string successMessage = "Congratulations! The gates to the VIP area swing open, revealing a world of wonders.";
    private string failureMessage = "Oh no! The magical barrier remains closed. Your incantation must have been incorrect.";

    private bool gameActive = false;

    void Start()
    {
        ResetGame();
    }

    void ResetGame()
    {
        userInputField.text = "";
        instructionText.text = pretextMessage;
        submitButton.onClick.RemoveAllListeners();
        submitButton.onClick.AddListener(StartGame);
        submitButton.GetComponentInChildren<Text>().text = "Begin the Quest";
        gameActive = false;
    }

    void StartGame()
    {
        instructionText.text = pretextMessage;
        submitButton.onClick.RemoveAllListeners();
        submitButton.onClick.AddListener(CheckCode);
        submitButton.GetComponentInChildren<Text>().text = "Whisper the Incantation";
        gameActive = true;
    }

    void CheckCode()
    {
        string userCode = userInputField.text;

        if (userCode == targetInformation)
        {
            instructionText.text = successMessage;
        }
        else
        {
            instructionText.text = failureMessage;
        }

        submitButton.onClick.RemoveAllListeners();
        submitButton.onClick.AddListener(ResetGame);
        submitButton.GetComponentInChildren<Text>().text = "Try Again";
        gameActive = false;
    }
}
