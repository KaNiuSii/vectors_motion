using System.Collections.Generic;
using UnityEngine;

public class DataDisplayManager : MonoBehaviour
{
    public VectorsManager vectorsManager;
    public GameObject dataDisplayPrefab;
    private List<GameObject> spawnedDisplays = new List<GameObject>();
    public float verticalSpacing = 300f;

    private void Start()
    {
        UpdateDisplays();
    }
    float t = 0f;
    bool updated = false;
    private void Update()
    {
        t += Time.deltaTime;
        if (t > 0.1f && !updated)
        {
            updated = true;
            UpdateDisplays();
        }
    }
    public void UpdateDisplays()
    {
        ClearExistingDisplays();
        for (int i = 0; i < vectorsManager.vectors.Count; i++)
        {
            SpawnDataDisplay(vectorsManager.vectors[i], i);
        }
    }

    void SpawnDataDisplay(VectorData vectorData, int index)
    {
        GameObject displayObject = Instantiate(dataDisplayPrefab, transform);
        displayObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -index * verticalSpacing, 0);

        DataDisplay dataDisplay = displayObject.GetComponent<DataDisplay>();
        dataDisplay.bind = vectorData;
        dataDisplay.vectorsManager = vectorsManager;
        dataDisplay.indx.text = $"{index}";
        spawnedDisplays.Add(displayObject);
    }

    void ClearExistingDisplays()
    {
        foreach (var display in spawnedDisplays)
        {
            Destroy(display);
        }
        spawnedDisplays.Clear();
    }
}
