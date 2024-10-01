using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceControl : MonoBehaviour
{
    private Dictionary<string, Vector3> directions = new Dictionary<string, Vector3>();
    private KeywordRecognizer keywordRecognizer;
    private Rigidbody rb;

    void Start()
    {
        // Definir direcciones asociadas a las palabras clave
        directions.Add("arriba", new Vector3(0, 0, 0));          // Apuntar hacia adelante (arriba)
        directions.Add("abajo", new Vector3(0, 180, 0));         // Apuntar hacia atrás (abajo)
        directions.Add("izquierda", new Vector3(0, 270, 0));     // Apuntar a la izquierda
        directions.Add("derecha", new Vector3(0, 90, 0));        // Apuntar a la derecha

        // Direcciones diagonales
        directions.Add("uno", new Vector3(0, 315, 0));           // Entre izquierda y arriba (45 grados)
        directions.Add("dos", new Vector3(0, 45, 0));            // Entre arriba y derecha (135 grados)
        directions.Add("tres", new Vector3(0, 135, 0));          // Entre derecha y abajo (225 grados)
        directions.Add("cuatro", new Vector3(0, 225, 0));        // Entre abajo e izquierda (315 grados)

        // Inicializar reconocimiento de palabras clave
        keywordRecognizer = new KeywordRecognizer(directions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();

        rb = GetComponent<Rigidbody>();
    }

    // Esta función se ejecuta cuando se detecta una palabra clave
    private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Vector3 targetRotation;
        if (directions.TryGetValue(args.text, out targetRotation))
        {
            RotatePlayer(targetRotation);
        }
    }

    private void RotatePlayer(Vector3 rotation)
    {
        // Establece la rotación absoluta, no relativa
        transform.eulerAngles = rotation;
    }

    void OnDestroy()
    {
        // Detener el reconocimiento de voz cuando se destruya el objeto
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            keywordRecognizer.Stop();
            keywordRecognizer.OnPhraseRecognized -= OnKeywordsRecognized;
        }
    }
}
