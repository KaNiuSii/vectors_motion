using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorsManager : MonoBehaviour
{
    public List<VectorData> vectors = new List<VectorData>();
    public VectorData mainVector;
    public GameObject vector;
    private bool rotating = false;
    public DataDisplayManager dispMgr;
    private void Start()
    {
        vectors.Add(mainVector);
    }
    public void AddVector()
    {
        if (vectors.Count >= 7) return;
        GameObject v = Instantiate(vector);
        VectorFollowTip follow = v.AddComponent<VectorFollowTip>();
        follow.toFollow = vectors[vectors.Count - 1];
        vectors.Add(v.GetComponent<VectorData>());
        dispMgr.UpdateDisplays();
    }
    public void RemoveVector()
    {
        if (vectors.Count <= 1) return;
        VectorData vToDel = vectors[vectors.Count - 1];
        vectors.RemoveAt(vectors.Count - 1);
        Destroy(vToDel.gameObject);
        dispMgr.UpdateDisplays();
    }

    public void RotationChange()
    {
        if (rotating)
        {
            StopRotating();
        }
        else
        {
            StartRotating();
        }
    }

    public void StartRotating()
    {
        foreach (var v in vectors)
        {
            v.rotate = true;
        }
        rotating = true;
    }
    public void StopRotating()
    {
        foreach (var v in vectors)
        {
            v.rotate = false;
        }
        rotating = false;
    }

    public void ResetSimulation()
    {
        StopRotating();
        ResetAllRotations();
        ClearAllLines();
    }

    private void ClearAllLines()
    {
        foreach (var v in vectors)
        {
            LineRenderer lineRenderer = v.GetComponent<LineRenderer>();
            if (lineRenderer != null)
            {
                lineRenderer.positionCount = 0;
            }
        }
    }

    private void ResetAllRotations()
    {
        foreach (var v in vectors)
        {
            v.transform.rotation = Quaternion.identity;
        }
    }
}
