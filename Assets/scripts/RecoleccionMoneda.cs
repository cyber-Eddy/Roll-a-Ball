using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoleccionMoneda : MonoBehaviour
{
   
    //Declaro la variable publica emite para decidir quien emitira el sonido
    public AudioSource moneda;
    //Declaro la variable publica emite para decidir el sonido que se va a emitir
    public AudioClip sonido;
    //Declaro la variable publica emite para decidir el volumen
    public float volumen = 0.5f;

    void OnTriggerEnter(Collider other){

        if (other.gameObject.CompareTag ("Player")){
            moneda.PlayOneShot(sonido, volumen);
            moneda.Play();
            print(other.name);
        }
    }
    
}
