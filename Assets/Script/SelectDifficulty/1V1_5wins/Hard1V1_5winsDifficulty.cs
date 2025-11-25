using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hard1V1_5winsDifficulty : MonoBehaviour
{
    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;
    public Text winnerDisplay;
    public Image questionMarkImage_User;
    public Image RockImage_User;
    public Image PaperImage_User;
    public Image ScissorsImage_User;
    public Image questionMarkImage_Computer;
    public Image RockImage_Computer;
    public Image PaperImage_Computer;
    public Image ScissorsImage_Computer;
    public Text computerIndex;
    public Text userIndex;
    public Button returnToMainMenuButton;

    private string userChoice;
    private string computerChoice;
    private int userWins = 0;
    private int computerWins = 0;

    private const int WINS_NEEDED = 5;  // Change for 5 wins, 10 wins, etc.

    private void Start()
    {
        // Initialize UI
        userIndex.text = "0";
        computerIndex.text = "0";

        // Add button listeners
        rockButton.onClick.AddListener(() => OnChoiceClicked("Rock", RockImage_User));
        paperButton.onClick.AddListener(() => OnChoiceClicked("Paper", PaperImage_User));
        scissorsButton.onClick.AddListener(() => OnChoiceClicked("Scissors", ScissorsImage_User));

        returnToMainMenuButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
    }

    private void OnChoiceClicked(string choice, Image userChoiceImage)
    {
        if (userWins >= WINS_NEEDED || computerWins >= WINS_NEEDED)
            return;

        userChoice = choice;
        questionMarkImage_User.sprite = userChoiceImage.sprite;

        GenerateComputerChoice();
        DetermineWinner();
    }

    private void GenerateComputerChoice()
    {
        int randomChoice = Random.Range(0, 3);

        switch (randomChoice)
        {
            case 0:
                computerChoice = "Rock";
                questionMarkImage_Computer.sprite = RockImage_Computer.sprite;
                break;

            case 1:
                computerChoice = "Paper";
                questionMarkImage_Computer.sprite = PaperImage_Computer.sprite;
                break;

            case 2:
                computerChoice = "Scissors";
                questionMarkImage_Computer.sprite = ScissorsImage_Computer.sprite;
                break;
        }
    }

    private void DetermineWinner()
    {
        string message;

        if (userChoice == computerChoice)
        {
            message = "Tie.";
        }
        else if ((userChoice == "Rock" && computerChoice == "Scissors") ||
                 (userChoice == "Paper" && computerChoice == "Rock") ||
                 (userChoice == "Scissors" && computerChoice == "Paper"))
        {
            message = "User wins this round!";
            userWins++;
            computerIndex.text = "0";
            computerWins = 0;
            userIndex.text = userWins.ToString();
        }
        else
        {
            message = "Computer wins this round!";
            computerWins++;
            userIndex.text = "0";
            userWins = 0;
            computerIndex.text = computerWins.ToString();
        }

        winnerDisplay.text = message;

        // Check for full game win
        if (userWins >= WINS_NEEDED)
            EndGame("USER WINS THE GAME!");
        else if (computerWins >= WINS_NEEDED)
            EndGame("COMPUTER WINS THE GAME!");
    }

    private void EndGame(string winnerMessage)
    {
        winnerDisplay.text = winnerMessage;

        // Save results to GameResult
        GameResult.WinnerName = winnerMessage;
        GameResult.UserScore = userWins;
        GameResult.ComputerScore = computerWins;

        SceneManager.LoadScene("GameOverUIScene");
    }
}
