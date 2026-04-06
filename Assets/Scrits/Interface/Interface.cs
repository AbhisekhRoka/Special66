using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public Slider _slider;
    [Header("Variables")]
    public float _defaultSlider = 0.5f;
    private void Start()
    {


        LoadData();
    }
    public void DeteleData()
    {
        _slider.value = _defaultSlider;
    }
    public void SaveData()
    {
        PlayerPrefs.SetFloat("Volume", _slider.value);
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            _slider.value = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            _slider.value = _defaultSlider;
            PlayerPrefs.SetFloat("DefaultVolume", _defaultSlider);

        }
    }
}
