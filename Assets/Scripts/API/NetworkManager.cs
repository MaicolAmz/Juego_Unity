using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
    public void CrearUser(string username, string password, Action<CResponse> response)
    {
        StartCoroutine(CO_CreateUser(username, password, response));
    }
    private IEnumerator CO_CreateUser(string username, string password, Action<CResponse> response)
    {
        Usuario form = new Usuario();
        form.username = username;
        form.password = password;

        string jsonObject = JsonUtility.ToJson(form);

        using (UnityWebRequest www = UnityWebRequest.Post("https://testyaviracunity.herokuapp.com/usuarios/register", jsonObject))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonObject));

            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError(www.error);
                string result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                response(JsonUtility.FromJson<CResponse>(result));
            }
            else
            {
                string result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                response(JsonUtility.FromJson<CResponse>(result));
            }
        }
    }

    public void CheckUser(string username, string password, Action<CResponse> response)
    {
        StartCoroutine(CO_CheckUser(username, password, response));
    }
    private IEnumerator CO_CheckUser(string username, string password, Action<CResponse> response)
    {
        Usuario form = new Usuario();
        form.username = username;
        form.password = password;

        string jsonObject = JsonUtility.ToJson(form);

        using (UnityWebRequest www = UnityWebRequest.Post("https://testyaviracunity.herokuapp.com/usuarios/login", jsonObject))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonObject));

            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError(www.error);
                string result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                response(JsonUtility.FromJson<CResponse>(result));
            }
            else
            {
                string result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                response(JsonUtility.FromJson<CResponse>(result));
            }
        }
    }
}
[Serializable]
public class Usuario
{
    public int id_usuarios;
    public string username;
    public string password;
}