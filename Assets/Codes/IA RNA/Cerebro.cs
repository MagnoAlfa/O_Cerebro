using System;
using Unity.VisualScripting;
using UnityEngine;


public class Cerebro : MonoBehaviour
{
    [SerializeField] float[] entrada;
    [SerializeField] float[] saida;
    [SerializeField] bool ativo;
    [SerializeField] public string nomeRede;
    [SerializeField] int contagemNeuronio = 0;

    [SerializeField] public DadosMemoria _DadosMemoria = new DadosMemoria();


    private void Start()
    {
        
        entrada = new float[_DadosMemoria.neuroniCamaEtrada];
        //Retararar arquivos
        //Load("RNAS");
        Ativador();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Ativador();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            MostrarPesos(_DadosMemoria.peso);
        }
    }



    private void Ativador()
    {
        Debug.Log("Ativador " + nomeRede);
        ativo = true;
        contagemNeuronio = 0;
        float[] mediador;
        mediador = CamadaEntrada(entrada, _DadosMemoria.neuroniCamaEtrada);
        mediador = CamadaOcuta(mediador, _DadosMemoria.neuroniECamasOcuta);
        mediador = CamadaSaida(mediador, _DadosMemoria.neuroniCamaSaida);
        Debug.Log("Saida de Dados " + nomeRede);
        saida = mediador;
        ativo = false;

    }

    //Camadas
    //Camada de Entrada
    private float[] CamadaEntrada(float[] dEntra, int nCamada)
    {
        Debug.Log("CamadaEntrada");
        float[] tep = new float[nCamada];
        for (int n = 0; n < tep.Length; n++)
        {
            tep[n] = NeuronioEntrada(dEntra[n], _DadosMemoria.peso[contagemNeuronio][0], _DadosMemoria.bias[contagemNeuronio]);
            contagemNeuronio++;
        }

        return tep;
    }


    //Camada(s) Ocuta(s)

    private float[] CamadaOcuta(float[] dEntra, int[] nCamada)
    {
        Debug.Log("CamadaOcuta");
        float[] sup = dEntra;
        float[] tep;
        for (int c = 0; c < nCamada.Length; c++)
        {
            tep = new float[nCamada[c]];
            for (int n = 0; n < nCamada[c]; n++)
            {
                tep[n] = NeuronioOcuto(sup, _DadosMemoria.peso[contagemNeuronio], _DadosMemoria.bias[contagemNeuronio]);
                contagemNeuronio++;
            }
            sup = new float[tep.Length];
            sup = tep;
        }

        return sup;
    }

    //Camada de Saida

    private float[] CamadaSaida(float[] dEntra, int nCamada)
    {
        Debug.Log("CamadaSaida");
        float[] fim = new float[nCamada];
        for (int n = 0; n < nCamada; n++)
        {
            fim[n] = NeuronioSaida(dEntra, _DadosMemoria.peso[contagemNeuronio], _DadosMemoria.bias[contagemNeuronio]);
            contagemNeuronio++;
        }

        return fim;
    }

    //Neuronios

    private float NeuronioEntrada(float valor, float _peso, float _bias)
    {



        return _peso * valor + _bias;
    }

    private float NeuronioOcuto(float[] valor, float[] _peso, float _bias)
    {



        return soma(_peso, valor) + _bias;
    }

    private float NeuronioSaida(float[] valor, float[] _peso, float _bias)
    {



        return soma(_peso, valor) + _bias;
    }

    //Suporte do neuronio
    float soma(float[] _peso, float[] _entrada)
    {
        float _saida = 0;
        for (int i = 0; i < _entrada.Length; i++)
        {
            _saida += _peso[i] * _entrada[i];
        }
        return _saida;
    }

    void MostrarPesos(float[][] pesos)
    {
        string post = null;
        for (int c = 0; c < pesos.Length; c++)
        {
            Debug.Log("Neuronio: " + (c+1));
            for (int n = 0; n < pesos[c].Length; n++)
            {
                post += pesos[c][n]+", ";
            }
            Debug.Log(post);
            post = null;
        }
    }
}
