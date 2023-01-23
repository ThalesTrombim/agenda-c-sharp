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

		static void InsertContact(ref string[] name, ref string[] email, ref int tl)
		{
			try
			{
        if(tl >= 200)
        {
          Console.WriteLine("Tamanho maximo atingido.");
        } else
        {
          Console.WriteLine("Inserir contato");
          Console.Write("Nome: ");
          name[tl] = Console.ReadLine();
          Console.Write("Email: ");
          email[tl] = Console.ReadLine();
          int pos = FindAContact(email, tl, email[tl]);
          if (pos == -1)
          {
            tl++;
            Console.WriteLine("Contato cadastrado");
          }
          else
          {
            Console.WriteLine("Contato ja cadastrado");
          }
          Console.ReadKey();
        }
      }
			catch (Exception e)
			{	
				Console.WriteLine("Erro:" + e.Message);
				Console.ReadKey();
      }
    }

    static void UpdateContact(ref string[] name, ref string[] email, ref int tl)
    {
      try
      {
        Console.WriteLine("Alterar contato");
        Console.Write("Email: ");
        string emailContact = Console.ReadLine();
				int pos = FindAContact(email, tl, emailContact);
				if(pos != -1)
				{
          Console.WriteLine("Novos dados do contato");
          Console.Write("Nome: ");
          string newName = Console.ReadLine();
          Console.Write("Nome: ");
          string newEmail = Console.ReadLine();
					int posF = FindAContact(email, tl, newEmail);

          if (posF == -1 || posF == pos)
					{
            name[pos] = newName;
            email[pos] = newEmail;
            Console.WriteLine("Contato alterado");
          }
					else
					{
            Console.WriteLine("Contato ja cadastrado");
          }
          Console.ReadKey();
        }
				else
				{
					Console.WriteLine("Contato nao encontrado");
					Console.ReadKey();
				}
      }
      catch (Exception e)
      {
        Console.WriteLine("Erro:" + e.Message);
        Console.ReadKey();
      }
    }

    static int FindAContact(string[] email, int tl, string emailContact)
		{
			int pos = -1;
			int i = 0;
			while (i < tl && email[i] != emailContact)
			{
				i++;
			}
			if (i < tl)
				pos = i;
				return pos;
		}

    static Boolean ExcludeContact(ref String[] name, ref String[] email, ref int tl, string emailContact)
    {
      Boolean excluded = false;
      int pos = 0;
      pos = FindAContact(email, tl, emailContact);

      if(pos != -1)
      {
        for (int i = pos; i < tl-1; i++)
        {
          name[i] = name[i + 1];
          email[i] = email[i + 1];
        }
        excluded = true;
        tl--;
      }
      return excluded;
    }


    static void Main(string[] args)
		{
			string[] name = new string[200];
			string[] email = new string[200];

      int pos = 0;

      string emailContact = "";

      int tl = 0;
			int op = 0;

      AgendaBackup.fileName = "data.rtf";
      AgendaBackup.RestoreData(ref name, ref email, ref tl);

      while (op != 6)
			{
				op = ShowMenu();
        switch (op)
        {
          case 1:
						ShowContacts(name, email, tl);
            break;
					case 2:
						InsertContact(ref name, ref email, ref tl);
            break;
          case 3:
            UpdateContact(ref name, ref email, ref tl);
            break;
          case 4:
            Console.WriteLine("Excluir um contato");
            Console.Write("Email: ");
            emailContact = Console.ReadLine();
            if (ExcludeContact(ref name, ref email, ref tl, emailContact))
            {
              Console.WriteLine("Contado excluido");
            }
            else
            {
              Console.WriteLine("Contado Não encontrado");
            }
            Console.ReadKey();
            break;
          case 5:
						Console.WriteLine("Localizar um contato");
						Console.Write("Email: ");
						emailContact = Console.ReadLine();
            pos = FindAContact(email, tl, emailContact);
						if(pos != -1)
						{
              Console.WriteLine("Nome: {0} - Email: {1}", name[pos], email[pos]);
            }
						else
						{
							Console.WriteLine("Contato nao encontrado");
						}
            Console.ReadKey();
            break;
          case 6:
						Console.ReadKey();
            break;
        }
      }

      AgendaBackup.SaveData(ref name, ref email, ref tl);
    }
	}
}

