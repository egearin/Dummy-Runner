using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collect"))
        {
            other.gameObject.transform.position = PlayerController.instance.GetPos();
            Destroy(gameObject.GetComponent<CollectController>());
            other.gameObject.AddComponent<CollectController>();
            other.gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
            other.gameObject.AddComponent<CameraFollowUp>();
            other.gameObject.AddComponent<StackMovement>();
            other.gameObject.GetComponent<StackMovement>().connectedStack = transform;
            other.gameObject.tag = ("Collected");
        }
    }
}
