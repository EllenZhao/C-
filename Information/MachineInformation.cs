using System.Diagnostics;
using System;
using System.Net.NetworkInformation;

namespace CSharp.Kit.Information
{
    public static class MachineInformation
    {
        public static String GetMachineName()
        {
            return Environment.MachineName;
        }

        public static List<String> GetMac(NetworkInterfaceType interfaceType)
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            List<String> macList = new List<string>();
            foreach (var item in interfaces)
            {
                if (item.NetworkInterfaceType == interfaceType)
                {
                    var mac = item.GetPhysicalAddress().ToString();
                    macList.Add(mac);
                }
            }
            return macList;
        }

        public static List<String> GetIpAddress()
        {
            List<String> ipList = new List<String>();
            return ipList;
        }
    }
}