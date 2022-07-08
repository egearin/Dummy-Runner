using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Rigidbody rb;
    private float speed = 7f;
    private Touch touch;
    private bool ready = false;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (ready == true)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved && (transform.position.x > -10.2f && transform.position.x < 5f))
                {
                    transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * 0.004f, transform.position.y, transform.position.z);
                }
                if (transform.position.x <= -10.2f)
                {
                    transform.position = new Vector3(-10.1f, transform.position.y, transform.position.z);
                }
                if (transform.position.x >= 5f)
                {
                    transform.position = new Vector3(4.9f, transform.position.y, transform.position.z);
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            ready = true;
            animator.Play("Running");
        }
    }

    public Vector3 GetPos()
    {
        return transform.position + Vector3.forward;
    }

    //transform.position + Vector3.forward;
}
