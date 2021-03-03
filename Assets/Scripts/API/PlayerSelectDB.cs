using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerSelectDB : MonoBehaviour
{

    public void CheckPuntajesGlobal(Action<CPuntaje> response)
    {
        StartCoroutine(CO_CheckPuntajesGlobal(response));
    }

    private IEnumerator CO_CheckPuntajesGlobal(Action<CPuntaje> response)
    {

        using (UnityWebRequest www = UnityWebRequest.Get("https://testyaviracunity.herokuapp.com/puntajes/"))
        {

            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError(www.error);
                string result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                response(JsonUtility.FromJson<CPuntaje>(result));
            }
            else
            {
                string result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                response(JsonUtility.FromJson<CPuntaje>(result));
            }
        }
    }

    public void CheckPuntaje(string id_usuario, Action<CPuntaje> response)
    {
        StartCoroutine(CO_CheckPuntaje(id_usuario, response));
    }

    private IEnumerator CO_CheckPuntaje(string id_usuario, Action<CPuntaje> response)
    {

        using (UnityWebRequest www = UnityWebRequest.Get("https://testyaviracunity.herokuapp.com/puntajes/"+id_usuario))
        {

            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError(www.error);
                string result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                response(JsonUtility.FromJson<CPuntaje>(result));
            }
            else
            {
                string result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                response(JsonUtility.FromJson<CPuntaje>(result));
            }
        }
    }

    public void InsertPuntaje(int id_usuario, string puntaje, Action<CPuntaje> response)
    {
        StartCoroutine(CO_InsertPuntaje(id_usuario, puntaje, response));
    }

    private IEnumerator CO_InsertPuntaje(int id_usuario, string puntaje, Action<CPuntaje> response)
    {
        Puntaje form = new Puntaje();
        form.id_usuarios = id_usuario;
        form.puntaje = puntaje;

        string jsonObject = JsonUtility.ToJson(form);
        
        using (UnityWebRequest www = UnityWebRequest.Post("https://testyaviracunity.herokuapp.com/puntajes", jsonObject))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonObject));

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError(www.error);
                string result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                response(JsonUtility.FromJson<CPuntaje>(result));
            }
            else
            {
                string result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                response(JsonUtility.FromJson<CPuntaje>(result));
            }
        }
    }
}
