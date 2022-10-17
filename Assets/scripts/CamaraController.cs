using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour {
    //Referencia a nuestro jugador
    public GameObject jugador;
    //Para registrar la diferencia entre la posicion de la camara y la del jugador
    private Vector3 offset;
    // Use this for initialization
    void Start () {
        //diferencia entre la posicion de la camara y la del jugador
        offset = transform.position - jugador.transform.position;
    }
    // Se ejecuta cada frame, pero despues de haber procesado todo. Es mas exacto para la camara
    void LateUpdate () {
        //Actualizo la posicion de la camara
        transform.position = jugador.transform.position + offset;
    }
}
