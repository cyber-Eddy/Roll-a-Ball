using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Agregamos
using UnityEngine.UI;
public class JugadorController : MonoBehaviour {
    //Declarlo la variable de tipo RigidBody que luego asociaremos a nuestro Jugador
    private Rigidbody rb;
    //Inicializo el contador de coleccionables recogidos
    private int contador;
    //Inicializo variables para los textos
    public Text TextoContador, TextoGanar;
    //Declaro la variable publica velocidad para poder modificarla desde la Inspector window
    public float velocidad;
    //Declaro la variable publica emite para decidir quien emitira el sonido
    public AudioSource moneda;
    //Declaro la variable publica emite para decidir el sonido que se va a emitir
    public AudioClip sonido;
    //Declaro la variable publica emite para decidir el volumen
    public float volumen = 0.5f;
    // Use this for initialization
    void Start () {
        //Capturo esa variable al iniciar el juego
        rb = GetComponent<Rigidbody>();
        //Inicio el contador a 0
        contador = 0;
        //Actualizo el texto del contador por pimera vez
        setTextoContador();
        //Inicio el texto de ganar a vacio
        TextoGanar.text = "";
    }
    // Para que se sincronice con los frames de fisica del motor
    void FixedUpdate () {
        //Estas variables nos capturan el movimiento en horizontal y vertical de nuestro teclado
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        //Un vector 3 es un trio de posiciones en el espacio XYZ, en este caso el que corresponde al movimiento
        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);
        //Asigno ese movimiento o desplazamiento a mi RigidBody, multiplicado por la velocidad que quiera darle
        rb.AddForce(movimiento * velocidad);
    }
    //Se ejecuta al entrar a un objeto con la opcion isTrigger seleccionada
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("coleccionable"))
        {
            //Desactivo el objeto
            //Destroy(gameObject,0.5f);
            moneda.PlayOneShot(sonido, volumen);
            other.gameObject.SetActive (false);
            //Incremento el contador en uno (tambien se peude hacer como contador++)
            contador = contador + 1;
            //Actualizo elt exto del contador
            setTextoContador();
        }
    }
    //Actualizo el texto del contador (O muestro el de ganar si las ha cogido todas)
    void setTextoContador(){
        TextoContador.text = "Contador: " + contador.ToString();
        if (contador >= 12){
            TextoGanar.text = "¡Ganaste!";
        }
    }
}
