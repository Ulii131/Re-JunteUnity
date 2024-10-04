using System.Collections;
using UnityEngine;
using TMPro;  // Importar TextMeshPro

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f; // 1 minuto en segundos
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;  // Asignar el componente TextMeshPro desde el inspector
    public GameObject successMessage; // Asignar el GameObject con el fondo y texto

    void Start()
    {
        // Iniciar el temporizador
        timerIsRunning = true;

        // Asegurarse de que el mensaje de "Conseguido" esté desactivado al inicio
        successMessage.SetActive(false);
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Restar el tiempo que ha pasado desde el último frame
                timeRemaining -= Time.deltaTime;

                // Actualizar el texto con el tiempo formateado
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                // Cuando el tiempo se acaba
                timeRemaining = 0;
                timerIsRunning = false;

                // Mostrar el cartel de "Conseguido"
                ShowSuccessMessage();
            }
        }
    }

    // Actualizar el texto del temporizador
    void UpdateTimerDisplay(float timeToDisplay)
    {
        // Formatear el tiempo para que muestre minutos y segundos
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Mostrar el tiempo en formato MM:SS
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Mostrar el mensaje de "Conseguido, terminaste el nivel"
    void ShowSuccessMessage()
    {
        successMessage.SetActive(true);  // Activar el GameObject del mensaje con la imagen y el texto
        Debug.Log("¡Conseguido, terminaste el nivel!");
    }
}
