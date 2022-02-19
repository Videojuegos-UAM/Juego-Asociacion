using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [Header ("Score")]
    [SerializeField] private ScoreUpdate _scoreUpdater;
    [SerializeField] private int _score;

    [Header("Gravity")]
    [SerializeField] private float minGravity;
    [SerializeField] private float maxGravity;

    private void Awake()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = Random.Range(minGravity, maxGravity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _scoreUpdater.score = _score;
            _scoreUpdater.Fire();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
