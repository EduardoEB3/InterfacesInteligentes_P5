using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Capturar : MonoBehaviour
{
    public string[] palabrasClave;
    private KeywordRecognizer reconocedor;
    private static bool activoCapturar;
    public delegate void Ataque();
    public static event Ataque ataque;
    public delegate void Defiende();
    public static event Defiende defiende;
    public delegate void Gira();
    public static event Gira gira;
    public delegate void Izquierda();
    public static event Izquierda izquierda;
    public delegate void Derecha();
    public static event Derecha derecha;
    public delegate void Gol();
    public static event Gol gol;

    // Start is called before the first frame update
    void Start()
    {
        reconocedor = new KeywordRecognizer(palabrasClave);
        reconocedor.OnPhraseRecognized += VerDatos;
        activoCapturar = false;
        // MicrosDisponibles();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static bool Activado
    { 
        get { return activoCapturar; }
    }

    void VerDatos(PhraseRecognizedEventArgs datos) {
        if (datos.text == "Ataca") {
            ataque();
        } else if (datos.text == "Defiende") {
            defiende();
        } else if (datos.text == "Gira") {
            gira();
        } else if (datos.text == "Izquierda") {
            izquierda();
        } else if (datos.text == "Derecha") {
            derecha();
        } else if (datos.text == "Gol") {
            gol();
        }
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1})\n", datos.text, datos.confidence);
        builder.AppendFormat("\tTimestamp: {0}\n", datos.phraseStartTime);
        builder.AppendFormat("\tDuration: {0} seconds\n", datos.phraseDuration.TotalSeconds);
        Debug.Log(builder.ToString());
    } 

    void MicrosDisponibles()
    {
        int contador = 1;
        foreach (var micro in Microphone.devices)
        {
            Debug.Log("Nombre del micro " + contador.ToString() + ": " + micro);
            contador++;
        }
    }

    void OnDestroy() 
    {
       reconocedor.Dispose(); 
    }

    void OnCollisionEnter(Collision objetoColision)
    {
        if(objetoColision.gameObject.name == "Jugador") {
            if (!activoCapturar && !Dictado.ActivadoD) {
                Debug.Log("Activo");
                activoCapturar = true;
                PhraseRecognitionSystem.Restart();
                reconocedor.Start();
            } else if (!activoCapturar && Dictado.ActivadoD) {
                Debug.Log("Primero debe desactivar el dictado.");
            } else {
                Debug.Log("Desactivado");
                activoCapturar = false;
                reconocedor.Stop();
                PhraseRecognitionSystem.Shutdown();
            }            
        }
    }
}

