using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSlowmo : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxZ;
    private Vector3 velocity;
    public float duration;
    private Collider player;

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
            player = other;
            Time.timeScale = 0.25f;
            Invoke(nameof(stopTime), duration * 0.25f);
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }
    
    private void stopTime()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
