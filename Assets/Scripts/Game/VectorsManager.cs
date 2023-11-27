using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorsManager : MonoBehaviour
{
    public List<VectorData> vectors = new List<VectorData>();
    public VectorData mainVector;
    public GameObject vector;
    private void Start()
    {
        vectors.Add(mainVector);
    }
    public void AddVector()
    {
        GameObject v = Instantiate(vector);
        VectorFollowTip follow = v.AddComponent<VectorFollowTip>();
        follow.toFollow = vectors[vectors.Count - 1];
        vectors.Add(v.GetComponent<VectorData>());
    }
    public void RemoveVector(int index)
    {
        if (index < 1 || index > vectors.Count) return;
        VectorData v = vectors[index];
        vectors.RemoveAt(index);
        Destroy(v.gameObject);
    }
}
