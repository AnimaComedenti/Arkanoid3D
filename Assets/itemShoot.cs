using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemShoot : MonoBehaviour
{
    public float maxZ;
    public int maxMissiles;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0, -maxZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        string tagname = other.tag;
        if (tagname == "outGoal")
        {
            Destroy(gameObject);
        }
        if (tagname == "player")
        {
            GetComponent<AudioSource>().Play();
            TextMesh missleText = GameObject.Find("currentMissel").GetComponent<TextMesh>();
            string text = missleText.text;
            int result = Int32.Parse(text);
            if (result < maxMissiles)
            {
                missleText.text = "" + (result + 1);
            }
            Destroy(gameObject);
        }
    }
}
