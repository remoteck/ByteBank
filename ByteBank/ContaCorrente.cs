using System;

namespace ByteBank {
    public class ContaCorrente {
        
        public Cliente Titular { get; set; }

        public static double TaxaOperacao { get; private set; }

        public static int TotalDeContasCriadas { get; private set; }

        public int Agencia { get; }
        
        public int Conta { get; }

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


        public ContaCorrente(int agenciaNumero, int contaNumero) {
            if (agenciaNumero <= 0) {
                throw new ArgumentException("Não foi possível criar agência menor que zero (0)", nameof(agenciaNumero));
                //ArgumentException equivale ao erro de argumento do construtor, diferente de só lançar Exception.
                //Utilizar 'nameof' para que seja necessário alterar quando a variável for modificada.
            }
            if (contaNumero <= 0) {
                throw new ArgumentException("Não foi possível criar conta menor que zero (0)!", nameof(contaNumero));
            }
            Agencia = agenciaNumero;
            Conta = contaNumero;
            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }


        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;

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