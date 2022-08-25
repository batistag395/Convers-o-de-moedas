using ConversaoDeMoedas;

Moedascs moedas;

List<Moedascs> MoedasList = new List<Moedascs>();

string[] text = System.IO.File.ReadAllLines(@"C:\Users\gorde\Desktop\Moeda\moedas.txt");

foreach (string line in text)
{
    string[] vect = line.Split(' ');
    moedas = new Moedascs(vect[0], double.Parse(vect[1]));
    MoedasList.Add(moedas);
}

Console.WriteLine("Imprimindo a lista");

foreach (Moedascs m in MoedasList)
{
    Console.WriteLine(m);
}
Console.WriteLine("Qual a moeda que voce possui? ");
string nomeMoedaEntrada = Console.ReadLine();

Console.WriteLine("Qual valor que voce quer converter?");
double valorMoedaOrigem = double.Parse(Console.ReadLine());

Console.WriteLine("Qual a moeda de saida para conversao?");
string nomeMoedaDestino = Console.ReadLine();

var moedaEntrada = from moeda in MoedasList
                   where moeda.Currency == nomeMoedaEntrada
                   select moeda.Rate;

var moedaSaida = from moeda in MoedasList
                 where moeda.Currency == nomeMoedaDestino
                 select moeda.Rate;

var siglaMoedaSaida = from moeda in MoedasList
                      where moeda.Currency == nomeMoedaDestino
                      select moeda.Currency;

foreach (var resultado in moedaEntrada)
{
    foreach (var moeda in moedaSaida)
    {
        foreach (var siglaMoedaDestino in siglaMoedaSaida)
        {
            Console.WriteLine($"Valor final da conversão sera de: {siglaMoedaDestino} {((resultado / moeda) * valorMoedaOrigem).ToString("F2")}");
        }
    }
}