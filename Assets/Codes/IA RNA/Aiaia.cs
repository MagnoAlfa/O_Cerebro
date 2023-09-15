using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiaia : MonoBehaviour
{
    [SerializeField] private float[] entrada;
    [SerializeField] private float[] peso;
    [SerializeField] private float bias;
    [SerializeField] private float saida;


    // Start is called before the first frame update
    void Start()
    {
        saida = soma(peso, entrada) + bias;
        Debug.Log(saida);
    }

    // Update is called once per frame
    void Update()
    {

    }

    float soma(float[] _peso, float[] _entrada)
    {
        float _saida = 0;
        for (int i = 0; i < entrada.Length; i++)
        {
            _saida += _peso[i] * _entrada[i];
        }
        return _saida;
    }

}
