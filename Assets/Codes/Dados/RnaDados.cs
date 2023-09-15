using System;

[Serializable]
public class RnaDados
{
    //Variáveis
    public int qMentes;
    public string[] nomeRede;
    public int[] nEtrada;
    public int[] nSaida;
    public int[][] cnOcuta;

    //Construtor vazio
    public RnaDados() { }

    //Construtor com dados
    public RnaDados(int _qMentes,string[] _nomeRede, int[] _nEtrada, int[] _nSaida, int[][] _cnOcuta)
    {
        qMentes = _qMentes;

        nomeRede = _nomeRede;

        nEtrada = _nEtrada;
        nSaida = _nSaida;
        cnOcuta = _cnOcuta;
    }
}