using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainsound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }
}
