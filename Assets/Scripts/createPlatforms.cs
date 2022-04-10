using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createPlatforms : MonoBehaviour
{   
    [SerializeField] private GameObject[] platformPrefab;//siendo array le podemos pasar mas de uno
    private int numberOfPlatforms;//elementos de la array

    [SerializeField] private Transform referencePoint;
    [SerializeField] private GameObject lastCreatedPlatfrom;
    [SerializeField] private float spaceBetweenPlatforms = 3f;
    
    float lastPlatformWidth;

    // public GameObject platformPrefab;
    // public Transform referentPoint;
    // public GameObject lastPlatform;

    void Start()
    {
        numberOfPlatforms=platformPrefab.Length;//pilla el size de la array
    }

    void Update(){

        float spaceRandom=Random.Range(6, 8);
        if (lastCreatedPlatfrom.transform.position.x < referencePoint.position.x) {            
            Vector3 targetCreationPoint = new Vector3(
                        referencePoint.position.x + lastPlatformWidth + spaceRandom,
                        0,
                        0);

            int randomPlatform = Random.Range(0, numberOfPlatforms);//numero random      

            lastCreatedPlatfrom = Instantiate(platformPrefab[randomPlatform], targetCreationPoint, Quaternion.identity);//crea una plataforma     
            
            BoxCollider2D collider = lastCreatedPlatfrom.GetComponent<BoxCollider2D>();            
            lastPlatformWidth = collider.bounds.size.x; //anchura de la plataforma       
        }
    }
}
