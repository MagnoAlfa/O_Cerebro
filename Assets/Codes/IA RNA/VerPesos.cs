using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;


public class VerPesos : MonoBehaviour
{
    [SerializeField] float[][] peso;

    private Cerebro GetCerebro()
    {
        return GetComponent<Cerebro>();
    }

    private void Start()
    {
        peso = GetCerebro()._DadosMemoria.peso;
    }



}