using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importa el espacio de nombres necesario para manejar escenas, lo que permite reiniciar el juego al cargar la escena actual nuevamente
using TMPro; // Importa el espacio de nombres necesario para usar TextMeshPro, lo que permite mostrar la puntuación del jugador en la pantalla de manera más atractiva y legible

public class GM : MonoBehaviour
{
    [SerializeField] GameObject panelGameOver; // Referencia al panel de Game Over, se asigna desde el inspector de Unity para mostrarlo cuando el jugador muere

    public bool gameOver = false; // Variable para controlar el estado del juego, se establece en true cuando el jugador muere
    float score = 0; // Variable para almacenar la puntuación del jugador, se incrementa a medida que el jugador avanza en el juego
    float score0ffset = 0; // Variable para almacenar el offset inicial de la puntuación, se resta de la posición del jugador para que la puntuación comience desde cero
    [SerializeField] TextMeshProUGUI scoreText; // Referencia al texto de la puntuación en la interfaz de usuario, se asigna desde el inspector de Unity para mostrar la puntuación del jugador en la pantalla
    [SerializeField] Player player; // Referencia al script del jugador, se asigna desde el inspector de Unity para acceder a sus variables y métodos si es necesario

   
   void Awake()
    {
        score0ffset =(int) player.gameObject.transform.position.x; // Almacena la posición inicial del jugador para que la puntuación comience desde cero, se puede usar para mostrar la puntuación del jugador en la pantalla y hacer que el juego sea más competitivo y divertido
    }
   
    // Update is called once per frame
    void Update()
    {
        if (gameOver) // Si el juego ha terminado, muestra el panel de Game Over
        {
            panelGameOver.SetActive(true);

        }        
        else
        {
            score = (int)(player.transform.position.x - score0ffset); // Calcula la puntuación basada en la posición del jugador, restando un offset inicial para que la puntuación comience desde cero, se puede usar para mostrar la puntuación del jugador en la pantalla y hacer que el juego sea más competitivo y divertido
            scoreText.text = "" + score; // Actualiza el texto de la puntuación en la pantalla, se puede usar para mostrar la puntuación del jugador en la pantalla y hacer que el juego sea más competitivo y divertido

        }
    }

    public void Reset() // Método para reiniciar el juego, se puede llamar desde un botón en el panel de Game Over
    {
        Debug.Log("¡El botón sí funciona y llamó a Reset!");
        Time.timeScale = 1; // Asegura que el tiempo del juego esté en su escala normal antes de reiniciar, lo que permite que el juego se ejecute correctamente después de reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);// Recarga la escena actual para reiniciar el juego
    }
}
