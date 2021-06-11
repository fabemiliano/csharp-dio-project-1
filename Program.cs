using System;
using System.Collections.Generic;

namespace BankAccount
{
  class Program
  {
    static List<Account> AccountList = new List<Account>();
    static void Main(string[] args)
    {
      string selectedOption = SelectOption();

      while (selectedOption.ToUpper() != "X")
      {
        switch (selectedOption)
        {
          case "1":
            ListAccount();
            break;
          case "2":
            InsertAccount();
            break;
          case "3":
            Transfer();
            break;
          case "4":
            Withdraw();
            break;
          case "5":
            Deposit();
            break;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }

        selectedOption = SelectOption();
      }

      Console.WriteLine("Obrigado por utilizar nossos serviços.");
      Console.ReadLine();
    }

    private static void Deposit()
    {
      Console.Write("Digite o número da conta: ");
      int index = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser depositado: ");
      double value = double.Parse(Console.ReadLine());

      AccountList[index].Deposit(value);
    }

    private static void Withdraw()
    {
      Console.Write("Digite o número da conta: ");
      int index = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser sacado: ");
      double value = double.Parse(Console.ReadLine());

      AccountList[index].Withdraw(value);
    }

    private static void Transfer()
    {
      Console.Write("Digite o número da conta de origem: ");
      int index = int.Parse(Console.ReadLine());

      Console.Write("Digite o número da conta de destino: ");
      int outIndex = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser transferido: ");
      double valorTransferencia = double.Parse(Console.ReadLine());

      AccountList[index].Transfer(valorTransferencia, AccountList[outIndex]);
    }

    private static void InsertAccount()
    {
      Console.WriteLine("Inserir nova conta");

      Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
      int accountType = int.Parse(Console.ReadLine());

      Console.Write("Digite o Nome do Cliente: ");
      string name = Console.ReadLine();

      Console.Write("Digite o saldo inicial: ");
      double balance = double.Parse(Console.ReadLine());

      Console.Write("Digite o crédito: ");
      double credit = double.Parse(Console.ReadLine());

      Account newAccount = new Account((AccountType)accountType,
                    balance,
                    credit,
                    name);

      AccountList.Add(newAccount);
    }

    private static void ListAccount()
    {
      Console.WriteLine("Listar contas");

      if (AccountList.Count == 0)
      {
        Console.WriteLine("Nenhuma conta cadastrada.");
        return;
      }

      for (int i = 0; i < AccountList.Count; i++)
      {
        Account account = AccountList[i];
        Console.Write("#{0} - ", i);
        Console.WriteLine(account);
      }
    }

    private static string SelectOption()
    {
      Console.WriteLine();
      Console.WriteLine("Banco 24h a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar contas");
      Console.WriteLine("2- Inserir nova conta");
      Console.WriteLine("3- Transfer");
      Console.WriteLine("4- Sacar");
      Console.WriteLine("5- Depositar");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string selectedOption = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return selectedOption;
    }
  }
}
