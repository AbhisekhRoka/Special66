using UnityEngine;

public class EnemyPatruya : MonoBehaviour
{
    //zona de variables globales
    [Header("puntosdecontrol")]
    [SerializeField]
    //array de posicion del fantasma
    private Transform[] _positionArray;
    [SerializeField]
    private float _speed;

    private Vector3 _moverAcia;
    private int i;
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField]
    private GameObject _panelDePerde;


    private void FixedUpdate()
    {
        Detectar();
    }
    // Start is called before the first frame update
    void Start()
    {
        //indicar en que "puntodecontrol" va a empezar el fantasma
        i = 0;
        _moverAcia = _positionArray[i].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ChangePosition();
        Rotate();
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _moverAcia, _speed * Time.deltaTime);
    }
    private void ChangePosition()
    {
        if (Vector3.Distance(transform.position, _moverAcia) < Mathf.Epsilon)
        {
            // comprueva si estoy en la ultima casilla del array 
            if (i == _positionArray.Length - 1)
            {
                //vuelve a la casilla inicial del array
                i = 0;
            }
            else
            {
                i++;
            }
            _moverAcia = _positionArray[i].position;
        }
    }
    private void Rotate()
    {
        transform.LookAt(_moverAcia);
    }
    private void Detectar()
    {
        _ray.origin = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        _ray.direction = transform.forward;
        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.CompareTag("Maria"))
            {
                _panelDePerde.SetActive(true);
            }
        }
    }
}
