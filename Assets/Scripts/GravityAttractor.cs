using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public float initialX;
    public float initialY;
    public float initialZ;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Rigidbody>().velocity = new Vector3(initialX, initialY, initialZ);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
