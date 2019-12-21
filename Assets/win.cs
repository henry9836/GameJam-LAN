using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Target")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
