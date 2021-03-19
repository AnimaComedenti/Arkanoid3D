using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playBall : MonoBehaviour
{
    private Vector3 velocity;
    private AudioSource audio;
    private bool gotOut;
    private float timer = 0.0f;
    private float timerMax = 1.0f;
    private bool hitted;

    public float maxX;
    public float maxZ;
    public int duration;
    public GameObject gameover;
    public GameObject gamewon;
    public AudioClip hitwall;
    public AudioClip hitbrick;
    public AudioClip outOfField;
    public GameObject mainMusik;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        hitted = false;
        Invoke(nameof(throwBall),duration);
    }

    void throwBall()
    {
        velocity = new Vector3(0, 0, -maxZ);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectsWithTag("brick").Length == 0)
        {
            gamewon.SetActive(true);
            mainMusik.GetComponent<AudioSource>().volume = 0;
            Time.timeScale = 0;
            Destroy(gameObject);
        }

        if (!gotOut)
        {
            transform.position += velocity * Time.deltaTime;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= timerMax)
            {
                velocity = new Vector3(0, 0, -maxZ);
                transform.position += velocity * Time.deltaTime;
                timer = 0.0f;
                gotOut = false;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string tagname = other.tag;
        hitted = true;
        if (hitted)
        {
            if (tagname == "player")
            {
                float maxdistanz = other.transform.localScale.x * 1 * 0.5f + transform.localScale.x * 1 * 0.5f;
                float dist = transform.position.x - other.transform.position.x;
                float ndist = dist / maxdistanz;

                velocity = new Vector3(ndist * maxX, 0, -velocity.z);
                audio.clip = hitbrick;
                audio.volume = 0.2f;
                audio.Play();
            }
            if (tagname == "wall")
            {
                velocity = new Vector3(velocity.x * -1f, 0, velocity.z);
                audio.clip = hitwall;
                audio.volume = 1;
                audio.Play();
            }

            if (tagname == "topWall")
            {
                velocity = new Vector3(velocity.x, 0, velocity.z * -1f);
                audio.clip = hitwall;
                audio.volume = 1;
                audio.Play();
            }

            if (tagname == "outGoal")
            {
                transform.position = new Vector3(0, 0.5f, -2);
                TextMesh liveText = GameObject.Find("currentLives").GetComponent<TextMesh>();
                string text = liveText.text;
                int result = Int32.Parse(text);
                result--;
                audio.clip = outOfField;
                audio.volume = 1;
                audio.Play();
                if (result >= 1)
                {
                    liveText.text = "" + result;
                }
                else
                {
                    liveText.text = "" + result;
                    gameover.SetActive(true);
                    mainMusik.GetComponent<AudioSource>().volume = 0;
                    Time.timeScale = 0;
                }
                gotOut = true;
            }

            if (tagname == "brick")
            {
                float maxdistanz = other.transform.localScale.x * 1 * 0.5f + transform.localScale.x * 1 * 0.5f;
                float dist = transform.position.x - other.transform.position.x;
                float ndist = dist / maxdistanz;

                velocity = new Vector3(ndist * maxX, 0, -velocity.z);
                audio.clip = hitbrick;
                audio.volume = 0.2f;
                audio.Play();
            }
        }
        hitted = false;
    }
}

