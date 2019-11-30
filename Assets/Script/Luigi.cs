using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luigi : MonoBehaviour
{
    public float speed;
    public float speed2;
    public static float totalSpeed;
    float acceleration = 10;
    float maxSpeed = 5;
    float maxSink = -2f;
    
    public float jumpForce = 6;
    private Vector3 velocity;


    public enum LuigiStates {Land,Swim }
    public static LuigiStates currentStates;

    private void Start()
    {
        currentStates = LuigiStates.Land;
    }

    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionZ = Input.GetAxisRaw("Vertical");

        speed = Mathf.MoveTowards(speed, maxSpeed * directionX, acceleration * Time.deltaTime);
        speed2 = Mathf.MoveTowards(speed2, maxSpeed * directionZ, acceleration * Time.deltaTime);

        totalSpeed = speed + speed2;
        Vector3 moveAmount = Vector3.right * speed * Time.deltaTime + Vector3.forward * speed2 * Time.deltaTime;
        CharacterController controller = GetComponent<CharacterController>();

       

        if (currentStates == LuigiStates.Land)
        {
            if (controller.isGrounded)
            {
                velocity = Vector3.zero;
                Jump();
            }

            velocity += Vector3.down * Time.deltaTime;
            controller.Move(moveAmount + velocity);
        }

        if (currentStates == LuigiStates.Swim)
        {
            if (velocity.y >= maxSink)
            {
                velocity += Vector3.down* 0.05f * Time.deltaTime;
            }

            if (controller.isGrounded)
            {
                velocity = Vector3.zero;

            }
            Floating();
            controller.Move(moveAmount + velocity);
            
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity += Vector3.up * jumpForce * Time.deltaTime;
        }
    }
    
    private void Floating()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity += Vector3.up * 3f * Time.deltaTime; 
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "AirBlock")
        {
            hit.transform.SendMessage("OnHit", SendMessageOptions.DontRequireReceiver);
            if (velocity.y >0)
            {
                velocity = Vector3.zero;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "water")
        {
            velocity = Vector3.zero;
            currentStates = LuigiStates.Swim;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "water")
        {
            currentStates = LuigiStates.Land;
        }
    }
}
