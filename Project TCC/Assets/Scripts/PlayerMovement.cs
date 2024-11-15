using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    CharacterController controller;
    public float speed;
    private float originalSpeed;
    Vector3 move;

    [Header("Gravity")]
    public float gravityIncrease;
    public float gravityLimit;
    private float gravity;
    public float jumpForce;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        originalSpeed = speed;
    }

    void Update()
    {
        move = Vector3.zero;

        if(Input.GetAxisRaw("Vertical") != 0 && Input.GetAxisRaw("Horizontal") != 0 && speed == originalSpeed)
            speed /= 2;
        else
        {
            if(speed != originalSpeed)
                speed = originalSpeed;
        }


        move += transform.forward * Input.GetAxisRaw("Vertical") * speed;
        move += transform.right * Input.GetAxisRaw("Horizontal") * speed;

        if(controller.isGrounded)
        {
            gravity = 0;
            if (Input.GetButton("Jump"))
            {
                gravity = jumpForce;
            }
        }
        else
        {
            if(gravity > -gravityLimit)
                gravity -= gravityIncrease;
        }

        move.y += gravity;

        controller.Move(move * Time.deltaTime);
    }
}
