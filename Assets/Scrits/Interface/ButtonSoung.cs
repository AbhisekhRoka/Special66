using UnityEngine;

public class ButtonSoung : MonoBehaviour
{
    //llamamos al audosource
    private AudioSource music;
    // agregamos los sonidos que queremos para el sonido
    public AudioClip encimamusic;
    [SerializeField]
    private AudioClip ClipSonido;

    void Start()
    {
        // llamamos al audosource apra que funcione
        music = GetComponent<AudioSource>();
    }

    public void Clikaudio()
    {
        //colocamos la funcion de reproducir el clip de sonido una vez
        music.PlayOneShot(ClipSonido);
        //AudioManager.Instance.PlaySound(ClipSonido);
    }

    public void EncimaBoton()
    {
        music.PlayOneShot(encimamusic);
    }
}
