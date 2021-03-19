using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public Transform playGround;
    public GameObject missle;
    private float realTime;
    // Start is called before the first frame update
    void Start()
    {
        realTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxis("Horizontal");
        float newx;
        if(Time.timeScale == 0.25f)
        {
            newx = transform.position.x + (Time.deltaTime * speed * dir) / 0.75f;
        }
        else
        {
            newx = transform.position.x + (Time.deltaTime * speed * dir) / Time.timeScale;
        }

        float playGroundArea = playGround.localScale.x * 10;
        float paddelSize = transform.localScale.x * 1;

        float maxx = 0.5f * playGroundArea - 0.5f * paddelSize;
        float clamptx = Mathf.Clamp(newx, -maxx, maxx);
        if (Time.timeScale != 0) {
            transform.position = new Vector3(clamptx, transform.position.y, transform.position.z);
        }
        
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TextMesh missleText = GameObject.Find("currentMissel").GetComponent<TextMesh>();
            string text = missleText.text;
            int result = Int32.Parse(text);
            if (result != 0)
            {
                Vector3 misslePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                Instantiate(missle, misslePosition, Quaternion.identity);
                missleText.text = "" + (result - 1);
            }
        }

    }
}
