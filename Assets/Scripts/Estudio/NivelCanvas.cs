using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class NivelCanvas : MonoBehaviour
{
    public GameObject panel, pausemenu, feid;
    public AudioSource musicAudio, streetAudio;
    public PlayerController player;
    public VideoPlayer screen1, screen2;
    void Start()
    {
        feid.SetActive(true);
        Time.timeScale = 1;
        player.canMove = false;
        panel.SetActive(false);
        pausemenu.SetActive(false);
        StartCoroutine("n1");
        musicAudio.Play();
        streetAudio.Play();
        screen1.Play();
        screen2.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(panel.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
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
            musicAudio.Pause();
            streetAudio.Pause();
            screen1.Pause();
            screen2.Pause();
            player.canMove = false;
            if(Input.GetKeyDown(KeyCode.Z))
            {
                Time.timeScale = 1;
                musicAudio.Play();
                streetAudio.Play();
                screen1.Play();
                screen2.Play();
                player.canMove = true;
                pausemenu.SetActive(false);
            }
            if(Input.GetKeyDown(KeyCode.X))
            {
                pausemenu.SetActive(false);
                Time.timeScale = 1;
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
