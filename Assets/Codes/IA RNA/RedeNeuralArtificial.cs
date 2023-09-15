using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System;

public class RedeNeuralArtificial : MonoBehaviour
{


    //Variáveis da RNA
    [SerializeField] string nomeRede;
    [SerializeField] int nEtrada;
    [SerializeField] int nSaida;
    [SerializeField] int[] cnOcuta;
    [SerializeField] bool ativar;
    [SerializeField] GameObject[] cerebros;
    [SerializeField] Transform target;


    [SerializeField] RnaDados _RnaDados;


    //Variáveis do arquivo
    FileStream file = null;
    BinaryFormatter bf = new BinaryFormatter();


    //Variáveis de restauração de arquivo

    private void Start()
    {
        //Retararar arquivos
        //Load("RNAS");

    }



    public void Save(string oQue)
    {
        try
        {
            //Gera o arquivo onde vamos escrever os dados no caminho especificado
            file = File.Create(Application.persistentDataPath + "/" + oQue + ".cafe");
            //Serializa os dados em formato binário e escreve no arquivo
            if (oQue == nomeRede)
            {
                bf.Serialize(file, CriadorMemorias());
            }
            if (oQue == "RNAS")
            {
                bf.Serialize(file, _RnaDados);
            }
        }
        catch (Exception e)
        {
            //Imprime mensagem de erro no console
            Debug.Log(e.Message);
            Debug.Log(Application.persistentDataPath + "/" + oQue + ".cafe");
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

    public void Load(string oQue)
    {
        try
        {
            //Abre o arquivo no caminho especificado
            file = File.Open(Application.persistentDataPath + "/" + oQue + ".cafe", FileMode.Open);
            //Desserializa os dados no arquivo
            _RnaDados = (RnaDados)bf.Deserialize(file);
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


    private void Update()
    {
        if (ativar == true)
        {
            Rna("Mente_" + nomeRede, nEtrada, nSaida, cnOcuta);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Instantiate(Mente,target.position,target.rotation);
            Rna("Mente_" + nomeRede, nEtrada, nSaida, cnOcuta);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Instantiate(Mente,target.position,target.rotation);
            Save("RNAS");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Instantiate(Mente,target.position,target.rotation);
            Load("RNAS");
        }
        cerebros = GameObject.FindGameObjectsWithTag("CEREBRO");

        if (cerebros.Length > _RnaDados.qMentes)
        {
            Debug.Log("Etapa 1");
            GetDados();
        }

    }

    void Rna(string _nomeRede, int _nEtrada, int _nSaida, int[] _cnOcuta)
    {

        Save(_nomeRede);
        GameObject Mente = new GameObject(_nomeRede);
        Mente.tag = "CEREBRO";
        Mente.AddComponent<Cerebro>();

        Debug.Log("Etapa 0");

    }

    public void GetDados()
    {

        Debug.Log("Etapa 2");
        if (cerebros.Length > _RnaDados.qMentes)
        {
            RnaDados tem = new RnaDados();
            _RnaDados.qMentes++;

            Debug.Log(cerebros.Length);


            tem.nomeRede = new string[cerebros.Length];
            tem.nEtrada = new int[cerebros.Length];
            tem.nSaida = new int[cerebros.Length];
            tem.cnOcuta = new int[cerebros.Length][];

            for (int i = 0; i < cerebros.Length - 1; i++)
            {
                tem.nomeRede[i] = _RnaDados.nomeRede[i];
                tem.nEtrada[i] = _RnaDados.nEtrada[i];
                tem.nSaida[i] = _RnaDados.nSaida[i];
                tem.cnOcuta[i] = _RnaDados.cnOcuta[i];
            }


            tem.nomeRede[cerebros.Length - 1] = "Mente_" + nomeRede;
            Debug.Log(nomeRede);
            tem.nEtrada[cerebros.Length - 1] = nEtrada;
            Debug.Log(nEtrada);
            tem.nSaida[cerebros.Length - 1] = nSaida;
            Debug.Log(nSaida);
            tem.cnOcuta[cerebros.Length - 1] = cnOcuta;
            Debug.Log(cnOcuta);

            _RnaDados.nomeRede = tem.nomeRede;
            _RnaDados.nEtrada = tem.nEtrada;
            _RnaDados.nSaida = tem.nSaida;
            _RnaDados.cnOcuta = tem.cnOcuta;

            Debug.Log("Etapa 3");
        }

        Debug.Log("Etapa 4");
        Save("RNAS");
    }

    public MemoriaDados CriadorMemorias()
    {
        int _qNeuronio = 0;
        int maiorCamada = 0;


        if (maiorCamada < nEtrada) { maiorCamada = nEtrada; }
        _qNeuronio += nEtrada;
        _qNeuronio += nSaida;

        for (int c = 0; c < cnOcuta.Length; c++)
        {
            if (maiorCamada < cnOcuta[c]) { maiorCamada = cnOcuta[c]; }
            _qNeuronio += cnOcuta[c];
        }
        if (maiorCamada < nSaida) { maiorCamada = nSaida; }

        float[][] _pesos = new float[_qNeuronio][];
        for (int n = 0; n < _pesos.Length; n++)
        {
            _pesos[n] = new float[maiorCamada];
        }


        float[] _bias = new float[_qNeuronio];

        for (int d = 0; d < _qNeuronio; d++)
        {
            _bias[d] = 1;
            for (int n = 0; n < _pesos[d].Length; n++)
            {
                _pesos[d][n] = 1;
            }
        }


        return new MemoriaDados(_qNeuronio, _pesos, _bias);
    }

}
