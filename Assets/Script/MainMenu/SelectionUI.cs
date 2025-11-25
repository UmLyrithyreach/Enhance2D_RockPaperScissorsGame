using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionUIManagement : MonoBehaviour
{
    public Button startButton;
    public Button selectDifficultyButton;
    public string startScene;
    public string loadDifficultyScene;

    void Start()
    {
        startButton.onClick.AddListener(() => LoadScene(startScene));
        selectDifficultyButton.onClick.AddListener(() => LoadScene(loadDifficultyScene));
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
