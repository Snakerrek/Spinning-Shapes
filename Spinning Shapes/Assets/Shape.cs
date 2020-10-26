using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [SerializeField] float shrinkSpeed = 5.0f;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = new Vector3(15f, 15f, 15f);
    }

    void Update()
    {
        Shrink();
    }

    void Shrink()
    {
        Vector3 scaleFactor = new Vector3(1.0f, 1.0f, 1.0f) * shrinkSpeed * Time.deltaTime;
        transform.localScale -= scaleFactor;

        if (transform.localScale.x <= 0.1f)
            Destroy(gameObject);
    }


}
