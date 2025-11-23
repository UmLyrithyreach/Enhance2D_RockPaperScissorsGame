using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Selection : MonoBehaviour
{
    public Button returnButton;
    public Button button1V1;
    public Button button1V1_3wins;
    public Button button1V1_5wins;
    public Button button3V1_1win;
    public string returnToMainMenu;
    public string goTo1V1Scene;
    public string goTo1V1_3wins;
    public string goTo1V1_5wins;
    public string goTo3V1_1win;


    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    // Start is called before the first frame update
    void Start()
    {
        returnButton.onClick.AddListener(() => LoadScene(returnToMainMenu));
        button1V1.onClick.AddListener(() => LoadScene(goTo1V1Scene));
        button1V1_3wins.onClick.AddListener(() => LoadScene(goTo1V1_3wins));
        button1V1_5wins.onClick.AddListener(() => LoadScene(goTo1V1_5wins));
        button3V1_1win.onClick.AddListener(() => LoadScene(goTo3V1_1win));
    }
}
