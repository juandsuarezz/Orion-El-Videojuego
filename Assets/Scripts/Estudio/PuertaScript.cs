using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuertaScript : MonoBehaviour
{
    public GameObject player, puerta1canvas;
    public Text puerta1text;
    public levelManager managerscript;
    public Animator anim;
    public bool abierta;

    void Start() 
    {
        abierta = false;
        puerta1canvas.SetActive(false);
        puerta1text.text = "Z → Abrir Puerta";
    }
    void Update()
    {
        if (managerscript.menesCanvas == true)
        {
            if (player.transform.position.x > 1.9 && player.transform.position.x < 6.3
            && player.transform.position.z > 0.3 && player.transform.position.z < 4)
            {
                puerta1canvas.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Z))
                {
                    if (!abierta)
                    {
                        anim.SetTrigger("abrir1");
                        abierta = true;
                        puerta1text.text = "Z → Cerrar Puerta";
                    }
                    else
                    {
                        anim.SetTrigger("cerrar1");
                        abierta = false;
                        puerta1text.text = "Z → Abrir Puerta";
                    }
                }
            }
            else 
            {
                puerta1canvas.SetActive(false);
            }
        }
    }
}
