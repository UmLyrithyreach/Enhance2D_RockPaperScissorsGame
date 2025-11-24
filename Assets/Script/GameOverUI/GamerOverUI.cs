using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamerOverUI : MonoBehaviour
{
    public TextMeshProUGUI winnerTextUI;
    public Button restartButton;
    public Button returnToMainmenu;

    private void Start()
    {
        // Assign winner
        winnerTextUI.text = GameResult.WinnerName;

        // Buttons
        restartButton.onClick.AddListener(() => SceneManager.LoadScene("DifficultyUI"));
        returnToMainmenu.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
    }
}
