using System;
using System.Collections.Generic;

public class Program
{
    static List<Station> stations = new List<Station>();
    static List<Monitor> monitors = new List<Monitor>();

    public static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n0 - Sair\n1 - Criar Estação\n2 - Atualizar Estação\n3 - Remover Estação\n4 - Criar Monitor\n5 - Editar Monitor");
            string option = Console.ReadLine();

            switch (option)
            {
                case "0":
                    running = false;
                    break;
                case "1":
                    CreateStation();
                    break;
                case "2":
                    UpdateStation();
                    break;
                case "3":
                    RemoveStation();
                    break;
                case "4":
                    CreateMonitor();
                    break;
                case "5":
                    EditMonitor();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static void CreateStation()
    {
        Console.Write("Digite o UF da estação: ");
        string uf = Console.ReadLine();
        stations.Add(new Station(uf));
        Console.WriteLine("Estação criada: UF = " + uf);
    }

    static void UpdateStation()
    {
        ListStations();
        Station station = GetStation();
        if (station == null) return;

        Console.WriteLine("1 - Atualizar Temperatura\n2 - Adicionar Monitor\n3 - Remover Monitor");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Write("Digite a nova temperatura: ");
                float temp = float.Parse(Console.ReadLine());
                station.SetTemperature(temp);
                break;
            case "2":
                Monitor monitor = GetMonitor();
                if (monitor != null) station.AddObserver(monitor);
                break;
            case "3":
                monitor = GetMonitor();
                if (monitor != null) station.RemoveObserver(monitor);
                break;
        }
    }

    static void RemoveStation()
    {
        ListStations();
        Station station = GetStation();
        if (station != null) stations.Remove(station);
    }

    static void CreateMonitor()
    {
        monitors.Add(new Monitor());
        Console.WriteLine("Monitor criado.");
    }

    static void EditMonitor()
    {
        ListMonitors();
        Monitor monitor = GetMonitor();
        if (monitor == null) return;

        Console.WriteLine("1 - Adicionar Estação\n2 - Remover Estação");
        string option = Console.ReadLine();
        Station station = GetStation();
        if (station != null)
        {
            if (option == "1") station.AddObserver(monitor);
            else if (option == "2") station.RemoveObserver(monitor);
        }
    }

    static void ListStations()
    {
        if (stations.Count == 0)
        {
            Console.WriteLine("Nenhuma estação disponível.");
            return;
        }

        Console.WriteLine("Estações disponíveis:");
        for (int i = 0; i < stations.Count; i++)
        {
            var station = stations[i];
            Console.WriteLine($"{i}: UF = {station.UF}, Temperatura = {station.GetTemperature()}");
        }
    }

    static void ListMonitors()
    {
        if (monitors.Count == 0)
        {
            Console.WriteLine("Nenhum monitor disponível.");
            return;
        }

        Console.WriteLine("Monitores disponíveis:");
        for (int i = 0; i < monitors.Count; i++)
        {
            Console.WriteLine($"{i}: Monitor {i}");
        }
    }

    static Station GetStation()
    {
        Console.Write("Digite o número da estação (0 a " + (stations.Count - 1) + "): ");
        int index = int.Parse(Console.ReadLine());

        if (index < 0 || index >= stations.Count)
        {
            Console.WriteLine("Estação inválida.");
            return null;
        }

        return stations[index];
    }

    static Monitor GetMonitor()
    {
        Console.Write("Digite o número do monitor (0 a " + (monitors.Count - 1) + "): ");
        int index = int.Parse(Console.ReadLine());

        if (index < 0 || index >= monitors.Count)
        {
            Console.WriteLine("Monitor inválido.");
            return null;
        }

        return monitors[index];
    }
}
