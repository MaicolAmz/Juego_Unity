using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;

    public Animator animator;
    private float checkPointPositionX, checkPointPositionY;

    private PlayerSelectDB playerSelectDB = null;

    public void Awake()
    {
        gameObject.AddComponent<PlayerSelectDB>();
        playerSelectDB = gameObject.GetComponent<PlayerSelectDB>();
    }

    void Start()
    {
        life = hearts.Length;
        if(PlayerPrefs.GetFloat("checkPointPositionX")!=0){
            transform.position=(new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"),PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    private void CheckLife ()
    {
        if (life <1)
        {
            Destroy(hearts[0].gameObject);
            animator.Play("Hit");

            PlayerPrefs.SetInt("puntajePreview", 0);

            if ((PlayerPrefs.GetString("username")).Length > 0)
            {
                playerSelectDB.CheckPuntaje((PlayerPrefs.GetInt("id_usuarios")).ToString(), delegate (CPuntaje res)
                {
                    if (res.done)
                    {
                        PlayerPrefs.SetInt("puntaje", Convert.ToInt32(res.data[0].puntaje));
                    }
                    else
                    {
                        PlayerPrefs.SetInt("puntaje", 0);
                    }
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                });
            } 
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("Hit");
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
            animator.Play("Hit");
        }
    }
    public void ReachedCheckPoint(float x, float y){
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamaged()
    {
        life--;
        CheckLife();
    }

}
