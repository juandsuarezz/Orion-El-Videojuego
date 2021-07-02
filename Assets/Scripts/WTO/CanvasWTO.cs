using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasWTO : MonoBehaviour
{
    public GameObject panel, pausemenu, feid, gameovermenu, finalmenu;
    public Text monedasFinales, ticketsFinales;
    public AudioSource song;
    public Animator barAnim, fadeAnim;
    public CounterScript counterScript;
    public RocketController player;
    void Start()
    {
        finalmenu.SetActive(false);
        gameovermenu.SetActive(false);
        feid.SetActive(true);
        player.canMove = false;
        panel.SetActive(false);
        pausemenu.SetActive(false);
        StartCoroutine("n1");
    }

    // Update is called once per frame
    void Update()
    {
        if(counterScript.vidaActual <= 0)
        {
            gameovermenu.SetActive(true);
        }

        if(gameovermenu.activeSelf)
        {
            Time.timeScale = 0;
            song.Pause();
            player.canMove = false;
            if(Input.GetKeyDown(KeyCode.Z))
            {
                counterScript.coins = counterScript.coins - counterScript.temporalCoins;
                counterScript.tickets = counterScript.tickets - counterScript.temporalTickets;
                PlayerPrefs.SetInt("coins", counterScript.coins);
                PlayerPrefs.SetInt("tickets", counterScript.tickets);
                PlayerPrefs.Save();
                Time.timeScale = 1;
                SceneManager.LoadScene("WelcomeToOrion");
            }
            if(Input.GetKeyDown(KeyCode.X))
            {
                Time.timeScale = 1;
                pausemenu.SetActive(false);
                SceneManager.LoadScene("MainMenu");
            }
        }

        if(panel.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                barAnim.SetTrigger("start");
                song.Play();
                player.canMove = true;
                panel.SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.P) && player.canMove)
        {
            pausemenu.SetActive(true);
        }
        if(pausemenu.activeSelf)
        {
            Time.timeScale = 0;
            song.Pause();
            player.canMove = false;
            if(Input.GetKeyDown(KeyCode.Z))
            {
                Time.timeScale = 1;
                song.Play();
                player.canMove = true;
                pausemenu.SetActive(false);
            }
            if(Input.GetKeyDown(KeyCode.X))
            {
                Time.timeScale = 1;
                pausemenu.SetActive(false);
                SceneManager.LoadScene("MainMenu");
            }
        }

        if(finalmenu.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                fadeAnim.SetTrigger("fadeout");
                StartCoroutine("fadeout");
            }
        }
    }

    IEnumerator n1()
    {
        yield return new WaitForSeconds(2);
        panel.SetActive(true);
    }

    public void showFinalMenu()
    {
        player.finalAnim = true;
        finalmenu.SetActive(true);
        player.canMove = false;
        monedasFinales.text = "+ $" + counterScript.temporalCoins.ToString();
        ticketsFinales.text = "+ " + counterScript.temporalTickets.ToString();
    }

    IEnumerator fadeout()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Carga3");
    }
}
