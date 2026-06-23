using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] float velocidad = 1f;
    [SerializeField] float aceleracion = 1f;
    [SerializeField] Transform camara;
    [SerializeField] float jumpForce = 1f;
    [SerializeField] GM gameManager;
    bool inGround = false;
    bool dead = false;

    Rigidbody2D rb;

    Animator anim; // Variable para controlar la animación del jugador, se puede usar para cambiar la animación del jugador según su estado (por ejemplo, corriendo, saltando, muerto) y hacer que el juego sea más visualmente atractivo y divertido

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (dead) // Si el jugador está muerto, se detiene el movimiento
        {
            return;
        }

        // Movimiento constante
        velocidad += aceleracion * Time.deltaTime; // Incrementa la velocidad gradualmente
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime * velocidad;
        camara.position += new Vector3(1, 0, 0) * Time.deltaTime * velocidad; // Mueve la cámara junto con el jugador
        
        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && inGround)
        {
            inGround = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            anim.SetBool("isJumping", true); // Cambia la animación del jugador a "saltando" cuando se presiona la tecla de salto y el jugador está en el suelo, lo que hace que el juego sea más visualmente atractivo y divertido
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("isCrouching", true); // Cambia la animación del jugador a "agachado" cuando se presiona la tecla de agacharse, lo que hace que el juego sea más visualmente atractivo y divertido
        }
        else
        {
            anim.SetBool("isCrouching", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Detecta si choca con un obstáculo
        if (collision.gameObject.tag == "Obstaculos")
        {
            dead = true;

            anim.SetTrigger("die"); // Cambia la animación del jugador a "muerto" cuando choca con un obstáculo, lo que hace que el juego sea más visualmente atractivo y divertido

            gameManager.gameOver = true; // Establece el estado de juego a Game Over en el Game Manager, lo que hará que se muestre el panel de Game Over en la pantalla y detendrá el juego para indicar que el jugador ha perdido
        }
        
        // Detecta si toca el suelo
        inGround = true;
    }
}