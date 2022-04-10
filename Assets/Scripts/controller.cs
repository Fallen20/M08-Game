using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class controller : MonoBehaviour
{
	[SerializeField] Text distanceTraveled;
	[SerializeField] Text pointsGot;
	public Canvas retryCanvas;
	
	[SerializeField] AudioSource musicControl;
	public AudioClip gameOverMusic;
	public AudioClip normalMusic;

	//maneras de coger las variables de otros:
	//hacer lo de abajo y pillas el objeto player (tag creo)
	 // [SerializeField] Player player; 

	public void Start(){

		///oculta
		retryCanvas.GetComponent<Canvas>().enabled = false;

	}

	public void showGameOverScreen(){ 

		musicControl.clip=gameOverMusic;
		musicControl.Play();
		//Debug.Log("over");
		//muestra el canvas
		retryCanvas.GetComponent<Canvas>().enabled = true;
		

		//manera 2
		//haces la variable public y accedes
		//quitar decimales
		float redondeado = Mathf.Ceil(PlayerScript.distanceTraveled);
 		distanceTraveled.text = redondeado.ToString();

 		pointsGot.text=PlayerScript.puntos.ToString();

		 //con este salen decimales
		 //distanceTraveled.text=PlayerScript.distanceTraveled.ToString();//cambia

		// distanceTraveled.text=player.distanceTraveled.ToString();//cambia
		
	}

   public void GameRestart(){

   		musicControl.clip=normalMusic;
		musicControl.Play();
   		//Debug.Log("Restart game");
   		//reset variables
   		PlayerScript.puntos=0;
   		PlayerScript.distanceTraveled=0f;
   		PlayerScript.doubleCoins=false;

   		//carga escena
   		SceneManager.LoadScene("SampleScene");

   		//oculta canvas
   		retryCanvas.GetComponent<Canvas>().enabled = false;
   }
}
