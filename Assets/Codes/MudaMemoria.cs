using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class MudaMemoria : MonoBehaviour
{
    DadosMemoria dadosMemoria;
    private void Start() {
        dadosMemoria = GetComponent<Cerebro>()._DadosMemoria;
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Radomisador();
        }
    }


    void Radomisador()
    {
        for (int c = 0; c < dadosMemoria.peso.Length; c++)
        {
            for (int n = 0; n < dadosMemoria.peso[c].Length; n++)
            {
                dadosMemoria.peso[c][n] = Random.Range(-1.0f, 1.0f);
            }
        }


        for (int b = 0; b < dadosMemoria.bias.Length; b++)
        {
            dadosMemoria.bias[b] = Random.Range(-1.0f, 1.0f);
        }


    }

}