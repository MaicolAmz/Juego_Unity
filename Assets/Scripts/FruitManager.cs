using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FruitManager : MonoBehaviour
{
    public Text totalFruits;
    public Text fruitsCollected;
    private int totalFruitsInLevel;
    public Text levelCleared;
    public GameObject transition;

    private void Start()
    {
        totalFruitsInLevel = transform.childCount;
    }
    //Actualiza cada que se coja una fruta
    public void Update()
    {
        AllFruitsCollected();
        totalFruits.text = totalFruitsInLevel.ToString(); 
        fruitsCollected.text = transform.childCount.ToString();
    }
    //Si quedan una fruta
    public void AllFruitsCollected()
    {
        if (transform.childCount == 0)
        {
            
            transition.SetActive(true);
            levelCleared.gameObject.SetActive(true);
            //Cambiar de Nivel o Escena
            Invoke("ChangeScene",2);
        }
    }
    void ChangeScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    
}
