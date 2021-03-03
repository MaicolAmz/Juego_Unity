using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public AudioSource clip;
    public GameObject optionsPanel;

    private PlayerSelectDB playerSelectDB = null;

    public void Awake()
    {
        gameObject.AddComponent<PlayerSelectDB>();
        playerSelectDB = gameObject.GetComponent<PlayerSelectDB>();
    }

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

   public void GoMainMenu()
   {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");

        if (PlayerPrefs.GetString("username").Length > 0)
        {
            int puntaje = PlayerPrefs.GetInt("puntaje") + PlayerPrefs.GetInt("puntajePreview");

            playerSelectDB.InsertPuntaje(PlayerPrefs.GetInt("id_usuarios"), puntaje.ToString(), delegate (CPuntaje respuesta)
            {
                Debug.Log(respuesta.message);
                PlayerPrefs.SetString("nivel", (SceneManager.GetActiveScene().buildIndex).ToString());
                PlayerPrefs.SetInt("puntajePreview", 0);
            });
        }
        else
        {
            PlayerPrefs.SetString("nivel", (SceneManager.GetActiveScene().buildIndex).ToString());
            PlayerPrefs.SetInt("puntajePreview", 0);
        }
   }

   public void QuitGame()
   {
        //Application.Quit();
        Time.timeScale = 1;
        SceneManager.LoadScene("Login");

        if (PlayerPrefs.GetString("username").Length > 0)
        {
            int puntaje = PlayerPrefs.GetInt("puntaje") + PlayerPrefs.GetInt("puntajePreview");

            playerSelectDB.InsertPuntaje(PlayerPrefs.GetInt("id_usuarios"), puntaje.ToString(), delegate (CPuntaje respuesta)
            {
                Debug.Log(respuesta.message);
                PlayerPrefs.SetString("nivel", (SceneManager.GetActiveScene().buildIndex).ToString());
                PlayerPrefs.SetInt("puntajePreview", 0);
            });
        }
        else
        {
            PlayerPrefs.SetString("nivel", (SceneManager.GetActiveScene().buildIndex).ToString());
            PlayerPrefs.SetInt("puntajePreview", 0);
        }
    }
    
    public void PlaySoundButton()
    {
        clip.Play();
    }

}






