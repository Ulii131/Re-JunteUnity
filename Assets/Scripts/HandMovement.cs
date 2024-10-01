using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    public Transform handLeft;    // Asigna la mano izquierda en el inspector
    public Transform handRight;   // Asigna la mano derecha en el inspector

    public float rotationSpeed = 10f; // Velocidad del movimiento giratorio
    public float swayAmplitude = 5f;  // Amplitud del balanceo suave
    public float swaySpeed = 2f;      // Velocidad del balanceo suave

    private float timer = 0f;
    private Quaternion initialRotationLeft;
    private Quaternion initialRotationRight;

    void Start()
    {
        // Guardar las rotaciones iniciales de las manos
        initialRotationLeft = handLeft.localRotation;
        initialRotationRight = handRight.localRotation;
    }

    void Update()
    {
        // Incrementamos el temporizador para el movimiento suave
        timer += Time.deltaTime * swaySpeed;

        // Movimiento suave de balanceo (oscila de un lado a otro)
        float sway = Mathf.Sin(timer) * swayAmplitude;

        // Mantener la rotación inicial y aplicar un pequeño balanceo relativo
        handLeft.localRotation = initialRotationLeft * Quaternion.Euler(0, 0, sway);
        handRight.localRotation = initialRotationRight * Quaternion.Euler(0, 0, -sway);

        // Movimiento giratorio sutil (se aplica en el espacio local)
        handLeft.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
        handRight.Rotate(Vector3.down * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
