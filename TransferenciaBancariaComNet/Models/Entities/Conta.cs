using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransferenciaBancariaComNet.Models
{
    public class Conta
    {
      

        private TipoConta TipoConta{ get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome{ get; set; }
       
        
        
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }
        // Sacar

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo -valorSaque <(this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta  de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        //Depositar
        public void Depositar (double valoDeposito)
        {
            this.Saldo += valoDeposito;
            Console.WriteLine("Saldo atual da conta  de {0} é {1}", this.Nome, this.Saldo);

        }

        // transferir
        public void Transferir (double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta" + this.TipoConta + " | ";
            retorno += "Nome" + this.Nome + " | ";
            retorno += "Saldo" + this.Saldo + " | ";
            retorno += "Credito" + this.Credito ;
            return retorno;

        }

    }
}
