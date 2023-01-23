using System;
namespace ConsoleAgenda
{
	internal class AgendaBackup
	{
    public static string fileName = "data.rtf";

    public static void SaveData(ref string[] name, ref string[] email, ref int tl)
    {
      StreamWriter sr = new StreamWriter(fileName);

      for (int i = 0; i < tl; i++)
      {
        sr.WriteLine(name[i] + "-" + email[i]);
      }
      sr.Close();
		}

    public static void RestoreData(ref string[] name, ref string[] email, ref int tl)
    {
      tl = 0;
      StreamReader sr = new StreamReader(fileName);
      string line = sr.ReadLine();
      while (line != null)
      {
        int pos = line.IndexOf("-");
        name[tl] = line.Substring(0, pos);
        email[tl] = line.Substring(pos+1);
        tl++;
        line = sr.ReadLine();
      }
    }
  }
}

