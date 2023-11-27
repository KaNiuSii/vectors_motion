using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class DataDisplay : MonoBehaviour
{
    public VectorData bind;
    public VectorsManager vectorsManager;
    public TextMeshProUGUI indx;
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
        lenSlider.value = bind.vectorScale;
        speedInputField.text = bind.rotationValue.ToString();
        drawToggle.isOn = bind.draw;
        drawColorImage.color = bind.drawColor;
    }

    void Update()
    {
        bind.vectorScale = lenSlider.value;
        bind.rotationValue = float.Parse(speedInputField.text);
        bind.draw = drawToggle.isOn;
        bind.drawColor = drawColorImage.color;

        int lenInt = (int)lenSlider.value;
        lenValText.text = lenInt.ToString();
    }
}
