using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Transform target;

    [SerializeField] private float scoreCount;
    private ScorePlayer score;

    // Añadir una variable para el AudioSource
    private AudioSource audioSource;

    // Variable para el clip de sonido
    [SerializeField] private AudioClip enemyDeathSound;

    private void Start()
    {
        score = FindObjectOfType<ScorePlayer>();
        audioSource = GetComponent<AudioSource>(); // Obtener el AudioSource
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    public void SetTarget(Transform player)
    {
        target = player;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Flashlight"))
        {
            score.IncrementScore(scoreCount);
            PlayDeathSound(); // Reproducir el sonido de muerte
            Destroy(gameObject);
        }
    }

    private void PlayDeathSound()
    {
        if (audioSource && enemyDeathSound)
        {
            audioSource.PlayOneShot(enemyDeathSound); // Reproducir el sonido
        }
    }
}
