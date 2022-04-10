using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rigid;
    private BoxCollider2D collider;
    public bool onFloor=false;
    public Animator animator;
    [SerializeField] controller controller;
    //[SerializeField] private Transform raycastOrigin;
    public GameObject escudo;
    

    //musica
    [SerializeField] AudioSource musicControl;
    public AudioClip coinMusic;
    public AudioClip doubleCoinMusic;

    public AudioClip jumpMusic;
    public AudioClip doubleJumpMusic;
    public AudioClip landMusic;
    
    public AudioClip hitMusic;
    
    public AudioClip shieldMusic;
    public AudioClip shieldBrokenMusic;

    //variables normales
    bool powerUp=false;
    bool jumpBool;
    public float jumpHigh=10f;
    private bool secondJump=false;
    private bool first=true;
    private bool jumped=false;

    //acceden otros
    public static int puntos=0;
    public static float distanceTraveled=0f;
    public static bool doubleCoins=false;


    void Start(){
        ///pillar los componentes de player
        rigid=GetComponent<Rigidbody2D>();
        collider=GetComponent<BoxCollider2D>();

        //al principio corre
        animator.SetBool("isRunning", true);

        //desactivar el escudo
        escudo.SetActive(false);

    }

    
    void Update(){

        distanceTraveled+=Time.deltaTime;

    	 //si apretas espacio, estas en el suelo...
    	//como es el primero secondJump es falso
    	if(Input.GetKeyDown("space") && onFloor==true && secondJump==false){//primer salto
            rigid.AddForce(new Vector2(0,jumpHigh), ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false); 

            musicControl.clip=jumpMusic;
            musicControl.Play();

            first=false;
            jumped=true;

        }
        //si apretas espacio, no estas en el suelo pero puede saltar dos veces...
        if(Input.GetKeyDown("space") && onFloor==false && secondJump==true){//segundo salto
			rigid.AddForce(new Vector2(0,jumpHigh), ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);

        	secondJump=false;//reset
        	jumped=true;

            musicControl.clip=doubleJumpMusic;
            musicControl.Play();
        }

        if(Input.GetKeyUp("space") && onFloor==false){//estas cayendo
            animator.SetBool("isJumping", false);
            animator.SetBool("isRunning", false);
        }

        if(onFloor==true && !Input.anyKey){//si estas en el suelo y no tocas nada (aka solo corres)
           animator.SetBool("isRunning", true);
           animator.SetBool("isJumping", false);
           secondJump=false;//reset

           if(first==false && jumped==true){//has caido
           	 jumped=false;
           	 musicControl.clip=landMusic;
           	 musicControl.Play();
           }
       }


       
    	//CheckForInput();
    }

    /*void FixedUpdate(){
        if (jumpBool == true){
            jumpBool = false;
            rigid.AddForce(new Vector2(0, jumpHigh), ForceMode2D.Impulse);
        }
        CheckForGrounded();
    }*/



	public void OnCollisionEnter2D(Collision2D objetoTocando){

       
         if(objetoTocando.gameObject.tag=="plataforma"){
             onFloor=true;
             secondJump=false;//estas en el suelo, no puedes saltar dos veces
         }

        if(objetoTocando.gameObject.tag=="obstaculo"){//si te chocas y no tienes escudo = OVER
            if(powerUp==false){
                controller.showGameOverScreen();//muestra la pantalla de game over
                
                musicControl.clip=hitMusic;
                musicControl.Play();
            }

            else if(powerUp==true){
                Destroy(objetoTocando.gameObject);//destruyes el obstaculo

                escudo.SetActive(false);//te quitas el escudo

                powerUp=false;//te quitas el powerup

                musicControl.clip=shieldBrokenMusic;;
                musicControl.Play();
            }
            
        }

        if(objetoTocando.gameObject.tag=="levelEnder"){
            controller.showGameOverScreen();//muestra la pantalla de game over
        }

         
     }

     public void OnCollisionExit2D(Collision2D objetoTocando){

         if(objetoTocando.gameObject.tag=="plataforma"){
             onFloor=false;
             secondJump=true;//estas en el aire, puedes saltar de nuevo
         }
     }


     private void OnTriggerEnter2D(Collider2D objetoTocando){

         if(objetoTocando.gameObject.tag=="coleccionable"){

            Destroy(objetoTocando.gameObject);

            musicControl.clip=coinMusic;
            musicControl.Play();

            if(doubleCoins==true){
                puntos+=2;
            }
            else if(doubleCoins==false){puntos+=1;}
            
         }

         if(objetoTocando.gameObject.tag=="shieldUp"){//tienes escudo
            powerUp=true;
            escudo.SetActive(true);

            Destroy(objetoTocando.gameObject);

            musicControl.clip=shieldMusic;;
            musicControl.Play();
            
         }    

         if(objetoTocando.gameObject.tag=="powerUp"){

            musicControl.clip=doubleCoinMusic;;
            musicControl.Play();

            
            doubleCoins=true;
            Destroy(objetoTocando.gameObject);

            Invoke("doubleTimeUp", 20);//al cabo de 20seg se quita el bonus
            
         }  


     }

     void doubleTimeUp(){doubleCoins=false;}


    // void CheckForInput(){
    //     if(onFloor){
    //         if (Input.GetKeyDown(KeyCode.Space)){
    //             jumpBool=true;
    //         }
    //     }
    // }

    // void CheckForGrounded(){
    //      RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

    //     if (hit.collider != null){//no te chocas con nada
    //         if (hit.distance <0.1f){
    //             onFloor = true;
    //         }
    //         else{
    //             onFloor = false;
    //         }
    //     }

    // }
}
