using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 3f; // velocidade do inimigo
    public int dano = 1;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // obter referência ao componente Rigidbody2D
    }

    void FixedUpdate()
    {
        // movimentar o inimigo para a esquerda
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // se o inimigo colidir com o jogador
        {
            //other.vida -= dano;
        }
    }
}
