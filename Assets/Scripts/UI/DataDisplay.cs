using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class DataDisplay : MonoBehaviour
{
    public VectorData bind;
    public VectorsManager vectorsManager; // Reference to the VectorsManager

    [SerializeField]
    private Slider lenSlider;
    [SerializeField]
    private TextMeshProUGUI lenValText;
    [SerializeField]
    private TMP_InputField speedInputField;
    [SerializeField]
    private Toggle drawToggle;
    [SerializeField]
    private Image drawColorImage;

    void Start()
    {
        // Initial UI setup from bind vector data
        lenSlider.value = bind.vectorScale;
        speedInputField.text = bind.rotationValue.ToString();
        drawToggle.isOn = bind.draw;
        drawColorImage.color = bind.drawColor;
    }

    void Update()
    {
        // Update UI from bind vector data
        bind.vectorScale = lenSlider.value;
        bind.rotationValue = float.Parse(speedInputField.text);
        bind.draw = drawToggle.isOn;
        bind.drawColor = drawColorImage.color;

        // Update display texts
        lenValText.text = lenSlider.value.ToString("F2");
    }

    public void DeleteDataAndDisplay()
    {
        int index = vectorsManager.vectors.IndexOf(bind);
        if (index != -1)
        {
            vectorsManager.RemoveVector(index);
        }
    }
}
