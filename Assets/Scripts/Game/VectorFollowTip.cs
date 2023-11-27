using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorFollowTip : MonoBehaviour
{
    public VectorData toFollow;
    // Update is called once per frame
    void Update()
    {
        transform.position = toFollow.tip;
    }
}
