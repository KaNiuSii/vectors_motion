using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorRotate : MonoBehaviour
{
    VectorData data;

    void Start()
    {
        data = this.GetComponent<VectorData>();
    }

    // Update is called once per frame
    void Update()
    {
        // Assuming data.rotationValue is in degrees and you want to rotate around the Z axis
        transform.Rotate(new Vector3(0, 0, data.rotationValue) * Time.deltaTime);
    }
}
