using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hard3V1_1WinDifficulty : MonoBehaviour
{
    [Header("User")]
    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;
    public Image questionMarkImage_User;
    public Image RockImage_User;
    public Image PaperImage_User;
    public Image ScissorsImage_User;

    [Header("Computer 1")]
    public Image questionMarkImage_Computer1;
    public Image RockImage_Computer1;
    public Image PaperImage_Computer1;
    public Image ScissorsImage_Computer1;
    public Text computer1Index;

    [Header("Computer 2")]
    public Image questionMarkImage_Computer2;
    public Image RockImage_Computer2;
    public Image PaperImage_Computer2;
    public Image ScissorsImage_Computer2;
    public Text computer2Index;

    [Header("UI")]
    public Text winnerDisplay;
    public Text userIndex;
    public Button returnToMainMenuButton;

    private string userChoice;
    private string computer1Choice;
    private string computer2Choice;

    private int userWins = 0;
    private int computer1Wins = 0;
    private int computer2Wins = 0;

    private const int WINS_NEEDED = 1;

    private void Start()
    {
        userIndex.text = "0";
        computer1Index.text = "0";
        computer2Index.text = "0";

        rockButton.onClick.AddListener(() => OnChoiceClicked("Rock", RockImage_User));
        paperButton.onClick.AddListener(() => OnChoiceClicked("Paper", PaperImage_User));
        scissorsButton.onClick.AddListener(() => OnChoiceClicked("Scissors", ScissorsImage_User));

        returnToMainMenuButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
    }

    private void OnChoiceClicked(string choice, Image userChoiceImage)
    {
        if (userWins >= WINS_NEEDED || computer1Wins >= WINS_NEEDED || computer2Wins >= WINS_NEEDED)
            return;

        userChoice = choice;
        questionMarkImage_User.sprite = userChoiceImage.sprite;

        GenerateComputerChoices();
        DetermineWinner();
    }

    private void GenerateComputerChoices()
    {
        // Computer 1
        int r1 = Random.Range(0, 3);
        switch (r1)
        {
            case 0:
                computer1Choice = "Rock";
                questionMarkImage_Computer1.sprite = RockImage_Computer1.sprite;
                break;
            case 1:
                computer1Choice = "Paper";
                questionMarkImage_Computer1.sprite = PaperImage_Computer1.sprite;
                break;
            case 2:
                computer1Choice = "Scissors";
                questionMarkImage_Computer1.sprite = ScissorsImage_Computer1.sprite;
                break;
        }

        // Computer 2
        int r2 = Random.Range(0, 3);
        switch (r2)
        {
            case 0:
                computer2Choice = "Rock";
                questionMarkImage_Computer2.sprite = RockImage_Computer2.sprite;
                break;
            case 1:
                computer2Choice = "Paper";
                questionMarkImage_Computer2.sprite = PaperImage_Computer2.sprite;
                break;
            case 2:
                computer2Choice = "Scissors";
                questionMarkImage_Computer2.sprite = ScissorsImage_Computer2.sprite;
                break;
        }
    }

    private int Compare(string user, string computer)
    {
        if (user == computer) return 0;
        if ((user == "Rock" && computer == "Scissors") ||
            (user == "Paper" && computer == "Rock") ||
            (user == "Scissors" && computer == "Paper"))
            return +1;
        return -1;
    }

    private void DetermineWinner()
    {
        string msg = "";

        // Compare vs Computer 1
        int result1 = Compare(userChoice, computer1Choice);
        if (result1 > 0)
        {
            userWins++;
            userIndex.text = userWins.ToString();
            msg += "You beat Computer 1! ";
        }
        else if (result1 < 0)
        {
            computer1Wins++;
            computer1Index.text = computer1Wins.ToString();
            msg += "Computer 1 wins! ";
        }
        else
        {
            msg += "Tie with Computer 1. ";
        }

        // Compare vs Computer 2
        int result2 = Compare(userChoice, computer2Choice);
        if (result2 > 0)
        {
            userWins++;
            userIndex.text = userWins.ToString();
            msg += "You beat Computer 2! ";
        }
        else if (result2 < 0)
        {
            computer2Wins++;
            computer2Index.text = computer2Wins.ToString();
            msg += "Computer 2 wins! ";
        }
        else
        {
            msg += "Tie with Computer 2.";
        }

        // Update display
        winnerDisplay.text = msg;

        // Check if anyone reached the winning score AFTER all comparisons
        if (userWins >= WINS_NEEDED)
            EndGame("USER WINS THE GAME!");
        else if (computer1Wins >= WINS_NEEDED)
            EndGame("COMPUTER 1 WINS THE GAME!");
        else if (computer2Wins >= WINS_NEEDED)
            EndGame("COMPUTER 2 WINS THE GAME!");
    }

    private void EndGame(string winnerMessage)
    {
        winnerDisplay.text = winnerMessage;

        GameResult.WinnerName = winnerMessage;
        GameResult.UserScore = userWins;
        GameResult.ComputerScore = Mathf.Max(computer1Wins, computer2Wins); // track highest score

        SceneManager.LoadScene("GameOverUIScene");
    }
}
