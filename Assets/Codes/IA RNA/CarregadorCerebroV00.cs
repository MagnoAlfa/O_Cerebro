using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class CarregadorCerebroV00 : MonoBehaviour{

    //Variáveis do arquivo
    FileStream file = null;
    BinaryFormatter bf = new BinaryFormatter();


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