using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour {

    public float Posx;
    public float Posy;
    public float Posz;


    public void ResetPos()
    {
        gameObject.transform.position = new Vector3(Posx,Posy,Posz);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
