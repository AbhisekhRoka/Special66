using UnityEngine;

public class Camera : MonoBehaviour
{
    //variables globales
    public Transform turgert;
    //distancia entre la target y la camra
    private Vector3 _offset;
    //velocidad de la camara
    public float smoothng;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - turgert.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPosition = turgert.position + _offset;
        transform.position = Vector3.Lerp(transform.position, camPosition, smoothng * Time.deltaTime);
    }
}
