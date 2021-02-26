using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
    {  
        //valida que el enemigo entra en contacto con el jugado y ejecuta la destrucción del objeto 
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
    }
}
