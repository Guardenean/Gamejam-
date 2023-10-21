using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configurações Gerais")]
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;

    public bool noChao;

    [Header("Checador de chão")]
    public GameObject groundCheck;

    // Instância
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Mover();
        VerificarChao();
        Jump();
    }

    void Mover()
    {
        float movX = Input.GetAxis("Horizontal");

        Vector3 movimento = new Vector3(movX, 0, 0) * velocidade * Time.deltaTime;
        transform.Translate(movimento);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && noChao)
        {
            rb.AddForce(new Vector2(rb.velocity.x, forcaPulo), ForceMode2D.Impulse);
        }
    }

    void VerificarChao()
    {
        float raio = 0.1f;
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.transform.position, Vector2.down, raio);

        if (hit.collider != null)
        {
            noChao = true;
        }
        else
        {
            noChao = false;
        }
    }
}
