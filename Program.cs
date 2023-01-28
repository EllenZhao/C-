// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
List<String> maclist = CSharp.Kit.Information.MachineInformation.GetMac(System.Net.NetworkInformation.NetworkInterfaceType.Ethernet);
if (maclist.Count == 0)
{
    Console.WriteLine("No Ethernet enabled!");
}
else
{
    foreach (var mac in maclist)
    {
        Console.Write("Ethernet:");
        Console.WriteLine(mac);
    }
}

maclist = CSharp.Kit.Information.MachineInformation.GetMac(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
if (maclist.Count == 0)
{
    Console.WriteLine("No Wireless enabled!");
}
else
{
    foreach (var mac in maclist)
    {
        Console.Write("Wireless:");
        Console.WriteLine(mac);
    }
}
