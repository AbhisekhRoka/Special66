using UnityEngine;

public class VictoryDefaulf : MonoBehaviour
{
    [SerializeField]
    private GameObject _panelDeGanar;
    private void OnTriggerEnter(Collider infoAccess)
    {
        if (infoAccess.CompareTag("Bruja"))
        {
            Time.timeScale = 0.0f;
            _panelDeGanar.SetActive(true);
        }
    }
}
