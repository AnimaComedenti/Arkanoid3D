using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playBall : MonoBehaviour
{
    private Vector3 velocity;
    public float maxX;
    public float maxZ;
    private bool gotOut;
    private float timer = 0.0f;
    private float timerMax = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(throwBall());
    }

    IEnumerator throwBall()
    {
        yield return new WaitForSeconds(3);
        velocity = new Vector3(0, 0, -maxZ);
    }

    // Update is called once per frame
    void Update()
    {
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
        if (tagname == "player")
        {
            float maxdistanz = other.transform.localScale.x * 1 * 0.5f + transform.localScale.x * 1 * 0.5f;
            float dist = transform.position.x - other.transform.position.x;
            float ndist = dist / maxdistanz;

            velocity = new Vector3(ndist * maxX, 0, -velocity.z);
            GetComponent<AudioSource>().Play();
        }
        if (tagname == "wall")
        {
            velocity = new Vector3(velocity.x * -1f, 0, velocity.z);
        }

        if (tagname == "topWall")
        {
            velocity = new Vector3(velocity.x, 0, velocity.z* -1f);
        }

        if (tagname == "outGoal")
        {
            transform.position = new Vector3(0,0.5f,-2);
            gotOut = true;
        }

        if (tagname == "brick")
        {
            float maxdistanz = other.transform.localScale.x * 1 * 0.5f + transform.localScale.x * 1 * 0.5f;
            float dist = transform.position.x - other.transform.position.x;
            float ndist = dist / maxdistanz;

            velocity = new Vector3(ndist * maxX, 0, -velocity.z);
            Destroy(other.gameObject);
            GetComponent<AudioSource>().Play();
        }

    }
}
