using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
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

    private void OnChoiceClicked(string choice, Image userChoiceImage)
    {
        Debug.Log($"You chose: {choice}");
        userChoice = choice;
        questionMarkImage_User.sprite = userChoiceImage.sprite;
        
        GenerateComputerChoice();
        DetermineWinner();
    }

    void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    private void GenerateComputerChoice()
    {
        int randomChoice = Random.Range(0, 3);
        
        switch(randomChoice)
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
        Debug.Log($"Computer chose: {computerChoice}");
    }

    private void DetermineWinner()
    {
        string winner;

        if(userChoice == computerChoice)
        {
            winner = "Tie.";
        }
        else if((userChoice == "Rock" && computerChoice == "Scissors") ||
                (userChoice == "Paper" && computerChoice == "Rock") ||
                (userChoice == "Scissors" && computerChoice == "Paper"))
        {
            winner = "User is the winner.";
            userIndex.text = (int.Parse(userIndex.text) + 1).ToString();
        }
        else
        {
            winner = "Computer is the winner.";
            computerIndex.text = (int.Parse(computerIndex.text) + 1).ToString();
        }

        winnerDisplay.text = $"{winner}";
        Debug.Log($"Winner: {winner}");

    }

    void Start()
    {
        rockButton.onClick.AddListener(() => OnChoiceClicked("Rock", RockImage_User));
        paperButton.onClick.AddListener(() => OnChoiceClicked("Paper", PaperImage_User));
        scissorsButton.onClick.AddListener(() => OnChoiceClicked("Scissors", ScissorsImage_User));
        returnToMainMenuButton.onClick.AddListener(LoadMainMenu);
    }
}