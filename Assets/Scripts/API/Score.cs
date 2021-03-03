using System;
using System.Collections.Generic;

[Serializable]
public class CPuntaje
{
    public bool done = false;
    public string message = "";
    public Puntaje[] data;
}

[Serializable]
public class Puntaje
{
    public int id_usuarios = 1;
    public string username = "";
    public string puntaje = "";
}
