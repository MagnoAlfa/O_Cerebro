using System;
using Unity.VisualScripting;

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
    public MemoriaDados(int _qNeuronio, float[][] _pesos, float[] _bias) { qNeuronio = _qNeuronio; pesos = _pesos; bias = _bias; }
}



/*
struct MemoriaDadosV01
{
    //Dados da memoria
    bool ativo;
    int coluna;//Camada
    int linha;//Posição na Camada
    float bias;
    float[] pesos;


    //Dados da ligações
    //unsafe ref MemoriaDadosV01 proximoColuna;//Proximo na Camada
    //unsafe ref struct MemoriaDadosV01[] ligações;
    bool[] ativos;

    //Dados resutantes
    float[] valores;

}

[Serializable]
public class MemoriaDadosV0
{
    
    //Dados da memoria
    bool ativo;
    int coluna;//Camada
    int linha;//Posição na Camada
    float bias;
    float[] pesos;
    unsafe ref struct MemoriaDadosV01 proximoColuna;//Proximo na Camada
    unsafe ref struct MemoriaDadosV01[] ligações;
    bool[] ativos;

    //Dados resutantes
    float[] valores;


    public MemoriaDadosV0(){}
    public MemoriaDadosV0(int _coluna){}
}*/
