using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPC : MonoBehaviour
{
    public Vector3 offset;
    [Range(0, 100)] public float lerpValue;
    public Transform target;
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
        if(target.transform.position.z <= 3.3f)
        {

        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y , 7.4f);
        }
    }
}
