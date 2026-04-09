using UnityEngine;
using UnityEngine.UI;

public class FullPantalla : MonoBehaviour
{
    public Toggle _toggle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //scrit para hacer que el juego se ponga en pantalla completa en el escritorio
    void Start()
    {
        if (Screen.fullScreen)
        {
            _toggle.isOn = true;
        }
        else
        {
            _toggle.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }
}
