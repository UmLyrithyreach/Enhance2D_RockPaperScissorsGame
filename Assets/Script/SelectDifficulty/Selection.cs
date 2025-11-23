using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Selection : MonoBehaviour
{
    public Button returnButton;
    public string sceneName;

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    // Start is called before the first frame update
    void Start()
    {
        returnButton.onClick.AddListener(() => LoadScene(sceneName));
    }
}
