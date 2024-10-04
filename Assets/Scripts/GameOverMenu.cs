using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    //Metodo de cambio de Escena asignado a un boton 
    public void Restart()
    {
        SceneManager.LoadScene(1); //Reinicia juego
    }

    public void Menu()
    {
        SceneManager.LoadScene(0); //Vuelve al Menu
    }
}