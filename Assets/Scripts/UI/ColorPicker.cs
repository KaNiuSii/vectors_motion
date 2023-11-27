using UnityEngine;
using UnityEngine.UI;

public class SimpleColorPicker : MonoBehaviour
{
    public Slider hueSlider;
    private Image colorPanel;

    private void Start()
    {
        colorPanel = GetComponent<Image>();
        hueSlider.onValueChanged.AddListener(delegate { UpdateColor(); });
        UpdateColor();
    }

    private void UpdateColor()
    {
        float hue = hueSlider.value;
        Color color = Color.HSVToRGB(hue, 1f, 1f);
        colorPanel.color = color;
    }
}
