using UnityEngine;
using UnityEngine.UI;

public class CarnivalConundrumMatch : MonoBehaviour
{
    public Text scenarioText;
    public Button genuineButton;
    public Button pretextingButton;

    private string[] genuineScenarios = {
        "A friendly carnival barker invites you to try a game of ring toss.",
        "You receive a genuine ticket to enter the thrilling roller coaster.",
        "A carnival performer offers you a balloon animal as a goodwill gesture."
    };

    private string[] pretextingScenarios = {
        "A person dressed as a staff member asks for your credit card information for a 'special offer.'",
        "Someone claiming to be a carnival official insists on knowing your home address for a supposed prize delivery.",
        "A carnival game operator requests your social security number for 'age verification.'"
    };

    private bool isPretextingScenario;
    
    void Start()
    {
        genuineButton.onClick.AddListener(() => CheckAnswer(false));
        pretextingButton.onClick.AddListener(() => CheckAnswer(true));

        ShowRandomScenario();
    }

    void ShowRandomScenario()
    {
        isPretextingScenario = Random.Range(0, 2) == 0;
        string[] scenarios = isPretextingScenario ? pretextingScenarios : genuineScenarios;
        scenarioText.text = scenarios[Random.Range(0, scenarios.Length)];
    }

    void CheckAnswer(bool playerGuess)
    {
        if (playerGuess == isPretextingScenario)
        {
            // Correct guess
            scenarioText.text = "Correct! You've identified the correct scenario at the carnival.";
        }
        else
        {
            // Incorrect guess
            scenarioText.text = "Oops! That's not the correct answer. Keep enjoying the carnival, but stay cautious!";
        }

        Invoke("ShowRandomScenario", 5f); // Show a new scenario after 2 seconds
    }
}
