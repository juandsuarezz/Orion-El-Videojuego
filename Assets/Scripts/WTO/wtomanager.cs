using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wtomanager : MonoBehaviour
{
    public RocketController player;
    public CanvasWTO canvasWTO;
    public GameObject asteroide, finalTicket;
    public bool power, end;
    void Start()
    {
        StartCoroutine("endAsteroids");
        power = true;
        end = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(power && player.canMove && !end)
        {
            StartCoroutine("agregarAsteroides");
            power = false;
        }
    }
    IEnumerator agregarAsteroides()
    {
        yield return new WaitForSeconds(0.6f);
        Instantiate(asteroide, new Vector3 (29.5f, Random.Range(-2f, 19f), 0), 
        Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
        power = true;
    }
    IEnumerator endAsteroids()
    {
        yield return new WaitForSeconds(94);
        end = true;
        StartCoroutine("showTicket");
    }
    IEnumerator showTicket()
    {
        yield return new WaitForSeconds(3);
        Instantiate(finalTicket, new Vector3 (30, 8.5f, 0), Quaternion.Euler(0, 0, -180));
        StartCoroutine("showFinalTimer");
    }
    IEnumerator showFinalTimer()
    {
        yield return new WaitForSeconds(5);
        canvasWTO.showFinalMenu();
    }
}
