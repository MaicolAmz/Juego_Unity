using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ValidateUser : MonoBehaviour
{
    [SerializeField] public Text username;
    [SerializeField] public Text puntaje;
    private int id_usuario = 0;
    private string textUsername = "";

    private PlayerSelectDB playerSelectDB = null;

    public void Awake()
    {
        gameObject.AddComponent<PlayerSelectDB>();
        playerSelectDB = gameObject.GetComponent<PlayerSelectDB>();
    }

    public void checkPuntaje()
    {
        textUsername = PlayerPrefs.GetString("username");
        id_usuario = PlayerPrefs.GetInt("id_usuarios");
        if (textUsername.Length > 0)
        {
            username.text = textUsername;
            if ( id_usuario != 0)
            {
                playerSelectDB.CheckPuntaje(id_usuario.ToString(), delegate (CPuntaje res)
                {
                    if (res.done)
                    {
                        puntaje.text = res.data[0].puntaje;
                        PlayerPrefs.SetInt("puntaje", Convert.ToInt32(puntaje.text));
                    }
                    else
                    {
                        puntaje.text = "0";
                        PlayerPrefs.SetInt("puntaje", 0);
                    }
                });
            }
            else
            {
                puntaje.text = "0";
            }
        }
        else
        {
            username.text = "Sin Registrase";
            if (PlayerPrefs.GetInt("puntaje") != 0)
            {
                puntaje.text = PlayerPrefs.GetInt("puntaje").ToString();
            }
            else
            {
                puntaje.text = "---";
            }
        }
    }

}
