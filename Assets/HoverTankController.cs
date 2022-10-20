using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTankController : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 100.0f, vInput, hInput, distance, antiGravForce;

    Rigidbody rigidBody;

    [SerializeField]
    GameObject hoverPad1, hoverPad2, hoverPad3, hoverPad4;

    [SerializeField]
    bool player1, player2;

    public bool started, finished, go;

    float hover1Hit, hover2Hit, hover3Hit, hover4Hit;

    public float countdown, time;


    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        finished = false;
        countdown = 5.0f;
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        distance = 1.0f;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (player1 == true && player2 == false)
        {
            hInput = Input.GetAxis("Horizontal1");
            vInput = Input.GetAxis("Vertical1");
        }
        else if (player1 == false && player2 == true)
        {
            hInput = Input.GetAxis("Horizontal2");
            vInput = Input.GetAxis("Vertical2");
        }

        if (countdown <= 0)
        {
            go = true;
        }
        if (go == true)
        {
            transform.Rotate(Vector3.up, hInput * rotationSpeed * Time.deltaTime);
            rigidBody.AddRelativeForce(0, 0, vInput * 100);
        }
        if (go == true && started == true)
        {
            time += Time.deltaTime;
        }


        Debug.Log(started);


        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    private void FixedUpdate()
    {
        antiGravForce = rigidBody.mass;

        //hovering
        if (Physics.Raycast(hoverPad1.transform.position, Vector3.down, out hit, distance))
        {
            rigidBody.AddForceAtPosition(transform.up * (distance - hit.distance) / distance * (antiGravForce / 4), hoverPad1.transform.position, ForceMode.Impulse);
            hover1Hit = hit.distance;
        }
        if (Physics.Raycast(hoverPad2.transform.position, Vector3.down, out hit, distance))
        {
            rigidBody.AddForceAtPosition(transform.up * (distance - hit.distance) / distance * (antiGravForce / 4), hoverPad2.transform.position, ForceMode.Impulse);
            hover2Hit = hit.distance;
        }
        if (Physics.Raycast(hoverPad3.transform.position, Vector3.down, out hit, distance))
        {
            rigidBody.AddForceAtPosition(transform.up * (distance - hit.distance) / distance * (antiGravForce / 4), hoverPad3.transform.position, ForceMode.Impulse);
            hover3Hit = hit.distance;
        }
        if (Physics.Raycast(hoverPad4.transform.position, Vector3.down, out hit, distance))
        {
            rigidBody.AddForceAtPosition(transform.up * (distance - hit.distance) / distance * (antiGravForce / 4), hoverPad4.transform.position, ForceMode.Impulse);
            hover4Hit = hit.distance;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (started == false && finished == false)
        {
            started = true;
        }
        else if (started == true && finished == false)
        {
            finished = true;
        }
    }
}
