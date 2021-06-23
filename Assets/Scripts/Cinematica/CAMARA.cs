using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CAMARA : MonoBehaviour
{
    public Animator anim;
    void Start() 
    {
        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.SetInt("tickets", 0);
        PlayerPrefs.Save();    
    }
    public void changescene()
    {
        anim.SetTrigger("go");
    }

    public void next()
    {
        SceneManager.LoadScene("Estudio");
    }
}
