using System.Security.Cryptography;
using System.Collections.Generic;
using System.Drawing;

namespace MyByteBank
{
    public class Program
    {
        public static ContaCorrente contaLogada;

        static void Main(string[] args)
        {
            string opcaoMenu1;
            int opcaoMenu;


            List<ContaCorrente> conta = new List<ContaCorrente>();
            do
            {
                ShowMenu();
                opcaoMenu1 = Console.ReadLine();
                while (!String.Equals(opcaoMenu1, "0") && !String.Equals(opcaoMenu1, "1") && !String.Equals(opcaoMenu1, "2") && !String.Equals(opcaoMenu1, "3") && !String.Equals(opcaoMenu1, "4") && !String.Equals(opcaoMenu1, "5") && !String.Equals(opcaoMenu1, "6") ||  String.Equals(opcaoMenu1, null))
                {
                    Console.WriteLine();
                    Console.WriteLine("Opção inválida, tente novamente");
                    Console.WriteLine();
                    ShowMenu();
                    opcaoMenu1 = Console.ReadLine();
                }
                opcaoMenu = int.Parse(opcaoMenu1);

                Console.WriteLine("-----------------");

                switch (opcaoMenu)
                {
                    case 0:
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    case 1:
                        Console.WriteLine("Você digitou opção [1] - Inserir nova conta");
                        AdicionarConta(conta);
                        break;
                    case 2:
                        Console.WriteLine("Você digitou opção [2] - Deletar uma conta");
                        DeletarConta(conta);
                        break;
                    case 3:
                        Console.WriteLine("Você digitou opção [3] - Listar todas as contas registradas");
                        Console.WriteLine();
                        ContasRegistradas(conta);
                        break;
                    case 4:
                        Console.WriteLine("Você digitou opção [4] - Detalhes de uma conta");
                        ApresentarConta(conta);
                        break;

                    case 5:
                        Console.WriteLine("Você digitou opção [5] - Total armazenado no banco: ");
                        TotalDoBanco(conta);
                        break;
                    case 6:
                        string opcaoSubMenu1;
                        int opcaoSubmenu;
                        do
                        {
                            SubMenu();
                            opcaoSubMenu1 = Console.ReadLine();
                            while (!String.Equals(opcaoSubMenu1, "0") && !String.Equals(opcaoSubMenu1, "1") && !String.Equals(opcaoSubMenu1, "2") && !String.Equals(opcaoMenu1, "3") || String.Equals(opcaoSubMenu1, null))
                            {
                                Console.WriteLine();
                                Console.WriteLine("Opção inválida, tente novamente");
                                Console.WriteLine();
                                SubMenu();
                                opcaoSubMenu1 = Console.ReadLine();
                            }
                            opcaoSubmenu = int.Parse(opcaoSubMenu1);

                            
                            Console.WriteLine("-----------------");

                            switch (opcaoSubmenu)
                            {
                                case 0:
                                    Console.WriteLine("Sair");
                                    break;
                                case 1:
                                    Console.WriteLine("Você digitou opção [1] - Deposito");
                                    Depositar(conta);

                                    break;
                                case 2:
                                    Console.WriteLine("Você digitou opção [2] - Transferência");
                                    Transferir(conta);

                                    break;
                                case 3:
                                    Console.WriteLine("Você digitou opção [3] - Saque");
                                    Sacar(conta);

                                    break;

                            }
                        }
                        while (opcaoSubmenu!= 0);








                        break;




                }
                Console.WriteLine("-----------------");

            } while (opcaoMenu != 0);




            //Menu principal
            static void ShowMenu()
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("[1] - Inserir nova conta");
                Console.WriteLine("[2] - Deletar uma conta");
                Console.WriteLine("[3] - Listar todas as contas registradas");
                Console.WriteLine("[4] - Detalhes de uma conta");
                Console.WriteLine("[5] - Total armazenado no banco");
                Console.WriteLine("[6] - Manipular conta");
                Console.WriteLine("[0] - Sair do menu");
                Console.Write("Digite uma opção: ");

            }

            //Adicionar uma conta
            static void AdicionarConta(List<ContaCorrente> conta)
            {

                Console.WriteLine($"****Digite os dados da conta que deseja adicionar****");
                Console.WriteLine();
                Console.Write("Nome do titular da conta: ");
                string titular = Console.ReadLine();
                Console.Write("Digite o CPF do titular da conta: ");
                string cpf = Console.ReadLine();
                Console.Write("Crie uma senha: ");
                string senha = Console.ReadLine();
                Console.Write("Digite o saldo: ");
                double saldo = double.Parse(Console.ReadLine());
                conta.Add(new ContaCorrente(titular, cpf, senha, saldo));
                Console.WriteLine();
                Console.WriteLine($"Olá {titular}!! Seja bem-vindo ao ByteBank!");
            }

            //Deletar uma conta
            static void DeletarConta(List<ContaCorrente> conta)
            {

                Console.Write("Digite o CPF do titular da conta que você quer deletar: ");
                string contaDeletar = Console.ReadLine();
                int i = conta.FindIndex(cpf => cpf.Cpf == contaDeletar);

                if (i == -1 || contaDeletar == null)
                {
                    Console.WriteLine("CPF inválido");
                }
                else
                {
                    ContaCorrente c = conta.Find(cpf => cpf.Cpf == contaDeletar);
                    conta.Remove(c);
                    Console.WriteLine("Conta removida com sucesso");
                }

            }

            //Contas registradas
            static void ContasRegistradas(List<ContaCorrente> conta)
            {
                for (int i = 0; i < conta.Count; i++)
                {
                    Console.WriteLine(conta[i]);
                }
            }

            //Apresentar a conta
            static void ApresentarConta(List<ContaCorrente> conta)
            {
                Console.Write("Digite o CPF do titular da conta que você deseja ver detalhes: ");
                string contaApresentar = Console.ReadLine();
                int i = conta.FindIndex(cpf => cpf.Cpf == contaApresentar);

                Console.WriteLine(conta[i]);

            }

            //Total de dinheiro armazenado no banco
            static void TotalDoBanco(List<ContaCorrente> conta)
            {
                double total = 0;
                for (int i = 0; i < conta.Count; i++)
                {
                    total += conta[i].Saldo;
                }
                Console.WriteLine(total);
            }



            Console.WriteLine("Digite sua senha");


        }

        //SubMenu
        static void SubMenu()
        {
            Console.WriteLine("Digite a opção desejada");
            Console.WriteLine("[1] - Depósito");
            Console.WriteLine("[2] - Transferência");
            Console.WriteLine("[3] - Saque");
            Console.WriteLine("[0] - Sair");
            Console.Write("Digite uma opção: ");

        }




        static void Depositar(List<ContaCorrente> conta)

        {
            int i;
            do
            {

                Console.Write("Digite o seu CPF para fazer o login: ");
                string userName = Console.ReadLine();
                i = conta.FindIndex(cpf => cpf.Cpf == userName);
                if (i == -1)
                {
                    Console.WriteLine("CPF inválido.");
                }
            }
            while (i == -1);

            string senhaLogin;
            do
            {
                Console.Write("Digite sua senha:");
                senhaLogin = Console.ReadLine();
                if (senhaLogin != conta[i].Senha)
                {
                    Console.Write("Senha inválida.");
                }
            }


            while (senhaLogin != conta[i].Senha);

            ContaCorrente contaLogada = conta[i];

            Console.WriteLine($"Olá {contaLogada.Titular}, confira os dados da sua conta: ");
            Console.WriteLine(contaLogada);
            Console.WriteLine();
            Console.Write("Digite o valor a ser depositado: ");
            double valor = double.Parse(Console.ReadLine());
            contaLogada.Deposito(valor);
            Console.WriteLine("Esses são os dados depois do depósito:");
            Console.WriteLine();
            Console.WriteLine(contaLogada);
            Console.WriteLine();


        }




        static void Sacar(List<ContaCorrente> conta)

        {
            int i;
            do
            {

                Console.Write("Digite o seu CPF para fazer o login: ");
                string userName = Console.ReadLine();
                i = conta.FindIndex(cpf => cpf.Cpf == userName);
                if (i == -1)
                {
                    Console.WriteLine("CPF inválido.");
                }
            }
            while (i == -1);

            string senhaLogin;
            do
            {
                Console.Write("Digite sua senha:");
                senhaLogin = Console.ReadLine();
                if (senhaLogin != conta[i].Senha)
                {
                    Console.Write("Senha inválida.");
                }
            }


            while (senhaLogin != conta[i].Senha);

            ContaCorrente contaLogada = conta[i];

            Console.WriteLine($"Olá {contaLogada.Titular}, confira os dados da sua conta: ");
            Console.WriteLine(contaLogada);

            Console.Write("Digite o valor a que deseja sacar: ");
            double valor = double.Parse(Console.ReadLine());
            contaLogada.Saque(valor);
            Console.WriteLine("Esses são os dados depois do saque:");
            Console.WriteLine();
            Console.WriteLine(contaLogada);
            Console.WriteLine();


        }


        static void Transferir(List<ContaCorrente> conta)
        {
            int i,j;
            string cpfDestino;
            do
            {

                Console.Write("Digite o seu CPF para fazer o login: ");
                string userName = Console.ReadLine();
                i = conta.FindIndex(cpf => cpf.Cpf == userName);
                if (i == -1)
                {
                    Console.WriteLine("CPF inválido.");
                }
            }
            while (i == -1);

            string senhaLogin;
            do
            {
                Console.Write("Digite sua senha:");
                senhaLogin = Console.ReadLine();
                if (senhaLogin != conta[i].Senha)
                {
                    Console.Write("Senha inválida.");
                }
            }


            while (senhaLogin != conta[i].Senha);

            ContaCorrente contaLogada = conta[i];
            Console.WriteLine();
            Console.WriteLine($"Olá {contaLogada.Titular}, confira os dados da sua conta: ");
            Console.WriteLine(contaLogada);
            Console.WriteLine();

            ContaCorrente contaOrigem = contaLogada;
            do
            {
                Console.Write("Digite o CPF do titular da conta de destino: ");
                cpfDestino = Console.ReadLine();
                j = conta.FindIndex(cpf => cpf.Cpf == cpfDestino);
                
                if (j == -1)
                {
                    Console.WriteLine("CPF inválido.");
                }
                else if (j == i)
                {
                    Console.WriteLine("A conta de destino não pode ser a mesma conta da origem");
                }
            }
            while (j == -1 || j == i);

            ContaCorrente contaDestino = conta[j];
            Console.WriteLine();
            Console.WriteLine($"A transferência será realizada para {conta[j].Titular} ");
            Console.WriteLine();
            Console.Write("Digite o valor a que deseja transferir: ");
            double valor = double.Parse(Console.ReadLine());
            contaDestino.Transferencia(contaOrigem, contaDestino, valor);
            Console.WriteLine();
            Console.WriteLine("Esses são os dados depois da transferência:");
            Console.WriteLine();
            Console.WriteLine(contaOrigem);
            Console.WriteLine();
        }




    }
}













