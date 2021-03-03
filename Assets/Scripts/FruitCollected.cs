using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FruitCollected : MonoBehaviour
{

    public AudioSource clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //Llamar si exiten frutas
            Destroy(gameObject, 0.2f);
            if (PlayerPrefs.GetInt("puntajePreview").ToString().Length > 0)
            {
                aumentarPuntaje(gameObject.name, PlayerPrefs.GetInt("puntajePreview"));
            } 
            else
            {
                aumentarPuntaje(gameObject.name, 0);
            }
            clip.Play();
        }
    }

    public void aumentarPuntaje(string tipo, int puntaje)
    {
        if (tipo.Contains("Apple"))
        {
            PlayerPrefs.SetInt("puntajePreview", puntaje += 5);
        } 
        else if (tipo.Contains("Bananas"))
        {
            PlayerPrefs.SetInt("puntajePreview", puntaje += 8);
        } 
        else if (tipo.Contains("Strawberry"))
        {
            PlayerPrefs.SetInt("puntajePreview", puntaje += 12);
        }
        else if (tipo.Contains("Orange"))
        {
            PlayerPrefs.SetInt("puntajePreview", puntaje += 15);
        }
        else if (tipo.Contains("Pineapple"))
        {
            PlayerPrefs.SetInt("puntajePreview", puntaje += 18);
        }
        else if (tipo.Contains("Melon"))
        {
            PlayerPrefs.SetInt("puntajePreview", puntaje += 21);
        }

    }
}
