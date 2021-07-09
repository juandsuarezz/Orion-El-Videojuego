using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public Animator anim;
    public int state;
    public GameObject counter, canvas1, canvas2;
    void Start()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        state = PlayerPrefs.GetInt("state");
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1.5f);
        if(state == 0)
        {
            canvas1.SetActive(true);
            canvas2.SetActive(false);
            counter.SetActive(false);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("go");
            }
            if(Input.GetKeyDown(KeyCode.X))
            {
                Application.Quit();
            }
        }

        if(state == 1)
        {
            canvas1.SetActive(false);
            canvas2.SetActive(true);
            counter.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("go2");
            }
            if(Input.GetKeyDown(KeyCode.X))
            {
                Application.Quit();
            }
            if(Input.GetKeyDown(KeyCode.Z))
            {
                anim.SetTrigger("go");
            }
        }
    }
    public void changeScene()
    {
        SceneManager.LoadScene("Carga1");
    }

    public void changeScene2()
    {
        SceneManager.LoadScene("Carga3");
    }
}
