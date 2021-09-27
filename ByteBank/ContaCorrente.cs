using System;

namespace ByteBank {
    public class ContaCorrente {
        
        public Cliente Titular { get; set; }

        public static double TaxaOperacao { get; private set; }

        public static int TotalDeContasCriadas { get; private set; }

        public int Agencia { get; }
        
        public int Numero { get; }

        private double _saldo = 100;

        public double Saldo {
            get {
                return _saldo;
            }
            set {
                if (value < 0) {
                    return;
                }

                _saldo = value;
            }
        }


        public ContaCorrente(int agencia, int numero) {
            if (agencia <= 0 || numero <= 0) {
                throw new ArgumentException("Não foi possível criar agência e/ou conta!");
                //ArgumentException equivale ao erro de argumento do construtor, diferente de só lançar Exception.
            }
            Agencia = agencia;
            Numero = numero;
            
            try {
                TaxaOperacao = 30 / TotalDeContasCriadas;
            }
            catch (DivideByZeroException e) {
                Console.WriteLine(e.Message);
                throw;
            }
            TotalDeContasCriadas++;
        }


        public bool Sacar(double valor) {
            if (_saldo < valor) {
                return false;
            }

            _saldo -= valor;
            return true;
        }

        public void Depositar(double valor) {
            _saldo += valor;
        }


        public bool Transferir(double valor, ContaCorrente contaDestino) {
            if (_saldo < valor) {
                return false;
            }

            _saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
}