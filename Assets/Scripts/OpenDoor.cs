using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class OpenDoor : MonoBehaviour
{
    public Text text;
    //Móvil
    public Button boton;
    public string levelName;
    private bool inDoor = false;

    private PlayerSelectDB playerSelectDB = null;

    public void Awake()
    {
        gameObject.AddComponent<PlayerSelectDB>();
        playerSelectDB = gameObject.GetComponent<PlayerSelectDB>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
            boton.gameObject.SetActive(true);
            inDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        text.gameObject.SetActive(false);
        boton.gameObject.SetActive(false);
        inDoor = false;
    }
    public void openNivel()
    {
        PlayerPrefs.SetInt("puntajePreview", 0);
        PlayerPrefs.SetString("nivel", levelName);
        
        if (PlayerPrefs.GetString("username").Length > 0)
        {
            playerSelectDB.CheckPuntaje(PlayerPrefs.GetInt("id_usuarios").ToString(), delegate (CPuntaje res)
            {
                if (res.done)
                {
                    PlayerPrefs.SetInt("puntaje", Convert.ToInt32(res.data[0].puntaje));
                }
                else
                {
                    PlayerPrefs.SetInt("puntaje", 0);
                }
                SceneManager.LoadScene(levelName);
            });
        } 
        else
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
