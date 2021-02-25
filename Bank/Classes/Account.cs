using System;

namespace Bank
{
    public class Account
    {
        public string name;

        private float ac_balance{get;set;}
        private AccountType type{get;set;}

        public Account(string name, float balance, AccountType t){
            this.name = name;
            ac_balance = balance;
            type = t;
            Console.WriteLine("Conta Cadastrada!");
        }
 
        public void deposit(float value){
            this.ac_balance += value;
            Console.WriteLine("Depósito no valor de R${0:0.00} efetuado", value);
            Console.WriteLine("A conta de {0} tem saldo de R$ {1:0.00}", this.name, this.ac_balance);
        }
        public void withdraw(float value){
            if(value > this.ac_balance){
                Console.WriteLine("Saldo Insuficiente!");
                return;
            }
            this.ac_balance -= value;
            Console.WriteLine("Saque efetuado no valor de R${0:0.00}!", value);
            Console.WriteLine("A conta de {0} tem saldo de R$ {1:0.00}", this.name, this.ac_balance);
        }
        public void transfer(Account ac, float value){
            if(value > this.ac_balance){
                Console.WriteLine("Saldo Insuficiente!");
                return;
            }
            this.ac_balance -= value;
            ac.deposit(value);
            Console.WriteLine("Transferencia efetuada no valor de R${0:0.00}", value);
        }
        public void show(){
            Console.WriteLine("Titular: {0} | TipoConta: {1} | Saldo: {2}", this.name, this.type,this.ac_balance);
        }

    }
}