using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int coins, tickets, vidaMax, temporalCoins, temporalTickets;
    [Range(0, 100)] public float vidaActual;
    public Text coinText, ticketText;
    public Image barraVida;
    void Start()
    {
        temporalTickets = 0;
        temporalCoins = 0;
        vidaMax = 100;
        coins = PlayerPrefs.GetInt("coins");
        tickets = PlayerPrefs.GetInt("tickets");
        vidaActual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "$" + coins.ToString();
        ticketText.text = tickets.ToString();
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("tickets", tickets);
        PlayerPrefs.Save();
        RevisarVida();
    }

    public void RevisarVida()
    {
        barraVida.fillAmount = vidaActual / vidaMax;
        if(vidaActual <= 100 && vidaActual >= 67)
        {
            barraVida.color = Color.green;
        }
        else if(vidaActual <= 70 && vidaActual >= 34)
        {
            barraVida.color = Color.yellow;
        }
        else
        {
            barraVida.color = Color.red;
        }
    }
}
