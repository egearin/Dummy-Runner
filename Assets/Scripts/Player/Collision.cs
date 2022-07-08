using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool setFalse = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Chibi")
        {
            if (!JoinRush.instance.chibis.Contains(other.gameObject))
            {
                other.GetComponent<CapsuleCollider>().isTrigger = setFalse;
                other.gameObject.tag = "Untagged";
                other.gameObject.AddComponent<Collision>();
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                JoinRush.instance.StackChibi(other.gameObject, JoinRush.instance.chibis.Count - 1);
            }
        }
    }
}
