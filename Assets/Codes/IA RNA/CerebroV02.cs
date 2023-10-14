using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class CerebroV02 : MonoBehaviour
{
    [SerializeField] private float[] entradaDados;
    [SerializeField] private float[] saidaDados;


    //Variáveis do arquivo
    FileStream file = null;
    BinaryFormatter bf = new BinaryFormatter();
    [SerializeField] private int neuronioAtivo = 0;
    [SerializeField] MemoriaDados memoriaDados;
    [SerializeField] RnaDados rnaDados;
}