using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    public Collider2D collider2D;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public GameObject destroyParticle;

    public float jumpForce = 2.5f;

    public int lifes = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            LosseLifeAndHint();
            CheckLife();
        }
    }

    public void LosseLifeAndHint()
    {
        lifes--;
        animator.Play("Hit");
    }

    public void CheckLife()
    {
        if (lifes == 0)
        {
            destroyParticle.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("EnemyDie", 0.2f);

        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
        if (PlayerPrefs.GetInt("puntajePreview").ToString().Length > 0)
        {
            aumentarPuntaje(gameObject.name, PlayerPrefs.GetInt("puntajePreview"));
        }
        else
        {
            aumentarPuntaje(gameObject.name, 0);
        }
    }

    public void aumentarPuntaje(string tipo, int puntaje)
    {
        PlayerPrefs.SetInt("puntajePreview", puntaje += 10);
    }

}
