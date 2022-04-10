using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField] Transform player;//solo este scrript puede cambiar los valores, si uno hereda no puede
    [SerializeField] Vector3 cameraVelocity;
    [SerializeField] float smothTime = 1f;
    [SerializeField] bool lookAtPlayer;
    [SerializeField] int lowerLimit=0; //que tan abajo puede llegar
    [SerializeField] float offset = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     if(player.position.y>lowerLimit) {//si no esta por debajo del limite de abajo (no ha caido)
         Vector3 tarjet=new Vector3(transform.position.x, player.position.y+offset, transform.position.z);

         //cambia la posicion
         transform.position=Vector3.SmoothDamp(transform.position, tarjet, ref cameraVelocity, smothTime);
         //el transform afecta al objeto a quien se le asigna

         if(lookAtPlayer==true){
             transform.LookAt(player);
         }
     }  

    }
}
