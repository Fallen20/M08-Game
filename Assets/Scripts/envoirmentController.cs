using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class envoirmentController : MonoBehaviour
{
	[SerializeField] GameObject[] environmentElement;
 	[SerializeField] Transform referencePoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnvironmentELement());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreateEnvironmentELement() {
    	int randomPlatform = Random.Range(0, environmentElement.Length);//numero random 


    	Instantiate(environmentElement[randomPlatform], referencePoint.position, Quaternion.identity);
 		yield return new WaitForSeconds((Random.Range(3, 7)));//waitForSeconds es que espera X segundos para hacer un return
 		StartCoroutine(CreateEnvironmentELement());
    }
}
