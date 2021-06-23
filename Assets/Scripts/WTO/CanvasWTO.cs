using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasWTO : MonoBehaviour
{
    public GameObject panel, pausemenu, feid;
    public AudioSource song;
    public Animator barAnim;
    public RocketController player;
    void Start()
    {
        feid.SetActive(true);
        player.canMove = false;
        panel.SetActive(false);
        pausemenu.SetActive(false);
        StartCoroutine("n1");
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    IEnumerator n1()
    {
        yield return new WaitForSeconds(2);
        panel.SetActive(true);
    }
}
