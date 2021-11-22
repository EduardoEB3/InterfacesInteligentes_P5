using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class Dictado : MonoBehaviour
{
    public Text mensaje;
    private Text hipotetico;
    private Text reconocido;
    private DictationRecognizer dictado;
    private static bool activoDictado;

    // Start is called before the first frame update
    void Start()
    {
        dictado = new DictationRecognizer();
        dictado.DictationResult += Resultado;
        dictado.DictationHypothesis += Hipotetico;
        dictado.DictationComplete += Causa;
        dictado.DictationError += Error;
        activoDictado = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Resultado(string texto, ConfidenceLevel confianza)
    {
        Debug.LogFormat("Dictado resultado: {0}", texto);
        Mensaje(texto);
        if (reconocido != null) {
            reconocido.text += texto + "\n";
        }
    }

    void Hipotetico(string texto)
    {
        Debug.LogFormat("Dictado hipótesis: {0}", texto);
        if (hipotetico != null) {
            hipotetico.text += texto;
        }
    }

    void Causa(DictationCompletionCause causa)
    {
        if (causa != DictationCompletionCause.Complete) {
            Debug.LogErrorFormat("El dictado no ha tenido éxito: {0}", causa);
        }
    }

    void Error(string error, int resultado)
    {
        Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}", error, resultado);
    }

    void Mensaje(string texto) 
    {
        mensaje.text = texto;
    }

    public static bool ActivadoD
    { 
        get { return activoDictado; }
    }

    void OnDestroy()
    {
       dictado.Dispose(); 
    }

    void OnCollisionEnter(Collision objetoColision)
    {
        if(objetoColision.gameObject.name == "Jugador") {
            if (!activoDictado && !Capturar.Activado) {
                Debug.Log("Activo");
                activoDictado = true;
                dictado.Start();
            } else if (!activoDictado && Capturar.Activado) {
                Debug.Log("Primero debe desactivar el reconocedor.");
            } else {
                Debug.Log("Desactivado");
                activoDictado = false;
                Mensaje("");
                dictado.Stop();   
            }            
        }
    }
}
