using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransferenciaBancariaComNet.Models;

namespace TransferenciaBancariaComNet
{
    public class Program

    {

        static List<Conta> list = new List<Conta>();


        public static void Main(string[] args)
        {


            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {

                switch (opcaoUsuario)
                {
                    case "1":
                        ListaConta();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Tranferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();


            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();

           
        }

        private static void Tranferir()
        {
            Console.Write("Digite o numero da conta de Origem:");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite o numero da conta de Destino:");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser transferido");
            double valorTranferencia = double.Parse(Console.ReadLine());

            list[indiceContaOrigem].Transferir(valorTranferencia, list[indiceContaDestino]);

        }

        private static void Depositar()
        {
            Console.Write("Digite o numero da conta:");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser Depositado");
            double valorDeposito = double.Parse(Console.ReadLine());

            list[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta:");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser sacado");
            double valorSaque = double.Parse(Console.ReadLine());

            list[indiceConta].Sacar(valorSaque);
        }

        private static void ListaConta()
        {
            Console.WriteLine("Lista contas ");
           if(list.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
           for(int i=0;i< list.Count; i++)
            {
                Conta conta = list[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.Write("Digite 1 para conta Fisica e 2 para conta Juridica");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o Nome do Clinte:");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Credito");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta( tipoConta: (TipoConta)entradaTipoConta,
                                         saldo: entradaSaldo,
                                         credito: entradaCredito,
                                         nome: entradaNome);
            list.Add(novaConta);

        }

        private static string ObterOpcaoUsuario()
        {

            Console.WriteLine();
            Console.WriteLine("Banco ao seu dispor!");
            Console.WriteLine("Informe a opção desejada");


            Console.WriteLine("1 - Listar contar");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine(" C - Limpar Tela");
            Console.WriteLine(" X - Sair");
            Console.WriteLine();
            string opçaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opçaoUsuario;
        }


    }
}
