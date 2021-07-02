using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public CounterScript counterScript;
    public CharacterController controller;
    public GameObject bullet, limit;
    private float playerSpeed, x, y;
    public bool canMove, finalAnim;

    private void Start()
    {
        limit.SetActive(true);
        finalAnim = false;
        playerSpeed = 20f;
    }

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 2f);

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, y, 0);

        if(canMove)
        {
            controller.Move(move * Time.deltaTime * playerSpeed);

            Vector3 bulletPosition = new Vector3 (transform.position.x + 3.33f, transform.position.y, 0);

            if(Input.GetKeyDown(KeyCode.Z))
            {
                Instantiate(bullet, bulletPosition, Quaternion.Euler (-180f, -90f, 0f));
            }
        }

        if(finalAnim)
        {
            if(transform.position.x > 30)
            {
                Destroy(this.gameObject);
            }
            x = 0;
            y = 0;
            transform.position = transform.position + new Vector3(15f * Time.deltaTime, 0, 0);
            limit.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            counterScript.vidaActual = counterScript.vidaActual - 10;
        }

        if (other.tag == "Ticket")
        {
            Destroy(other.gameObject);
            counterScript.tickets = counterScript.tickets + 1;
            counterScript.temporalTickets = counterScript.temporalTickets + 1;
        }
    }
}
