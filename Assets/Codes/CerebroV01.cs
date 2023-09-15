using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class CerebroV01 : MonoBehaviour
{
    [SerializeField] private string nomeMemoria;
    [SerializeField] private int numeroMemoria;
    [SerializeField] private bool ativo;
    [SerializeField] private float[] entradaDados;
    [SerializeField] private float[] saidaDados;


    //Variáveis do arquivo
    FileStream file = null;
    BinaryFormatter bf = new BinaryFormatter();
    [SerializeField] private int neuronioAtivo = 0;
    [SerializeField] MemoriaDados memoriaDados;
    [SerializeField] RnaDados rnaDados;

    private void Start()
    {
        rnaDados = new RnaDados();
        memoriaDados = new MemoriaDados();

        Load("RNAS");
        Load(transform.name);
        if (nomeMemoria != transform.name)
        {
            for (int i = 0; i < rnaDados.nomeRede.Length; i++)
            {
                if (rnaDados.nomeRede[i] == transform.name)
                {
                    nomeMemoria = rnaDados.nomeRede[i];
                    numeroMemoria = i;
                    break;
                }
            }
        }
        entradaDados = new float[rnaDados.nEtrada.Length];
    }

    private void Update()
    {
        if (ativo == true)
            Ativador();
    }

    public void Load(string oQue)
    {
        try
        {
            //Abre o arquivo no caminho especificado
            file = File.Open(Application.persistentDataPath + "/" + oQue + ".cafe", FileMode.Open);
            //Desserializa os dados no arquivo
            if (oQue == transform.name)
            {
                memoriaDados = (MemoriaDados)bf.Deserialize(file);
            }
            if (oQue == "RNAS")
            {
                rnaDados = (RnaDados)bf.Deserialize(file);
            }
        }
        catch (Exception e)
        {
            //Imprime mensagem de erro no console
            Debug.Log(e.Message);
        }
        finally
        {
            //Fecha o caminho para o arquivo se ele não estiver vazio. Não fazer isso pode causar vazamento de memória (Memory Leak)
            if (file != null)
            {
                file.Close();
            }
        }
    }

    private void Ativador()
    {
        Debug.Log("Ativador");
        float[] mediador;
        mediador = CamadaEntrada(entradaDados, rnaDados.nEtrada[numeroMemoria]);
        mediador = CamadaOcuta(mediador, rnaDados.cnOcuta[numeroMemoria]);
        mediador = CamadaSaida(mediador, rnaDados.nSaida[numeroMemoria]);
        saidaDados = mediador;
        neuronioAtivo = 0;
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
            tep[n] = NeuronioEntrada(dEntra[n], memoriaDados.pesos[neuronioAtivo][0], memoriaDados.bias[neuronioAtivo]);
            neuronioAtivo++;
        }

        return tep;
    }


    //Camada(s) Ocuta(s)

    private float[] CamadaOcuta(float[] dEntra, int[] nCamada)
    {
        Debug.Log("CamadaOcuta");
        float[] fim = new float[nCamada[nCamada.Length - 1]];
        float[] sup = dEntra;
        float[] tep;
        for (int c = 0; c < nCamada.Length; c++)
        {
            tep = new float[nCamada[c]];
            for (int n = 0; n < nCamada[c]; n++)
            {
                tep[n] = NeuronioOcuto(sup, memoriaDados.pesos[0], memoriaDados.bias[0]);
                neuronioAtivo++;
            }
            sup = new float[tep.Length];
            sup = tep;
        }
        fim = sup;
        return fim;
    }

    //Camada de Saida

    private float[] CamadaSaida(float[] dEntra, int nCamada)
    {
        Debug.Log("CamadaSaida");
        float[] fim = new float[nCamada];
        for (int n = 0; n < nCamada; n++)
        {
            fim[n] = NeuronioSaida(dEntra, memoriaDados.pesos[0], memoriaDados.bias[0]);
            neuronioAtivo++;
        }

        return fim;
    }

    //Neuronios

    private float NeuronioEntrada(float valor, float peso, float bias)
    {



        return peso * valor + bias;
    }

    private float NeuronioOcuto(float[] valor, float[] peso, float bias)
    {



        return soma(peso, valor) + bias;
    }

    private float NeuronioSaida(float[] valor, float[] peso, float bias)
    {



        return soma(peso, valor) + bias;
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
}
