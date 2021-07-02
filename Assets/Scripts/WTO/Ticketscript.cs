using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticketscript : MonoBehaviour
{
    void Update()
    {
        transform.position = transform.position + new Vector3(-10f * Time.deltaTime, 0, 0);
    }
}
