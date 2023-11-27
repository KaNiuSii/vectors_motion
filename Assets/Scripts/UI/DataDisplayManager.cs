using System.Collections.Generic;
using UnityEngine;

public class DataDisplayManager : MonoBehaviour
{
    public VectorsManager vectorsManager;
    public GameObject dataDisplayPrefab;
    private List<GameObject> spawnedDisplays = new List<GameObject>();
    public float verticalSpacing = 300f; // Spacing between displays

    private void Start()
    {
        UpdateDisplays();
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
        displayObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -index * verticalSpacing, 0); // Adjust position

        DataDisplay dataDisplay = displayObject.GetComponent<DataDisplay>();
        dataDisplay.bind = vectorData;
        dataDisplay.vectorsManager = vectorsManager;
        dataDisplay.indx.text = $"{index}";
        spawnedDisplays.Add(displayObject); // Keep track of spawned displays
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
