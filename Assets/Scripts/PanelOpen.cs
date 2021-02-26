using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelOpen : MonoBehaviour
{
    public void OpenPanel()
    {
        SceneManager.LoadScene("Scores");
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
