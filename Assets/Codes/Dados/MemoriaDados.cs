using System;

[Serializable]
public class MemoriaDados
{
    //Variáveis
    public int qNeuronio;
    public float[][] pesos;
    public float[] bias;


    //Construtor vazio
    public MemoriaDados() { }

    //Construtor com dados
    public MemoriaDados(int _qNeuronio, float[][] _pesos, float[] _bias){qNeuronio = _qNeuronio;pesos=_pesos;bias=_bias;}
}