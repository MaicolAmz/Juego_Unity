using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectDB : MonoBehaviour
{
    string URL = "http://localhost/juego/select_player.php";
    public string [] playersData;
    public Text puntajes;
        // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW players = new WWW (URL);
        yield return players;
        string playersDataString = players.text;
        
        playersData = playersDataString.Split(';');
        for(int i = playersData.Length-1;i>=0;i--){
                puntajes.text += playersData[i] + "\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
