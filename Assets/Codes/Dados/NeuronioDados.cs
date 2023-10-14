

public partial class NeuronioDados
{
    //Variáveis
    int cod;
    float bias;
    float[] pesos;


    //Construtor vazio
    public NeuronioDados() { }


    //Construtor com dados
    public NeuronioDados(int _Cod, float _Bias, float[] _Pesos) { cod = _Cod; bias = _Bias; pesos = _Pesos; }

}