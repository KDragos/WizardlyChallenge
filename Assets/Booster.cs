using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public float thrust;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.name.Contains("Ball"))
        {
            //Debug.Log("Exit booster working!");
            //coll.GetComponent<Rigidbody>().AddForce(10, 10, 10);
            //coll.GetComponent<Rigidbody>().AddForce(Vector3.forward * Time.deltaTime * 100, ForceMode.Acceleration);
            //float multiplier = coll.GetComponent<Rigidbody>().velocity.magnitude;
            //coll.GetComponent<Rigidbody>().AddForce(Vector3.forward * (multiplier * Time.deltaTime * 10));
            //Rigidbody rb = coll.GetComponent<Rigidbody>();
           // rb.AddForce(coll.transform.forward * thrust);

        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.name.Contains("Ball"))
        {
            Debug.Log("Trigger stay working!");
            //coll.GetComponent<Rigidbody>().AddForce(10, 10, 10);
            //coll.GetComponent<Rigidbody>().AddForce(Vector3.forward * Time.deltaTime * 100, ForceMode.Acceleration);
            //float multiplier = coll.GetComponent<Rigidbody>().velocity.magnitude;
            //coll.GetComponent<Rigidbody>().AddForce(Vector3.forward * (multiplier * Time.deltaTime * 10));
            Rigidbody rb = coll.GetComponent<Rigidbody>();
            //rb.AddRelativeForce(Vector3.forward * thrust);
            rb.AddForce(rb.velocity.normalized * thrust);

        }
    }

    //public float desiredSpeed;
    //public float maximumDrag;
    //public float forceConstant;
    //void Update()
    //{
    //  Vector3 forceDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //This reduces drag when the player adds input, and makes it stop faster. 
    //rigidbody.drag = Mathf.Lerp(maximumDrag, 0, forceDirection.magnitude); // this reduces the amount of force that acts on the object if it is already // moving at speed. 
    //float forceMultiplier = Mathf.Clamp01((desiredSpeed - rigidbody.velocity.magnitude) / desiredSpeed); // now we actually perform the push 
    //Rigidbody.AddForce(forceDirection * (forceMultiplier * Time.deltaTime * forceConstant));
    //}
}