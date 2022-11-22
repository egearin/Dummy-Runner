using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Collision(Collider other)
    {
        if (other.gameObject.CompareTag("Collected") || other.gameObject.CompareTag("Chibi"))
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }

}
