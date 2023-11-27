using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorData : MonoBehaviour
{
    public Vector3 tip;
    public float rotationValue;
    public float vectorScale = 1f;
    public bool rotate = false;
    public bool draw = false;
    public Transform Tip;
    public Color drawColor = Color.yellow;
    private VectorDraw vectorDraw;    
    private void Start()
    {
        vectorDraw = GetComponent<VectorDraw>();
    }
    void Update()
    {
        TipUpdate();
        Scale();
        vectorDraw.color = drawColor;
        vectorDraw.draw = draw;
    }

    void TipUpdate()
    {
        tip = Tip.position;
    }

    void Scale()
    {
        Vector3 sc = transform.localScale;
        sc.y = vectorScale;
        transform.localScale = sc;
    }
}
