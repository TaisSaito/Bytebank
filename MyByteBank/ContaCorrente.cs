namespace MyByteBank
{
    public class ContaCorrente
    {
        
        public string Titular;
        public string Cpf;
        public string Senha;
        public double Saldo;
        public ContaCorrente(string titular, string cpf, string senha, double saldo)
        {
            Titular = titular;
            Cpf = cpf;
            Senha = senha;
            Saldo = saldo;
            
        }

        public ContaCorrente()
        {
        }

        public override string ToString()
        {
            return "Nome do titular: " + Titular + "   CPF: " + Cpf + "   Saldo: R$ " + Saldo.ToString("F2");
        }


        public void Deposito(double valor)
        {
            this.Saldo += valor;
        }

        public void Saque(double valor)
        {
            this.Saldo -= valor;
        }

        public void Transferencia(ContaCorrente contaOrigem, ContaCorrente contaDestino, double valor)
        {
            contaOrigem.Saldo -= valor;
            contaDestino.Saldo += valor;
        }
    }

}
