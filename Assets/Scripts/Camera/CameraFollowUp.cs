using UnityEngine;
using System.Collections;

public class CameraFollowUp : MonoBehaviour
{

    private GameObject chibi;
    public Transform target;
    public Vector3 camOffset;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + camOffset, Time.deltaTime * 2);    

    }
    
    /*void LateUpdate()
    {

        transform.position = chibi.transform.position + camOffset;
    }*/
}