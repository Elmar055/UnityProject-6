using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObjectsX : MonoBehaviour
{
    public float spinSpeed;

    // Update is called once per frame
    void Update()
    {
        // for rotate objects
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
