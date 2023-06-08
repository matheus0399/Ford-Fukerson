// See https://aka.ms/new-console-template for more information
using System.IO;
using busca.entities;

Boolean end = false;
ListGraph lGp = new ListGraph(false, false);
MatrixGraph mGp = new MatrixGraph(false, false);
Console.Clear();
Console.Write("Você deseja criar um grafo de lista(sim/não)? ");
Boolean listGraph = Console.ReadLine().Trim().ToLower() == "sim";
FordFukerson ff = new FordFukerson();


string path = Path.Combine(Directory.GetCurrentDirectory(),"graph.txt");

Boolean reboot = false;
do
{
    try
    {
        if (reboot == true)
        {
            lGp = new ListGraph(false, false);
            mGp = new MatrixGraph(false, false);
            Console.Write("Você deseja criar um grafo de lista(sim/não)? ");
            listGraph = Console.ReadLine().Trim().ToLower() == "sim";
            reboot = false;
        }
        if (listGraph == true)
        {
            lGp = lGp.readFile(path);
        }
        else
        {
            mGp = mGp.readFile(path);
        }
        Console.Write("\nQual o tipo de ação você deseja executar:"
            + "\n 1 - Ford-Fukerson"
            + "\n 2 - Reset: "
        );

        String input0 = Console.ReadLine().Trim().ToLower();
        String input1 = "";
        List<String> strs = new List<String>();

        switch (input0)
        {
            case "1":
                Console.Write("Insira a label do vertice de origem:");
                input0 = Console.ReadLine().Trim();
                Console.Write("Insira a label do vertice de destino:");
                input1 = Console.ReadLine().Trim();
                if (listGraph == true)
                {
                    ff.run(lGp, mGp, listGraph, input0, input1);
                }
                else
                {
                    ff.run(lGp, mGp, listGraph, input0, input1);
                }
                break;
            case "2":
                Console.Clear();
                reboot = true;
                break;
        }
        Console.WriteLine("");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.StackTrace);
        Console.WriteLine(e.Message);
        Console.WriteLine("\n INPUT ERROR \n");
    }
} while (end == false);
