using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Transform target;

    [SerializeField] private float scoreCount;
     private ScorePlayer score;

    private void Start()
    {
        score = FindObjectOfType<ScorePlayer>();
    }

    void Update()
    {
        if(target != null)
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
            Destroy(gameObject);
        }
    }
}
