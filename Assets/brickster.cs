using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class brickster : MonoBehaviour
{
    public int maxbounces;
    public int score;

    private Color red;
    private Color magenta;
    private Color yellow;
    // Start is called before the first frame update
    void Start()
    {
        red = new Color(255, 0, 0);
        magenta = new Color(255, 0, 201);
        yellow = new Color(243, 228, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        maxbounces--;
        Material material = GetComponent<Renderer>().material;
        TextMesh scoreText = GameObject.Find("currentScore").GetComponent<TextMesh>();
        string text = scoreText.text;
        switch (maxbounces)
        {
            case 4: 
                material.SetColor("_Color", magenta);
                break;
            case 3:
                material.SetColor("_Color", red);
                break;
            case 2:
                material.SetColor("_Color", yellow);
                break;
            case 1:
                material.SetColor("_Color", Color.green);
                break;
            case 0:

                /*TODO: Verschiebung nach dem Einfügen der Zahl*/
                int result = Int32.Parse(text);
                scoreText.text = "" + (result + score);
                Destroy(gameObject);
                break;
        }
    }
}
