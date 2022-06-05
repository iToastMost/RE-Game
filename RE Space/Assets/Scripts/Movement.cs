using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float turnSpeed = 2f;
    [SerializeField] private float backSpeed = 2f;
    [SerializeField] private float runSpeed = 4f;

    //private bool isRunning = false;

    public Animator animator;

    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += Time.deltaTime * moveSpeed * transform.forward;
        
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            transform.position += Time.deltaTime * runSpeed * transform.forward;
        
        if (Input.GetKey(KeyCode.S))
            transform.position += Time.deltaTime * backSpeed * -transform.forward;

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Time.deltaTime * turnSpeed * -Vector3.up);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Time.deltaTime * turnSpeed * Vector3.up);

        animator.SetFloat("moveSpeed", Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

    }
}
