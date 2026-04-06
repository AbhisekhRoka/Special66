using UnityEngine;

public class Player : MonoBehaviour
{

    // Start is called before the first frame update

    //variables globales
    //variables de movimeinto
    private float _horizontal,
                 _vertical;
    public float Speed;
    public float Speedx;
    //variables de salto
    private Ray _ray;
    private RaycastHit _hit;
    private float _rayLength = 0.3f;
    public LayerMask GramdLayer;
    private bool _isGrounded;
    private bool _canPlayerJunp;
    private Rigidbody _rb;
    public float JumpForce;
    // variable de correr
    public float _correr;
    public float _savedSpedd;
    //Sonido de maria
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip ClipAndar;
    [SerializeField]
    private AudioClip ClipSaltar;


    //animacion
    private Animator _animacion;

    private void Awake()
    {
        //llamada a animacion
        _animacion = GetComponent<Animator>();
        //llamada al rigidbody
        _rb = GetComponent<Rigidbody>();
        //llamamos al sourcede maria
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ImputPlayer();
        Move();
        turn();
        CanJumpc();
        Animatig();
        Salto();
        Correr();
    }

    private void FixedUpdate()
    {
        //identificar si toca el suelo
        LounchRaycast();
        if (_canPlayerJunp)
        {
            _canPlayerJunp = false;
            //salto
            Jump();
        }
    }
    // el raycasts, la linea invisible que calcula si toca o no
    private void LounchRaycast()
    {
        //posicion de salida del rayo
        _ray.origin = transform.position;
        // direccion del rayo, el menos es para que balla atras pero se puede colocar un down 
        _ray.direction = -transform.up;


        if (Physics.Raycast(_ray, out _hit, _rayLength, GramdLayer))
        {
            _isGrounded = true;
            //Debug.Log("estoy tocando el suelo " + gameObject.name);
        }
        else
        {
            _isGrounded = false;
        }
        //poder ver el rayo, le damos un color
        Debug.DrawRay(_ray.origin, _ray.direction * _rayLength, Color.red);

    }


    //codigos de movimiento
    private void ImputPlayer()
    {
        // movimiento hacia los lados
        _horizontal = Input.GetAxis("Horizontal");
        //movimiento al frente
        _vertical = Input.GetAxis("Vertical");
    }
    //movimiento al frente
    private void Move()
    {
        transform.Translate(Vector3.forward * _vertical * Speed * Time.deltaTime);
    }
    // rotacion a los lados
    private void turn()
    {
        transform.Rotate(Vector3.up * _horizontal * Speedx * Time.deltaTime);
    }
    //codigo de salto
    private void CanJumpc()
    {
        //si quiero saltar y puedo saltar
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _canPlayerJunp = true;

        }
    }
    // fuerza del salto
    private void Jump()
    {
        _rb.AddForce(Vector3.up * JumpForce);
    }

    //codigo de animacion
    private void Animatig()
    {
        if (_vertical != 0.0f)
        {
            // si es "si" aztiva el movimiento
            _animacion.SetBool("Juani", true);
            if (_audioSource.isPlaying == false)
            {
                _audioSource.PlayOneShot(ClipAndar);
            }
        }
        else
        {
            // si es "no" vuelve al estado anterior 
            _animacion.SetBool("Juani", false);
        }
    }
    private void Salto()
    {
        if (_canPlayerJunp == true)
        {
            // si es "si" aztiva el movimiento
            _animacion.SetBool("Salto", true);
            _audioSource.PlayOneShot(ClipSaltar);
        }


    }
    //codigo de salto
    private void Correr()
    {
        //al apretar shift sprinta
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = _correr;
            if (_correr >= 0)
            {
                _animacion.SetBool("Juani", true);
                if (_audioSource.isPlaying == false)
                {
                    _audioSource.PlayOneShot(ClipAndar);
                }
            }
            else
            {
                _animacion.SetBool("Juani", false);
            }
        }
        else
        {
            Speed = _savedSpedd;
        }

    }
}
