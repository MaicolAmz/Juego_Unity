using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OpenDoor : MonoBehaviour
{
    public Text text;
    //Móvil
    public Button boton;
    public string levelName;
    private bool inDoor = false;

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
        SceneManager.LoadScene(levelName);
    }
}
