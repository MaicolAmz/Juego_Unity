using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FruitManager : MonoBehaviour
{
    public Text totalFruits;
    public Text fruitsCollected;
    public Text puntaje;
    private int totalFruitsInLevel;
    public Text levelCleared;
    public GameObject transition;
    public Button nextLevel;

    private PlayerSelectDB playerSelectDB = null;

    public void Awake()
    {
        gameObject.AddComponent<PlayerSelectDB>();
        playerSelectDB = gameObject.GetComponent<PlayerSelectDB>();
    }

    private void Start()
    {
        totalFruitsInLevel = transform.childCount;
    }
    //Actualiza cada que se coja una fruta
    public void FixedUpdate()
    {
        AllFruitsCollected();
        totalFruits.text = totalFruitsInLevel.ToString(); 
        fruitsCollected.text = transform.childCount.ToString();

        puntaje.text = PlayerPrefs.GetInt("puntajePreview").ToString();
    }
    //Si quedan una fruta
    public void AllFruitsCollected()
    {
        if (transform.childCount == 0)
        {
            transition.SetActive(true);
            levelCleared.gameObject.SetActive(true);
            //Cambiar de Nivel o Escena
            nextLevel.gameObject.SetActive(true);
        }
    }
    public void ChangeScene() {
        if (PlayerPrefs.GetString("username").Length > 0)
        {
            int puntaje = PlayerPrefs.GetInt("puntaje") + PlayerPrefs.GetInt("puntajePreview");

            playerSelectDB.InsertPuntaje(PlayerPrefs.GetInt("id_usuarios"), puntaje.ToString(), delegate (CPuntaje respuesta)
            {
                nextLevel.gameObject.SetActive(false);
                PlayerPrefs.SetInt("puntajePreview", 0);
                PlayerPrefs.SetString("nivel", (SceneManager.GetActiveScene().buildIndex).ToString());
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            });
        } 
        else
        {
            nextLevel.gameObject.SetActive(false);
            PlayerPrefs.SetInt("puntajePreview", 0);
            PlayerPrefs.SetString("nivel", (SceneManager.GetActiveScene().buildIndex).ToString());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);;
        }
    }
}
