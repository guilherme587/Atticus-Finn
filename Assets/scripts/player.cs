using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int vida = 5;
    public float speed = 5f; // Velocidade do jogador
    public float jumpForce = 5f; // Força do salto
    public float doubleJumpForce = 3f; // Força do segundo salto
    public Transform groundCheck; // Posição do objeto que verifica se o jogador está no chão
    public LayerMask groundLayer; // Layer na qual o jogador é considerado no chão

    private Rigidbody2D rb;
    private bool isGrounded = false; // Se o jogador está no chão
    private bool doubleJump = false; // Se o jogador já deu o segundo salto

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtém o componente Rigidbody2D do jogador
    }


    void Update()
    {
        // Movimentação horizontal
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Salto
        if (isGrounded)
        {
            doubleJump = false; // O jogador está no chão, então pode dar o segundo salto novamente
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (!doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
                doubleJump = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        // Verifica se o jogador está no chão
        if(other.gameObject.CompareTag("ground")) isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("ground")) isGrounded = false;
    }
}
