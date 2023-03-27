using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pont_platafoma : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float velocidade = 1f;
    public float alturaInicial = 0f;

    private Vector3 posicaoInicial;
    
    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float flutuacao = alturaInicial + amplitude * Mathf.Sin (velocidade * Time.time);
        transform.position = new Vector3 (transform.position.x, flutuacao, transform.position.z);
    }
}
