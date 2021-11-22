using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidad;
    private int contador;

    // Start is called before the first frame update
    void Start()
    {
        velocidad = 5;
        contador = 0;
        Capturar.ataque += MoverAlante;
        Capturar.defiende += MoverAtras;
        Capturar.gira += Girar;
        Capturar.izquierda += MoverIzquierda;
        Capturar.derecha += MoverDerecha;
        Capturar.gol += Gol;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MoverAlante() {
        Vector3 vector;
        if (contador == 1) {
            vector = new Vector3(0f, 0f, -1f);
        } else {
           vector = new Vector3(0f, 0f, 1f);
        }
        transform.position +=  vector * velocidad;
    }

    void MoverAtras() {
        Vector3 vector;
        if (contador == 1) {
            vector = new Vector3(0f, 0f, 1f); 
        } else {
           vector = new Vector3(0f, 0f, -1f);
        }
        transform.position += vector * velocidad;
    }

    void MoverIzquierda() {
        transform.position += new Vector3(-1f, 0f, 0f) * velocidad;
    }

    void MoverDerecha() {
        transform.position += new Vector3(1f, 0f, 0f) * velocidad;
    }

    void Gol() {
        transform.position += new Vector3(0f, 0.25f, 0f) * velocidad;
        Invoke("PosicionOriginal", 0.5f);
    }

    void PosicionOriginal() {
        transform.position -= new Vector3(0f, 0.25f, 0f) * velocidad;
    }

    void Girar() {
        transform.RotateAround(transform.position, new Vector3(0, 1, 0) , 180);
        contador++;
    }
}
