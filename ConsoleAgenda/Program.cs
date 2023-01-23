using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAgenda
{
	internal class Program
	{
		static int ShowMenu()
		{
      int op = 0;
			Console.Clear();
			Console.WriteLine("Agenda modo Console.");
			Console.WriteLine("Exibir dados (1)");
      Console.WriteLine("Inserir contato (2)");
      Console.WriteLine("Alterar contato (3)");
      Console.WriteLine("Excluir contato (4)");
			Console.WriteLine("Localizar contato (5)");
      Console.WriteLine("Sair (6)");
			Console.Write("Opcao: ");
			op = Convert.ToInt32(Console.ReadLine());
      Console.Clear();
      return op;
    }

		static void ShowContacts(string[] name, string[] email, int tl)
		{
      Console.WriteLine("Exibir Contatos");
			for (int i = 0; i < tl; i++)
			{
				Console.WriteLine("Nome: {0} - Email: {1}", name[i], email[i]);
			}
			Console.ReadKey();
		}

		static void Main(string[] args)
		{
			string[] name = new string[200];
			string[] email = new string[200];

			int tl = 0;
			int op = 0;

      name[0] = "Danilo Filitto";
      email[0] = "danilo.filittogmail.com";
			tl++;
			name[tl] = "Thales Trombim";
			email[tl]= "thalestrombimyahoo.com.br";
      tl++;
      name[tl] = "Thales Silva";
      email[tl] = "thalaotrgmail.com";
      tl++;

      while (op != 6)
			{
				op = ShowMenu();
        switch (op)
        {
          case 1:
						ShowContacts(name, email, tl);
            break;
					case 2:
            break;
          case 6:
						Console.ReadKey();
            break;
        }
      }
    }
	}
}

