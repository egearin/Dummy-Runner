using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float swipeSpeed = 100;
    public float moveSpeed = 100;
    private Vector3 mousePos;
    private Vector3 hitVector;
    private Ray ray;
    private RaycastHit hit;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject firstChibi;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            Move();
        }

       
    }

    public void Move()
    {
        mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;
        ray = cam.ScreenPointToRay(mousePos);
        
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            firstChibi = JoinRush.instance.chibis[0];
            hitVector = hit.point;
            hitVector.y = firstChibi.transform.localPosition.y;
            hitVector.z = firstChibi.transform.localPosition.z;
            firstChibi.transform.localPosition = Vector3.MoveTowards(firstChibi.transform.localPosition, hitVector, Time.deltaTime * swipeSpeed);
        }

    }
}
