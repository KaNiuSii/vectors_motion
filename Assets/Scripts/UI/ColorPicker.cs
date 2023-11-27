using UnityEngine;
using UnityEngine.UI;

public class SimpleColorPicker : MonoBehaviour
{
    public Slider hueSlider; // Assign this in the inspector
    private Image colorPanel; // Assign this in the inspector

    private void Start()
    {
        colorPanel = GetComponent<Image>();
        // Initialize the slider event
        hueSlider.onValueChanged.AddListener(delegate { UpdateColor(); });
        UpdateColor(); // Set initial color
    }

    private void UpdateColor()
    {
        float hue = hueSlider.value; // Slider value ranges from 0 to 1
        Color color = Color.HSVToRGB(hue, 1f, 1f); // Full saturation and value for vivid colors
        colorPanel.color = color;
    }
}
