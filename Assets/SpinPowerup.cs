using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPowerup : MonoBehaviour {

    public float SpinSpeed = 1.5f;

    // Use this for initialization
    void Start () {
    }
    
    // Update is called once per frame
    void Update () {
        transform.Rotate(new Vector3(1, 0, 0), SpinSpeed);
    }
}
