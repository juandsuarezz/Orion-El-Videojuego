using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float x, z, speed = 4f, gravity = 9.8f;
    public CharacterController player;
    public Animator animator;
    public CounterScript counterScript;

    public Camera mainCam;
    private Vector3 camForward, camRight, movePlayer, playerInput;
    public bool canMove;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        playerInput = new Vector3(x, 0, z);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        if(canMove)
        {
            movePlayer = playerInput.x * camRight + playerInput.z * camForward;
            player.transform.LookAt(player.transform.position + movePlayer);
            movePlayer.y = -gravity * Time.deltaTime;
            player.Move(movePlayer * speed * Time.deltaTime);
            Animations();
            animator.SetFloat("vel", speed);
        }

        else
        {
            speed = 0f;
            animator.SetFloat("vel", speed);
        }
    }

    void camDirection()
    {
        camForward = mainCam.transform.forward;
        camRight = mainCam.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    public void Animations()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)
        || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow)
        || Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.RightArrow))
        {
            if(Input.GetKey(KeyCode.X))
            {
                speed = 6f;
            }
            else
            {
                speed = 3.5f;
            }
        }
        else
            {
                speed = 0f;
            }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            counterScript.coins = counterScript.coins + 100;
        }

        if (other.tag == "Ticket")
        {
            Destroy(other.gameObject);
            counterScript.tickets = counterScript.tickets + 1;
        }
    }
}
