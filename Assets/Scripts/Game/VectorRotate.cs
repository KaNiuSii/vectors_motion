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
        if (!data.rotate) return;
        transform.Rotate(new Vector3(0, 0, data.rotationValue) * Time.deltaTime);
    }
}
