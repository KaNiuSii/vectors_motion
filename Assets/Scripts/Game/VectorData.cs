using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorData : MonoBehaviour
{
    public Vector3 tip;
    public float rotationValue;
    public Transform ArrowTr;
    public Transform Tip;
    // Update is called once per frame
    void Update()
    {
        TipUpdate();
    }

    void TipUpdate()
    {
        tip = Tip.position;
    }

    public void ChangeArrowScale(float scale)
    {
        Vector3 sc = ArrowTr.localScale;
        sc.y = scale;
        Vector3 pos = ArrowTr.localPosition;
        pos.y = scale / 2;
        
        ArrowTr.localScale = sc;
        ArrowTr.localPosition = pos;
    }
}
