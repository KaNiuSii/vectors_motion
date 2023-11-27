using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorDraw : MonoBehaviour
{
    public bool draw = false;
    public float minDistance = 0.1f;
    public Color color = Color.yellow;
    private VectorData data;
    private LineRenderer lineRenderer;
    private Vector3 prev = Vector3.zero;
    
    private void Start()
    {
        data = GetComponent<VectorData>();
        lineRenderer = GetComponent<LineRenderer>();

        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer component not found on this GameObject.");
        }
        prev = data.tip;
    }
    float t = 0f;
    void Update()
    {
        if(t < 0.1f)
        {
            t += Time.deltaTime;
            return;
        }
        if (!draw || !data.rotate)
        {
            return;
        }
        lineRenderer.startColor = color;
        Vector3 pos = data.tip;
        pos.z = 0f;
        if(Vector3.Distance(pos, prev) > minDistance)
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);
            prev = data.tip;
        }
    }
}
