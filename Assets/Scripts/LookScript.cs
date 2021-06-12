using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookScript : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    float xRotation = 0f;

    public Transform playerBody;
    public Transform playerHead;


    // Start is called before the first frame update
    void Start()
    {
        (GravityAttractor gravityBody, Vector3 direction) = getDirection();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        (GravityAttractor gravityBody, Vector3 direction) = getDirection();

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerBody.rotation = Quaternion.FromToRotation(transform.up, direction.normalized) * transform.rotation;
        playerHead.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    (GravityAttractor, Vector3) getDirection()
    {
        GravityAttractor gravityBody = null;
        float force = 0;
        Vector3 direction = Vector3.zero;
        GravityAttractor[] allBodies = GameObject.FindObjectsOfType<GravityAttractor>();

        foreach (GravityAttractor currentBody in allBodies)
        {
            Vector3 currentDirection = transform.position - currentBody.transform.position;
            float currentForce = currentBody.GetComponent<Rigidbody>().mass / currentDirection.sqrMagnitude;
            if (force < currentForce)
            {
                gravityBody = currentBody;
                force = currentForce;
                direction = currentDirection;
            }
        }

        return (gravityBody, direction);
    }
}
