using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public float speed, asteroideScale;
    public CounterScript counterScript;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        counterScript = FindObjectOfType<CounterScript>();
        asteroideScale = Random.Range(1f, 4f);
        transform.localScale = new Vector3(asteroideScale, asteroideScale, asteroideScale);
        speed = Random.Range(-20f, -5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        if(transform.position.x <= -32)
        {
            Destroy(this.gameObject);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));
            counterScript.coins = counterScript.coins + 1;
            counterScript.temporalCoins = counterScript.temporalCoins + 1;
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(this.gameObject);
        }
    }
}
