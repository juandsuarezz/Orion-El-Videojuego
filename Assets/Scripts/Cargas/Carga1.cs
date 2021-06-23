using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Carga1 : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(true);
        StartCoroutine("n1");
    }

    IEnumerator n1()
    {
        yield return new WaitForSeconds(2);
        panel.SetActive(false);
        StartCoroutine("n2");
    }

    IEnumerator n2()
    {
        yield return new WaitForSeconds(6);
        panel.SetActive(true);
        StartCoroutine("n3");
    }

    IEnumerator n3()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Cinematic");
    }

}
