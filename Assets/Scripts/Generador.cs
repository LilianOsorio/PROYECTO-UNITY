using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    [SerializeField] GameObject[] nuevosPisos;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Genera un nuevo piso cada vez que el jugador pasa por el trigger

        int randomIndex= Random.Range(0, nuevosPisos.Length); // Selecciona un piso aleatorio de una lista de pisos disponibles
        
        Instantiate(nuevosPisos[randomIndex], new Vector3(transform.position.x + 20f, -2.5f, transform.position.z), Quaternion.identity);
        transform.position = new Vector3(transform.position.x + 20f, -2.5f, transform.position.z);    }


}

