

using static NeuronioDadosV00;

public partial class NeuronioDadosV00
{
    struct NeuronioDados{
    //Dados da memoria
    bool ativo;
    int coluna;//Camada
    int linha;//Posição na Camada
    float bias;
    float[] pesos;

    

    //Dados da ligações
    bool[] ativos;

    //Dados resutantes
    float[] valores;
    }
}
