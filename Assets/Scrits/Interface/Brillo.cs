using UnityEngine;
using UnityEngine.UI;

public class Brillo : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;
    [Header("Variables")]
    [SerializeField]
    private float _defaultSlider = 0.0f;
    [SerializeField] 
    private Image _panelBrillo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat("brillo");

        _panelBrillo.color = new Color(_panelBrillo.color.r, _panelBrillo.color.g, _panelBrillo.color.b, _slider.value);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeSlider(float valor)
    {
        _defaultSlider = valor;
        PlayerPrefs.SetFloat("brillo", _defaultSlider);
        _panelBrillo.color = new Color(_panelBrillo.color.r, _panelBrillo.color.g, _panelBrillo.color.b, _slider.value);
    }
}
