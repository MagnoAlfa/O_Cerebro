using System;

[Serializable]
public class DadosMemoria
{
    //Variáveis
    public string nomeRede ="ff";
    public int neuroniCamaEtrada = 3;
    public int neuroniCamaSaida = 2;
    public int[] neuroniECamasOcuta = { 4, 3 };
    public float[][] peso ={
    new float[] {  1},
    new float[] {  1},
    new float[] {  1},
    new float[] {  1,  1, 1},
    new float[] {  1,  1, 1},
    new float[] {  1,  1, 1},
    new float[] {  1,  1, 1},
    new float[] {  1,  1, 1, 1},
    new float[] {  1,  1, 1, 1},
    new float[] {  1,  1, 1, 1},
    new float[] {  1, 1, 1},
    new float[] {  1, 2, 1}};
    public float[] bias = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };


    //Construtor vazio
    public DadosMemoria() { }

    //Construtor com dados
    public DadosMemoria(string _nomeRede, int _neuroniCamaEtrada, int _neuroniCamaSaida, int[] _neuroniECamasOcuta, float[][] _peso, float[] _bias)
    { nomeRede = _nomeRede; neuroniCamaEtrada = _neuroniCamaEtrada; neuroniCamaSaida = _neuroniCamaSaida; neuroniECamasOcuta = _neuroniECamasOcuta; peso = _peso; bias = _bias; }
}