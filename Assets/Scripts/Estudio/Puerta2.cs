using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puerta2 : MonoBehaviour
{
    public GameObject player, puerta2canvas;
    public Text puerta2text;
    public levelManager managerscript;
    public Animator anim;
    public bool abierta;

    void Start() 
    {
        abierta = false;
        puerta2canvas.SetActive(false);
        puerta2text.text = "Z → Abrir Puerta";
    }
    void Update()
    {
        if (managerscript.menesCanvas == true)
        {
            if (player.transform.position.x > -2.8 && player.transform.position.x < 1.6
            && player.transform.position.z > -6.8 && player.transform.position.z < -3.4)
            {
                puerta2canvas.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Z))
                {
                    if (!abierta)
                    {
                        anim.SetTrigger("abrir");
                        abierta = true;
                        puerta2text.text = "Z → Cerrar Puerta";
                    }
                    else
                    {
                        anim.SetTrigger("cerrar");
                        abierta = false;
                        puerta2text.text = "Z → Abrir Puerta";
                    }
                }
            }
            else 
            {
                puerta2canvas.SetActive(false);
            }
        }
    }
}
