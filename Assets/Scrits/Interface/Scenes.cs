using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    //[SerializeField]
    
    public void Inicio()
    {
        SceneManager.LoadScene(0);
    }
    public void Comenzar()
    {
        SceneManager.LoadScene(1);
    }

    public void MisionUno()
    {
        SceneManager.LoadScene(2);
    }
    public void MisionDos()
    {
        SceneManager.LoadScene(3);
    }
    public void MisionTres()
    {
        SceneManager.LoadScene(4);
    }
    public void MisionCuatro()
    {
        SceneManager.LoadScene(5);
    }
    public void MisionCinco()
    {
        SceneManager.LoadScene(6);
    }

    public void Sali()
    {
        Application.Quit();
    }
    public void Pausa()
    {
        Time.timeScale = 0.0f;
    }

    public void DesPusa()
    {
        Time.timeScale = 1.0f;
    }
}
