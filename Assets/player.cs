using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public Transform playGround;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxis("Horizontal");
        float newx = transform.position.x + Time.deltaTime * speed * dir;
        float playGroundArea = playGround.localScale.x * 10;
        float paddelSize = transform.localScale.x * 1;

        float maxx = 0.5f * playGroundArea - 0.5f * paddelSize;
        float clamptx = Mathf.Clamp(newx, -maxx, maxx);
        transform.position = new Vector3(clamptx, transform.position.y, transform.position.z);
    }
}
