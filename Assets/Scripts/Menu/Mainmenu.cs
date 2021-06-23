using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1.5f);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("go");
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            Application.Quit();
        }
    }
    public void changeScene()
    {
        SceneManager.LoadScene("Carga1");
    }
}
