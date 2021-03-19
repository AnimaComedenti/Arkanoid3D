using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBigger : MonoBehaviour
{
    public float maxZ;
    private Vector3 velocity;
    public float duration;
    public float scale;
    public GameObject gameboard;
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
            GetComponent<AudioSource>().Play();
            if ((player.transform.localScale.x+1) < (gameboard.transform.localScale.x * 10))
            {
                player.transform.localScale = new Vector3(player.transform.localScale.x + scale, player.transform.localScale.y, player.transform.localScale.z);
                Invoke(nameof(makeSmaller), duration);
                GetComponent<Renderer>().enabled = false;
                GetComponent<Collider>().enabled = false;
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }
    private void makeSmaller()
    {
        player.transform.localScale = new Vector3(player.transform.localScale.x - scale, player.transform.localScale.y, player.transform.localScale.z);
        Destroy(gameObject);
    }
}
