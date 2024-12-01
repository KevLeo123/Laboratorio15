using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoDeBala : MonoBehaviour
{
    public float VelocidadDeDisparo;
    public GameObject explosioPrefab;
    private PointManager pointManager;

    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.up * VelocidadDeDisparo * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosioPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            pointManager.UpdateScore(100);
            Destroy(gameObject);
        }
    }
}
