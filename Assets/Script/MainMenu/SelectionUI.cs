using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionUIManagement : MonoBehaviour
{
    public Button startButton;
    public Button selectDifficultyButton;
    public string sceneName1;
    public string sceneName2;

    void Start()
    {
        startButton.onClick.AddListener(() => LoadScene(sceneName1));
        selectDifficultyButton.onClick.AddListener(() => LoadScene(sceneName2));
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
