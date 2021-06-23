using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int coins, tickets;
    public Text coinText, ticketText;

    void Start()
    {
        coins = PlayerPrefs.GetInt("coins");
        tickets = PlayerPrefs.GetInt("tickets");
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "$" + coins.ToString();
        ticketText.text = tickets.ToString();
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("tickets", tickets);
        PlayerPrefs.Save();
    }
}
