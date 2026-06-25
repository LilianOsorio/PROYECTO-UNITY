using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    [SerializeField] GameObject[] nuevosPisos;
    [SerializeField] float distanciaX = 20f; 
    [SerializeField] float alturaY = -2.5f;  

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int randomIndex = Random.Range(0, nuevosPisos.Length); 
            
            // Usamos las nuevas variables en lugar de los números fijos
            Instantiate(nuevosPisos[randomIndex], new Vector3(transform.position.x + distanciaX, alturaY, transform.position.z), Quaternion.identity);
            transform.position = new Vector3(transform.position.x + distanciaX, alturaY, transform.position.z);    
        }
    }
}