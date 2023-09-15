using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CriadorCerebro : MonoBehaviour
{


    //Variáveis da RNA
    [SerializeField] string nomeRede;
    [SerializeField] int nEtrada;
    [SerializeField] int nSaida;
    [SerializeField] int[] cnOcuta;
    [SerializeField] bool ativar;
    [SerializeField] GameObject[] cerebros;//Salvar
    [SerializeField] Transform target;
    [SerializeField] SaveCesrebos save = new SaveCesrebos();



    //Variáveis do arquivo
    FileStream file = null;
    BinaryFormatter bf = new BinaryFormatter();


    //Variáveis de restauração de arquivo
    int loadCerebro;
    private void Start()
    {
        //Retararar arquivos
        loadCerebro = 0;
        Load("Mentes");
        for (loadCerebro = 0; loadCerebro < save._DadosMemoria.Length; loadCerebro++)
        {
            CriaMente(save._DadosMemoria[loadCerebro].nomeRede, save._DadosMemoria[loadCerebro].neuroniCamaEtrada, save._DadosMemoria[loadCerebro].neuroniCamaSaida, save._DadosMemoria[loadCerebro].neuroniECamasOcuta, false);
        }

    }
    private void Update()
    {
        cerebros = GameObject.FindGameObjectsWithTag("CEREBRO");
        if (Input.GetKeyDown(KeyCode.E))
        {
            ativar = true;
            CriaMente(nomeRede, nEtrada, nSaida, cnOcuta, true);
            ativar = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save("Mentes");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Load("Mentes");
            for (int i = 0; i < save._DadosMemoria.Length; i++)
            {
                CriaMente(save._DadosMemoria[i].nomeRede, save._DadosMemoria[i].neuroniCamaEtrada, save._DadosMemoria[i].neuroniCamaSaida, save._DadosMemoria[i].neuroniECamasOcuta, false);
            }
        }
    }

    void CriaMente(string _nomeRede, int _nEtrada, int _nSaida, int[] _cnOcuta, bool novo)
    {
        GameObject Mente = new GameObject(_nomeRede);
        Mente.tag = "CEREBRO";
        Mente.AddComponent<Cerebro>();
        Mente.GetComponent<Cerebro>().nomeRede = _nomeRede;
        Mente.GetComponent<Cerebro>()._DadosMemoria.nomeRede = _nomeRede;
        Mente.GetComponent<Cerebro>()._DadosMemoria.neuroniCamaEtrada = _nEtrada;
        Mente.GetComponent<Cerebro>()._DadosMemoria.neuroniCamaSaida = _nSaida;
        Mente.GetComponent<Cerebro>()._DadosMemoria.neuroniECamasOcuta = _cnOcuta;

        int nNeuronio = 0;
        nNeuronio = _nEtrada + _nSaida;
        for (int i = 0; i < _cnOcuta.Length; i++)
        {
            nNeuronio += _cnOcuta[i];
        }

        float[] _bias = new float[nNeuronio];
        float[][] pesos = new float[nNeuronio][];
        int cotador = 0;
        for (int i = 0; i < _nEtrada; i++)
        {
            pesos[i] = new float[1];
            cotador++;
        }
        int definidor = _nEtrada;
        for (int c = 0; c < _cnOcuta.Length; c++)
        {

            for (int n = 0; n < _cnOcuta[c]; n++)
            {
                pesos[cotador] = new float[definidor];
                cotador++;
            }
            definidor = _cnOcuta[c];
        }
        for (int i = 0; i < _nSaida; i++)
        {
            pesos[cotador] = new float[definidor];
            cotador++;
        }

        if (novo == true)
        {
            for (int c = 0; c < pesos.Length; c++)
            {
                for (int n = 0; n < pesos[c].Length; n++)
                {
                    pesos[c][n] = 1;
                }
            }
            for (int b = 0; b < _bias.Length; b++)
            {
                _bias[b] = 1;
            }

            Mente.GetComponent<Cerebro>()._DadosMemoria.peso = pesos;
            Mente.GetComponent<Cerebro>()._DadosMemoria.bias = _bias;

        }
        else { Mente.GetComponent<Cerebro>()._DadosMemoria.peso = save._DadosMemoria[loadCerebro].peso; Mente.GetComponent<Cerebro>()._DadosMemoria.bias = save._DadosMemoria[loadCerebro].bias; }



        Debug.Log("Mente " + _nomeRede + " Criada");

    }

    public void Save(string oQue)
    {
        save._DadosMemoria = new DadosMemoria[cerebros.Length];
        for (int s = 0; s < save._DadosMemoria.Length; s++)
        {
            save._DadosMemoria[s] = cerebros[s].GetComponent<Cerebro>()._DadosMemoria;
        }
        try
        {
            //Gera o arquivo onde vamos escrever os dados no caminho especificado
            file = File.Create(Application.persistentDataPath + "/" + oQue + ".cafe");
            //Serializa os dados em formato binário e escreve no arquivo
            bf.Serialize(file, save);
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
            save = (SaveCesrebos)bf.Deserialize(file);
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
}