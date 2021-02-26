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
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        WWW w = new WWW("https://test1unityyavirac.herokuapp.com/route/createUser.php", form);
        yield return w;
        Debug.Log(w.text);
        response(JsonUtility.FromJson<CResponse>(w.text));
    }

    public void CheckUser(string username, string password, Action<CResponse> response)
    {
        StartCoroutine(CO_CheckUser(username, password, response));
    }
    private IEnumerator CO_CheckUser(string username, string password, Action<CResponse> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        WWW w = new WWW("https://test1unityyavirac.herokuapp.com/route/checkUser.php", form);

        yield return w;
        response(JsonUtility.FromJson<CResponse>(w.text));
    }
}
