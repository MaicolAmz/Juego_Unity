using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public AudioSource clip;


    public GameObject optionsPanel;

   public void OptionsPanel()
   {
       Time.timeScale = 0;
       optionsPanel.SetActive(true);
   }

   public void Return()
   {
       Time.timeScale = 1;
       optionsPanel.SetActive(false);
   }

   public void AnotherOptions()
   {
       //ajustes
   }

   public void GoMainMenu()
   {
       Time.timeScale = 1;
       SceneManager.LoadScene("MainMenu");
   }

   public void QuitGame()
   {
        //Application.Quit();
        Time.timeScale = 1;
        SceneManager.LoadScene("Login");
    }
    
    public void PlaySoundButton()
    {
        clip.Play();
    }

}






