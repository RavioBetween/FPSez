using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public CharacterController charContr;

    private float xDir;
    private float yDir;
    private float zDir;
    private Vector3 moveDirection;
    public float speed = 15f;
    private bool isGrounded;
    public Transform grandCheck;
    public float jump = 2f;
    public float grounDist = 0.3f;
    public LayerMask groundLayer; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(grandCheck.position, grounDist, groundLayer);
        if (isGrounded && yDir < 0)
        {
            yDir = -2f;
        }
        xDir = Input.GetAxis("Horizontal");
        zDir = Input.GetAxis("Vertical");
        yDir += Physics.gravity.y * Time.deltaTime;
            moveDirection = transform.right * xDir * speed + transform.forward * zDir * speed + transform.up * yDir;
        charContr.Move(moveDirection * Time.deltaTime);
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            yDir = Mathf.Sqrt(jump * -2f * Physics.gravity.y);
        }
    }
}
