using ProjetoSenai.Model;

ExemploSenaiContext context = new ExemploSenaiContext();

while (true)
{
    Console.WriteLine("O que deseja fazer? 1 - Logar, " 
        + "2 - Registrar ou 3 - Sair");
    string num = Console.ReadLine();
    if (num == "1")
    {
        Console.Clear();
    }
    else if (num == "2")
    {
        Console.Clear();
    }
    else if (num == "3")
    {
        break;
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Operação Inválida");
    }
}