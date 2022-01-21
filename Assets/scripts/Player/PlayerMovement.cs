using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controller;
    public float MovementSpeed= 12f;
    public float Sprong = 1f;
    public float gravity = -10f;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;

    Vector3 Velocity;
    bool Grounded;

    void Update()
    {
        // maakt een kleinde sphere onder het object en zorgt ervoor dat als dat met iets colide dat het true word zo niet word het false
        Grounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);
        
        if(Grounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }
        if(Input.GetButtonDown("Jump")&& Grounded)
        {
            Velocity.y = Mathf.Sqrt(Sprong * -2f * gravity);
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Controller.Move(move * MovementSpeed * Time.deltaTime);
        Velocity.y += gravity * Time.deltaTime;
        Controller.Move(Velocity * Time.deltaTime);

    }
}
