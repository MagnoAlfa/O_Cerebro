using System;

[Serializable]
public class SaveCesrebos
{
    //Variáveis
    public DadosMemoria[] _DadosMemoria;


    //Construtor vazio
    public SaveCesrebos() { }

    //Construtor com dados
    public SaveCesrebos(DadosMemoria[] _dadosMemoria)
    { _DadosMemoria = _dadosMemoria; }
}