using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extintor : MonoBehaviour
{
    public float cargaMaxima = 100.0f; // Carga máxima do extintor
    public float taxaDeUso = 10.0f; // Taxa de uso do extintor
    private float cargaAtual; // A carga atual do extintor
    public ParticleSystem fogo; // Referência à partícula de fogo
    private bool segurandoExtintor = false; // Para rastrear se o jogador está segurando o extintor

    void Start()
    {
        RecarregarExtintor();
    }

    void Update()
    {
        if (segurandoExtintor)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                UsarExtintor();
            }
        }
    }

    void PegarExtintor()
    {
        // Lógica para pegar o extintor
        gameObject.SetActive(false); // Desativa o extintor no jogo
        segurandoExtintor = true;
    }

    void DeixarExtintor()
    {
        // Lógica para deixar o extintor
        gameObject.SetActive(true); // Ativa o extintor no jogo novamente
        segurandoExtintor = false;
    }

    void UsarExtintor()
    {
        if (segurandoExtintor && cargaAtual > 0)
        {
            fogo.emissionRate -= taxaDeUso * Time.deltaTime;
            cargaAtual -= taxaDeUso * Time.deltaTime;

            if (fogo.emissionRate <= 0)
            {
                // Toda a chama foi apagada
                // Implemente a lógica de vitória ou próxima fase aqui
            }
        }
    }

    void RecarregarExtintor()
    {
        cargaAtual = cargaMaxima;
    }
}
