using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour
{
    public float movePlatformSpeed=2f;
    public float movementPlatform=-2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=new Vector3(movementPlatform,0,0)*movePlatformSpeed*Time.deltaTime;

        if(transform.position.x<-40){Destroy(gameObject);}
    }
}
