using System;

namespace ByteBank {
    class Program {
        static void Main(string[] args) {

            try {
                ContaCorrente conta = new ContaCorrente(0, 0);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(ContaCorrente.TaxaOperacao);
            Console.WriteLine(ContaCorrente.TotalDeContasCriadas);
        }
    }
}
