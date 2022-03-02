// See https://aka.ms/new-console-template for more information
using DIO.Series;
using DIO.Series.Classes;
using  DIO.Series.Interfaces;

SerieRepositorio repositorio = new SerieRepositorio();
string opcaoUsuario = ObterOpcaoUsuario();

while(opcaoUsuario.ToUpper() != "X")
{
    switch(opcaoUsuario)
    {
        case "1":
         ListarSeries();
         break;
          case "2":
         InserirSerie();
         break;
          case "3":
         AtualizarSerie();
         break;
          case "4":
         ExcluirSerie();
         break;
          case "5":
         VisualizarSerie();
         break;
          case "C":
         Console.Clear();
         break;
          default:
         throw new ArgumentOutOfRangeException();
         
    }


}
System.Console.WriteLine("Obrigado por finalizar nossos serviços!!");
Console.ReadLine();

  void ListarSeries()
{
    System.Console.WriteLine("listar series");
    var lista = repositorio.Lista();

    if(lista.Count == 0){
        System.Console.WriteLine("nenhuma serie");
        return;
    }
    foreach(var serie in lista){
        var excluido = serie.retornaExcluido();
        System.Console.WriteLine("ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(),(excluido ? "'Excluido'" : ""));

    }
}
 void InserirSerie(){
    System.Console.WriteLine("Inserir Nova Serie");

    foreach( int i in Enum.GetValues(typeof(Genero)))
    {
        Console.WriteLine("{0} -{1}",i,Enum.GetName(typeof(Genero),i));

    }
    System.Console.WriteLine("digite o genero entre as opçoes acima: ");
    int entradaGenero = int.Parse(Console.ReadLine());

    System.Console.WriteLine("digite o titulo da serie: ");
    string entradaTtulo = Console.ReadLine(); 

    System.Console.WriteLine("digite o Ano de inicio da Serie: ");
    int entradaAno = int.Parse(Console.ReadLine());

    System.Console.WriteLine("digite a Descrição da Serie: ");
    string entradaDescricao = Console.ReadLine();
    Serie novaSerie =  new Serie(id: repositorio.ProximoId(),
                                genero: (Genero)entradaGenero,
                                titulo: entradaTtulo,
                                ano: entradaAno,
                                descricao: entradaDescricao);

    repositorio.Insere(novaSerie);                          

     ObterOpcaoUsuario();

}
void AtualizarSerie()
{
    System.Console.WriteLine("Digite o Id Serie");
    int indiceSerie = int.Parse(Console.ReadLine());

    foreach( int i in Enum.GetValues(typeof(Genero)))
    {
        Console.WriteLine("{0} -{1}",i,Enum.GetName(typeof(Genero),i));

    }
    System.Console.WriteLine("digite o genero entre as opçoes acima: ");
    int entradaGenero = int.Parse(Console.ReadLine());

    System.Console.WriteLine("digite o titulo da serie: ");
    string entradaTtulo = Console.ReadLine(); 

    System.Console.WriteLine("digite o Ano de inicio da Serie: ");
    int entradaAno = int.Parse(Console.ReadLine());

    System.Console.WriteLine("digite a Descrição da Serie: ");
    string entradaDescricao = Console.ReadLine();

    Serie atualizaSerie =  new Serie(id: indiceSerie,
                                genero: (Genero)entradaGenero,
                                titulo: entradaTtulo,
                                ano: entradaAno,
                                descricao: entradaDescricao);
    repositorio.Atualiza(indiceSerie, atualizaSerie);                          

}
void ExcluirSerie()
{
    System.Console.WriteLine("Digite o Id Serie");
    int indiceSerie = int.Parse(Console.ReadLine());
    repositorio.Exclui(indiceSerie);
}
void VisualizarSerie()
{
    System.Console.WriteLine("Digite o Id Serie");
    int indiceSerie = int.Parse(Console.ReadLine());

    var serie = repositorio.RetornaPorId(indiceSerie);
    Console.WriteLine(serie);
}


 static string ObterOpcaoUsuario()
{
    System.Console.WriteLine();
    System.Console.WriteLine("Dio series a seu dispor!!!");
    System.Console.WriteLine("Informe a Opção desejada");


    System.Console.WriteLine("1- Listar Series");
    System.Console.WriteLine("2- Inserir nova Serie");
    System.Console.WriteLine("3- Atualizar Serie");
    System.Console.WriteLine("4- Excluir Serie");
    System.Console.WriteLine("5 Visualizar Serie");
    System.Console.WriteLine("C - Limpar tela");
    System.Console.WriteLine("X- sair");
    System.Console.WriteLine();


    string opcaoUsuario = Console.ReadLine().ToUpper();
    Console.WriteLine();
    return opcaoUsuario;
















}