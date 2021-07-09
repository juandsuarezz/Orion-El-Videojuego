using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CanvasORION : MonoBehaviour
{
    public GameObject pausemenu, feid, SceneMenu, noTickets, noCoins, noTrofeos;
    public Animator fadeAnim, songout;
    public AudioSource song;
    public string atraccionString, scenetoChange;
    public Animator fadeout;
    public Text atraccionText;
    public int ticketCost;
    public CounterScript counterScript;
    // Start is called before the first frame update
    void Start()
    {
        SceneMenu.SetActive(false);
        PlayerPrefs.SetInt("state", 1);
        PlayerPrefs.Save(); 
        feid.SetActive(true);
        noTickets.SetActive(false);
        noTrofeos.SetActive(false);
        noCoins.SetActive(false);
        pausemenu.SetActive(false);
        StartCoroutine("fadeFalse");
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1.5f + 172f);
        atraccionText.text = "¿Quieres Entrar a la atracción '" + atraccionString.ToString() + "'?\nEsta atracción cuesta " + ticketCost.ToString() + " Tickets";
        if(Input.GetKeyDown(KeyCode.P))
        {
            pausemenu.SetActive(true);
        }
        if(pausemenu.activeSelf)
        {
            Time.timeScale = 0;
            song.Pause();
            if(Input.GetKeyDown(KeyCode.Z))
            {
                Time.timeScale = 1;
                song.Play();
                pausemenu.SetActive(false);
            }
            if(Input.GetKeyDown(KeyCode.X))
            {
                Time.timeScale = 1;
                pausemenu.SetActive(false);
                SceneManager.LoadScene("MainMenu");
            }
        }
        if(SceneMenu.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                if(counterScript.tickets >= ticketCost)
                {
                    songout.SetTrigger("out");
                    SceneMenu.SetActive(false);
                    feid.SetActive(true);
                    fadeout.SetTrigger("fadeout");
                    StartCoroutine("changeScene");
                }
                else
                {
                    SceneMenu.SetActive(false);
                    noTickets.SetActive(true);
                }
            }
            if(Input.GetKeyDown(KeyCode.X))
            {
                SceneMenu.SetActive(false);
            }
        }
        if(noTickets.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                noTickets.SetActive(false);
            }
        }
        if(noCoins.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                noCoins.SetActive(false);
            }
        }
        if(noTrofeos.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                noTrofeos.SetActive(false);
            }
        }
    }
    public void EntrarAtraccion(string StringAtraccion)
    {
        atraccionString = StringAtraccion;
        SceneMenu.SetActive(true);
    }
    public void SetScene(string SceneGame)
    {
        scenetoChange = SceneGame;
    }
    public void SetTicketCost(int cost)
    {
        ticketCost = cost;
    }
    IEnumerator fadeFalse()
    {
        yield return new WaitForSeconds(1.4f);
        feid.SetActive(false);
    }
    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(2.4f);
        SceneManager.LoadScene(scenetoChange);
    }

    public void canjearTickets()
    {
        if(counterScript.coins >= 100)
        {
            counterScript.coins = counterScript.coins - 100;
            counterScript.tickets = counterScript.tickets + 1;
        }
        else
        {
            noCoins.SetActive(true);
        }
    }

    public void noTrofeosMenu()
    {
        if(counterScript.trofeos >= 6)
        {
            songout.SetTrigger("out");
            SceneMenu.SetActive(false);
            feid.SetActive(true);
            fadeout.SetTrigger("fadeout");
            StartCoroutine("changeScene");
        }
        else
        {
            noTrofeos.SetActive(true);
        }
    }
}