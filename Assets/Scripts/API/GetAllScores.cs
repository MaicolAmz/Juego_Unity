using UnityEngine;
using UnityEngine.UI;

public class GetAllScores : MonoBehaviour
{

    public Transform tabla;
    public Transform plantillaScore;

    private PlayerSelectDB playerSelectDB = null;

    public void Awake()
    {
        gameObject.AddComponent<PlayerSelectDB>();
        playerSelectDB = gameObject.GetComponent<PlayerSelectDB>();
    }

    // Start is called before the first frame update
    public void Start()
    {
        if ((PlayerPrefs.GetString("username")).Length > 0)
        {
            playerSelectDB.CheckPuntajesGlobal(delegate (CPuntaje res)
            {
                if (res.done)
                {
                    for (int i = 0; i < res.data.Length ; i++)
                    {
                        Transform entryTransform = Instantiate(plantillaScore, tabla);
                        RectTransform entryRecTransform = entryTransform.GetComponent<RectTransform>();
                        entryRecTransform.anchoredPosition = new Vector2(0, -25f * i);
                        entryTransform.gameObject.SetActive(true);

                        entryTransform.Find("username").GetComponent<Text>().text = res.data[i].username;
                        entryTransform.Find("puntaje").GetComponent<Text>().text = res.data[i].puntaje;
                        entryTransform.Find("lugar").GetComponent<Text>().text = (i + 1).ToString();
                    }
                }
                else
                {
                    Debug.LogError("Espere");
                }

            });
        }
        else
        {
            Debug.Log("Necesita Loguearse para saber");
        }
    }
}
