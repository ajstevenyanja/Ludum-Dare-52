using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float destroyTime;
        
    void Start()
    {
        // second argument in Destroy() : The optional amount of time to delay in seconds before destroying the object.
        Destroy(this.gameObject, destroyTime);
    }    
}
