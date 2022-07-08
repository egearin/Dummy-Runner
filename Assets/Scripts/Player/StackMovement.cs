using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackMovement : MonoBehaviour
{

    public Transform connectedStack;
    //public float stackSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, connectedStack.transform.position.x, Time.deltaTime * 20), 
            connectedStack.position.y, 
            connectedStack.position.z + 1);
    }
}
