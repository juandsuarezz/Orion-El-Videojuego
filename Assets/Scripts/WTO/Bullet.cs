using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 25f;
        StartCoroutine("destruir");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
    }

    IEnumerator destruir()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(this.gameObject);
    }
}
