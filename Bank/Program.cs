using System;
using System.Collections.Generic;


namespace Bank{
    class Program{
        static List<Account> ac_list = new List<Account>();
        static void Main(string[] args){
           string operation = Menu();
           while(operation != "6"){
               switch(operation){
                    case "1":
                        op_add_ac();

                        break;
                    case "2":
                        op_list();
                        break;
                    case "3":
                        op_deposit();

                        break;
                    case "4":
                        op_withdraw();

                        break;
                    case "5":
                        op_transfer();

                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Insira valor válido!");
                        break;
                }
                Console.Clear();
                operation = Menu();
            }
            Console.Clear();
            Console.WriteLine("Obrigado por utilizar nossos serviços!");

        }

        private static void op_add_ac(){
            bool flag = true;
            float initial_balance = 0;
            Console.WriteLine("Insira o nome do Titular da conta:");
            string holder  = Console.ReadLine();
            Console.WriteLine("Insira o saldo inicial:");
            while(flag){
                initial_balance = float.Parse(Console.ReadLine());
                if(initial_balance < 0){
                    throw new InvalidOperationException(message: "Insira valor positivo");
                }else{
                    flag = false;
                }
            }
            Console.WriteLine("Insira o Tipo da Conta (1 ou 2):");
            Console.WriteLine("1 - Pessoa Fisica ou 2 - Pessoa Juridica");
            int ac_type  = int.Parse(Console.ReadLine());
            Account ac = new Account(holder,initial_balance,(AccountType)ac_type);
            ac_list.Add(ac);
            Console.WriteLine("Conta Registrada com sucesso!");
            Console.WriteLine("Conta de numero: {0}",ac_list.Count);
        }
        private static void op_list(){
            if(ac_list.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada ainda!");
            }else{
                int num = 0;
                foreach( Account ac in ac_list){
                    Console.Write("#{0}->",num);
                    ac.show();
                    num++;
                }
            }
            Console.ReadLine();
        }

        private static int idx_verifier(){
            bool f = true;
            int idx = 0;
            while(f){
                idx = int.Parse(Console.ReadLine());
                if(idx < 0 && idx > ac_list.Count){
                    Console.WriteLine("Numero de conta não existente! Tente novamente com um valor valido!");
                    idx = int.Parse(Console.ReadLine());
                }else{
                    f = false;
                    Console.WriteLine("Conta de {0} foi selecionada!", ac_list[idx].name);
                }
            }
            return idx;
        }
        private static void op_deposit(){
            Console.WriteLine("Insira o numero da conta para deposito:");
            int ac_idx = idx_verifier();
            Console.WriteLine("Insira o valor a ser depositado: ");
            float vl = float.Parse(Console.ReadLine());
            if(vl < 0.00){
                throw new InvalidOperationException(message: "Valor invalido");
                return;
            }
            ac_list[ac_idx].deposit(vl);
        }
        private static void op_withdraw(){
            Console.WriteLine("Insira numero da conta para saque:");
            int ac_idx = idx_verifier();
            Console.WriteLine("Insira valor a ser sacado: ");
            float vl = float.Parse(Console.ReadLine());
            if(vl > 0){
                throw new InvalidOperationException("Insira valor positivo!");
                return;
            }
            ac_list[ac_idx].withdraw(vl);

        }
        private static void op_transfer(){
            Console.WriteLine("Insira o numero da conta que irá transferir:");
            int ac_idx1 = idx_verifier();
            Console.WriteLine("Insira o numero da conta que receberá a transferencia:");
            int ac_idx2 = idx_verifier();
            Console.WriteLine("Insira o valor a ser transferido:");
            float vl = float.Parse(Console.ReadLine());
            if(vl > 0){
                throw new InvalidOperationException("Insira valor positivo!");
                return;
            }
            ac_list[ac_idx1].transfer(ac_list[ac_idx2],vl);
        }

        private static string Menu(){
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao Banco!\n Selecione uma operação digitando:");
            Console.WriteLine("1 - Adicionar conta");
            Console.WriteLine("2 - Listar contas");
            Console.WriteLine("3 - Depositar");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Transferir");
            Console.WriteLine("6 - Sair");
            Console.WriteLine();
            string r = Console.ReadLine();
            return r;
        }
    }
}
