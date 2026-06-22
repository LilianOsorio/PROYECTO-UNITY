using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    [SerializeField] private float speed = 1f; // velocidad del jugador

    [SerializeField] private float speedIncrement = 0.01f; //aceleracion del jugador

    [SerializeField] private float fuerzaSalto = 1f; //fuerza del salto del jugador



    public Transform cameraTransform; //referencia al transform de la camara

    public GM gameManager; //referecnia al game manager

    private bool inGround,  dead = false, isCrouching = false; //booleanos que detectan piso, si el jugador está muerto y si está agachado

    private Animator animator; //variable de animador



    private Rigidbody2D rb; //variable de rigidbody2d

   
    void Awake(){

        rb = GetComponent<Rigidbody2D>(); //obtiene el componente rigidbody2d del jugador
        animator = GetComponent<Animator>(); //obtiene el componente animator del jugador
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == true){ // si está muerto ya no hagas el resto
            
            return;//evita que se ejecute todo lo demás
        }

     
        //si el jugador está en el piso y no está agachado entonces puede brincar con espacio
         if(Input.GetKeyDown(KeyCode.Space) == true && inGround == true && isCrouching == false){

           
            
            Debug.Log("Salto");
            inGround = false;

            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);//empuja hacia arriba
            
            //setea animación de brincar
            animator.SetBool("jump", true);


            
        }

        //si el jugador está en el piso y no está agachado entonces puede agacharse con flecha hacia abajo
        if(Input.GetKeyDown(KeyCode.DownArrow) == true && inGround == true && isCrouching == false){

            isCrouching = true;

            Debug.Log("Agachate");
            

            
            //setea animación de "agacharse"
            animator.SetBool("crouch", true);


            
        }

        //si el jugador está en el piso y está agachado entonces puede volver al estado base si deja de presionar la flecha hacia abajo
        if(Input.GetKeyUp(KeyCode.DownArrow) == true && inGround == true && isCrouching == true){

            isCrouching = false;

            Debug.Log("Deja de agacharte");
            

            
            //setea animación de "volver a estado base"
            animator.SetBool("crouch", false);


            
        }


        //mueven el jugador y la cámara
        transform.position += transform.right * speed * Time.deltaTime;
        cameraTransform.position += new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;


        //incremente velocidad con el tiempo y le pone un límite 
        if(speed < 15f){
            speed += speedIncrement* Time.deltaTime;
        }
        
        
    }





    //Detecta colisiones 
    void OnCollisionEnter2D(Collision2D other){

        Debug.Log("Colisionaste con " + other.gameObject.name);

        
        //Si choca con obstaculo muere
        if(other.gameObject.tag == "Obstacle"){
            
            dead = true;
  
            animator.SetTrigger("dead");

            
            gameManager.gameOver = true;
            
        }
        
        //Si choca con piso
        if(other.gameObject.tag == "Piso"){
            
           Debug.Log("Tocaste el piso");

           //Setea animación de "aterrizaje"
           animator.SetBool("jump", false);


           inGround = true; //deja que vuelva a saltar
           

            
        }
       
        
     
    }





}
