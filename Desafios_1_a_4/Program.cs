using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {

    }

    private void Exercicio4()
    {
        bool Compra = false;
        bool CartaoTabajara = false;
        double TotalCompra = 0;
        double descontoTabajara = 0;
        string tipoCarne = string.Empty;
        string respostaCartao = string.Empty;
        int quantidade = 0;
        double PrecoPorKG = 0;
        List<double> PrecoKGLista = new List<double>();
        List<int> QuantidadeLista = new List<int>();
        do
        {
            Console.WriteLine("Promoção de Carnes:");
            Console.WriteLine("Até 5 Kg \t Acima de 5 Kg");
            Console.WriteLine("File Duplo \t R$ 4,90 por Kg \t R$ 5,80 por Kg");
            Console.WriteLine("Alcatra \t R$ 5,90 por Kg \t R$ 6,80 por Kg");
            Console.WriteLine("Picanha \t R$ 6,90 por Kg \t R$ 7,80 por Kg");

            Console.Write("\nDigite o tipo de carne (File Duplo, Alcatra ou Picanha): \n");
            tipoCarne = Console.ReadLine().Trim();
            Console.Write("Digite a quantidade (em Kg): \n");
            quantidade = int.Parse(Console.ReadLine());
            QuantidadeLista.Add(quantidade);
            if (!CartaoTabajara)
            {
                Console.Write("A compra será realizada com cartão Tabajara? (S/N): \n");
                respostaCartao = Console.ReadLine().ToUpper().Trim();
                CartaoTabajara = respostaCartao == "S" ? true : false;
            }

            Console.Write("Deseja continuar comprando? (S/N) \n");
            var respostaCompra = Console.ReadLine().ToUpper().Trim();

            Compra = respostaCompra == "S" ? true : false;

            switch (tipoCarne)
            {
                case "File Duplo":
                case "file duplo":
                    if (quantidade <= 5)
                    {
                        PrecoPorKG = 4.90;
                        PrecoKGLista.Add(PrecoPorKG);
                    }
                    else
                    {
                        PrecoPorKG = 5.80;
                        PrecoKGLista.Add(PrecoPorKG * quantidade);
                    }
                    break;

                case "Alcatra":
                case "alcatra":
                    if (quantidade <= 5)
                    {
                        PrecoPorKG = 5.90;
                        PrecoKGLista.Add(PrecoPorKG * quantidade);
                    }
                    else
                    {
                        PrecoPorKG = 6.80;
                        PrecoKGLista.Add(PrecoPorKG * quantidade);
                    }
                    break;

                case "Picanha":
                case "picanha":
                    if (quantidade <= 5)
                    {
                        PrecoPorKG = 6.90;
                        PrecoKGLista.Add(PrecoPorKG * quantidade);
                    }
                    else
                    {
                        PrecoPorKG = 7.80;
                        PrecoKGLista.Add(PrecoPorKG * quantidade);
                    }
                    break;

                default:
                    Console.WriteLine("Tipo da carne inválida");
                    break;
            }

        } while (Compra != false);

        TotalCompra = PrecoKGLista.Sum();

        if (CartaoTabajara)
        {
            descontoTabajara = 0.05 * TotalCompra;
        }

        var ValorAPagar = TotalCompra - descontoTabajara;

        Console.WriteLine("\n ================================= Cupom Fiscal ================================= \n");
        Console.WriteLine($"Tipo de carne: {tipoCarne}");
        Console.WriteLine($"Quantidade: {QuantidadeLista.Sum()} Kg");
        Console.WriteLine($"Preço total: R$ {TotalCompra:F2}");
        Console.WriteLine($"Tipo de pagamento: {(respostaCartao.ToUpper() == "S" ? "Cartão Tabajara" : "Outro")}");
        Console.WriteLine($"Valor do desconto: R$ {descontoTabajara:F2}");
        Console.WriteLine($"Valor a pagar: R$ {ValorAPagar:F2}");
    }
    private void Exercicio3()
    {
        double[] salarioMinimo = { 200, 300, 400, 500, 600, 700, 800, 900 };
        double[] salarioMaximo = { 299, 399, 499, 599, 699, 799, 899, 999 };
        Console.WriteLine("Quantos vendedores a loja tem?");

        List<int> contadores = new List<int>(new int[int.Parse(Console.ReadLine())]);
        int NumVendedores = contadores.Count;

        for (int i = 0; i < NumVendedores; i++)
        {
            int contadorAtual = i + 1;
            Console.WriteLine($"Quanto o vendedor {contadorAtual} recebeu?");

            var ValorSalario = double.Parse(Console.ReadLine());

            double SalarioComBonus = 200 + (0.09 * ValorSalario);
            Console.WriteLine($"O valor {SalarioComBonus} está dentro do intervalo entre {salarioMinimo[i]} e {salarioMaximo[i]}");

        }
    }
    private void Exercicio2()
    {
        string[] opcoes = { "Windows", "Unix", "Linux", "Netware", "Mac OS", "Outro" };
        int[] votos = new int[6];
        int contador = 0;
        int valorVoto = 0;
        int TotalVoto = 0;

        do
        {
            Console.WriteLine("Digite o número correspondente ao Sistema Operacional (ou 0 para sair):");
            Console.WriteLine("1- Windows\n2- Unix\n3- Linux\n4- Netware\n5- Mac OS\n6- Outro");

            valorVoto = int.Parse(Console.ReadLine());

            if (valorVoto <= 6 && valorVoto >= 0)
            {
                votos[contador] = valorVoto;
                contador++;
                TotalVoto++;
            }
            else if (valorVoto != 0)
            {
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção de 1 a 6.");
            }

        } while (valorVoto != 0);

        int totalVotos = 0;
        foreach (int v in votos)
        {
            totalVotos += v;
        }
        Console.WriteLine("\nQual o melhor Sistema Operacional para uso em servidores?");
        Console.WriteLine("Sistema Operacional\tVotos\t%");
        Console.WriteLine("-------------------\t-----\t---");
        for (int i = 0; i < opcoes.Length; i++)
        {
            double percentual = (double)votos[i] / totalVotos * 100;
            Console.WriteLine($"{opcoes[i]}\t\t\t{votos[i]}\t{(int)percentual}%:F2");
        }
        Console.WriteLine("-------------------\t-----\t---");
        Console.WriteLine($"Total\t\t\t{totalVotos}");

        int maxVotos = 0;
        int indiceVencedor = 0;
        for (int i = 0; i < votos.Length; i++)
        {
            if (votos[i] > maxVotos)
            {
                maxVotos = votos[i];
                indiceVencedor = i;
            }
        }
        double percentualVencedor = (double)maxVotos / totalVotos * 100;
        Console.WriteLine($"\nO Sistema Operacional mais votado foi o {opcoes[indiceVencedor]}, com {maxVotos} votos, correspondendo a {(int)percentualVencedor}% dos votos.");
    }
    private void Exercicio1()
    {
        Console.WriteLine("Digite o valor do Salário:");
        double salario = double.Parse(Console.ReadLine());

        double aumento = 0;

        if (salario == 280.00)
        {
            aumento = salario * 0.20;
        }
        else if (salario <= 700.00)
        {
            aumento = salario * 0.15;
        }
        else if (salario <= 1500.00)
        {
            aumento = salario * 0.10;
        }
        else
        {
            aumento = salario * 0.05;
        }

        double novosalario = salario + aumento;


        Console.WriteLine($"Salário antes do reajuste: R$ {salario:F2}");

        Console.WriteLine($"Aumento: R$ {aumento:F2}");

        Console.WriteLine($"Novo salário: R$ {novosalario:F2}");
    }
}
