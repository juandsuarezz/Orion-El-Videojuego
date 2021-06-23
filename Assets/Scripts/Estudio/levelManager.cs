using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public GameObject player, menestexto, menesdialogo, 
    cohetetexto, sinticket, conticket;
    public PlayerController playerScript;
    public CounterScript counterScript;
    public Animator fadeanim, sound1, sound2;
    public bool menesCanvas;
    void Start()
    {
        
        sinticket.SetActive(false);
        conticket.SetActive(false);
        cohetetexto.SetActive(false);
        menesCanvas = false;
        menestexto.SetActive(false);
        menesdialogo.SetActive(false);
        playerScript = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 2.5f);
        if(!menesCanvas && playerScript.canMove)
        {
            hablarconmenes();
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.X) && player.transform.position.x < 0.5 && (player.transform.position.z > 0.1 &&
        player.transform.position.z < 0.8))
            {
                menesdialogo.SetActive(false);
                playerScript.canMove = true;
            }
        }
        coheteCanvas();
        aOrion();
    }

    void hablarconmenes()
    {
        if(player.transform.position.x < 0.5 && (player.transform.position.z > 0.1 &&
        player.transform.position.z < 0.8) && playerScript.canMove)
        {
            menestexto.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Z))
            {
                playerScript.canMove = false;
                menesCanvas = true;
                menestexto.SetActive(false);
                menesdialogo.SetActive(true);
            }
        }

        else
        {
            menestexto.SetActive(false);
        }
    }

    void coheteCanvas()
    {
        if(player.transform.position.z < -1.5 && (player.transform.position.x > 5 &&
        player.transform.position.x < 10) && playerScript.canMove)
        {
            cohetetexto.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Z))
            {
                playerScript.canMove = false;
                cohetetexto.SetActive(false);
                if(counterScript.tickets != 1)
                {
                    sinticket.SetActive(true);
                }

                else
                {
                    conticket.SetActive(true);
                }
            }
        }

        else
        {
            cohetetexto.SetActive(false);
        }

        if((sinticket.activeSelf || conticket.activeSelf) && Input.GetKeyDown(KeyCode.X))
        {
            cohetetexto.SetActive(false);
            conticket.SetActive(false);
            sinticket.SetActive(false);
            playerScript.canMove = true;
        }
    }
    void aOrion()
    {
        if(conticket.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {   
                sound1.SetTrigger("sound1");
                sound2.SetTrigger("sound2");
                fadeanim.SetTrigger("fadeout");
                conticket.SetActive(false);
                cohetetexto.SetActive(false);
                playerScript.canMove = false;
                StartCoroutine("rocket");
            }
        }
    }

    IEnumerator rocket()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Carga2");
    }
}
