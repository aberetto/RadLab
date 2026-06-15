using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static RadLab.ClassDevice;

namespace RadLab
{
    public partial class ClassMain
    {
        public class Filter(int SetSize)
        {
            public int Size { get; set; } = SetSize;
            private ulong Summa { get; set; } = 0;
            private Queue<PointsBuferT> PointQueue { get; } = [];
            public uint[] DistributionArray { get; set; } = new uint[65536];
            public uint MinIndex { get; set; } = 0;
            public uint MaxIndex { get; set; } = 0;

            public void ReSize(int NewSize)
            {
                if (NewSize > PointQueue.Count)
                {
                    Size = NewSize;
                }
                if (NewSize < PointQueue.Count)
                {
                    while (PointQueue.Count > NewSize)
                    {
                        RemoveFirstValue();
                    }
                    Size = NewSize;
                }
            }

            private void RemoveFirstValue()
            {
                PointsBuferT First = PointQueue.Dequeue();
                Summa -= First.CntPerSec;
                DistributionArray[First.CntPerSec]--;
                if (MinIndex == First.CntPerSec && DistributionArray[First.CntPerSec] == 0)
                {
                    MinIndex = 0;
                    if (Summa != 0)
                    {
                        while (DistributionArray[MinIndex] == 0)
                        {
                            MinIndex++;
                        }
                    }
                }
                if (MaxIndex == First.CntPerSec && DistributionArray[First.CntPerSec] == 0)
                {
                    MaxIndex = 65535;
                    while (DistributionArray[MaxIndex] == 0)
                    {
                        MaxIndex--;
                    }
                }
            }

            public void AddValue(PointsBuferT Point)
            {
                PointQueue.Enqueue(Point);
                Summa += Point.CntPerSec;
                DistributionArray[Point.CntPerSec]++;
                if (MinIndex > Point.CntPerSec) { MinIndex = Point.CntPerSec; }
                if (MaxIndex < Point.CntPerSec) { MaxIndex = Point.CntPerSec; }
                if (PointQueue.Count > Size)
                {
                    RemoveFirstValue();
                }
            }

            public void Clear()
            {
                PointQueue.Clear();
                DistributionArray = new uint[65536];
                Summa = 0;
                MinIndex = 0;
                MaxIndex = 0;
            }

            public ulong GetSum()
            {
                return Summa;
            }

            public float GetAverage()
            {
                float Avg = Summa / (float)PointQueue.Count;
                return Avg;
            }

            public ushort Count()
            {
                return (ushort)PointQueue.Count;
            }

            public Queue<PointsBuferT> GetBufer()
            {                
                return new Queue<PointsBuferT>(PointQueue);
            }

            public double GetVariance()
            {
                double Variance = 0;
                double Avg = Summa / (double)PointQueue.Count;
                if (PointQueue.Count > 1)
                {
                    PointsBuferT[] x = [.. PointQueue];
                    for (int i = 0; i < PointQueue.Count; i++)
                    {
                        double Delta = x[i].CntPerSec - Avg;
                        Variance += Delta * Delta;
                    }
                    Variance /= (PointQueue.Count - 1);
                }
                return Variance;
            }
        }

        public static Dictionary<string, string[]> GetPortNames(bool OnlySTM32)
        {
            Dictionary<string, string[]> COMList = [];
            try
            {
                // В ветке HKLM\SYSTEM\CurrentControlSet\Enum ищем все устройства с ClassGUID = {4d36e978-e325-11ce-bfc1-08002be10318}
                // И имеющим в Device Parameters параметр PortName                              
                var reg_ccs_enum = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\");
                if (reg_ccs_enum != null)
                {
                    string[] ccs_enums = reg_ccs_enum.GetSubKeyNames();
                    foreach (string ccs_enum in ccs_enums)
                    {
                        try
                        {
                            var path1 = "SYSTEM\\CurrentControlSet\\Enum\\" + ccs_enum;
                            var reg_ccs_enum_service = Registry.LocalMachine.OpenSubKey(path1);
                            if (reg_ccs_enum_service != null)
                            {
                                string[] ccs_enum_services = reg_ccs_enum_service.GetSubKeyNames();
                                foreach (string ccs_enum_service in ccs_enum_services)
                                {
                                    try
                                    {
                                        var path2 = path1 + "\\" + ccs_enum_service;
                                        var reg_ccs_enum_service_device = Registry.LocalMachine.OpenSubKey(path2);
                                        if (reg_ccs_enum_service_device != null)
                                        {
                                            string[] ccs_enum_service_devices = reg_ccs_enum_service_device.GetSubKeyNames();
                                            foreach (string ccs_enum_service_device in ccs_enum_service_devices)
                                            {
                                                try
                                                {
                                                    var path3 = path2 + "\\" + ccs_enum_service_device;
                                                    var reg_ccs_enum_service_device_desc = Registry.LocalMachine.OpenSubKey(path3);
                                                    if (reg_ccs_enum_service_device_desc != null)
                                                    {
                                                        if (reg_ccs_enum_service_device_desc.GetValue("ClassGUID", "").Equals("{4d36e978-e325-11ce-bfc1-08002be10318}"))
                                                        {
                                                            string Service_Name = $"{reg_ccs_enum_service_device_desc.GetValue("Service")}";
                                                            string path4 = "SYSTEM\\CurrentControlSet\\Services\\" + Service_Name + "\\Enum";
                                                            var reg_enum = Registry.LocalMachine.OpenSubKey(path4);
                                                            if (reg_enum != null)
                                                            {
                                                                byte enum_counts = Convert.ToByte($"{reg_enum.GetValue("Count")}");
                                                                while (enum_counts > 0)
                                                                {
                                                                    enum_counts--;
                                                                    string enum_serv = $"{reg_enum.GetValue(enum_counts.ToString())}";
                                                                    if (enum_serv.Equals(ccs_enum + "\\" + ccs_enum_service + "\\" + ccs_enum_service_device))
                                                                    {
                                                                        string[] PortDesc = ["", ""];
                                                                        var reg_ccs_enum_service_device_param = reg_ccs_enum_service_device_desc.OpenSubKey("Device Parameters");
                                                                        string FriendlyName = "";
                                                                        string PortName = "";
                                                                        if (reg_ccs_enum_service_device_param != null)
                                                                        {
                                                                            FriendlyName = $"{reg_ccs_enum_service_device_desc.GetValue("FriendlyName")}";
                                                                            PortName = $"{reg_ccs_enum_service_device_param.GetValue("PortName")}";
                                                                            PortDesc[0] = ccs_enum;
                                                                        }
                                                                        if (ccs_enum.Equals("USB"))
                                                                        {
                                                                            if (ccs_enum_service.Equals("VID_0483&PID_5740"))
                                                                            {
                                                                                if (OnlySTM32)
                                                                                {
                                                                                    PortDesc[1] = FriendlyName;
                                                                                    COMList.Add(PortName, PortDesc);
                                                                                }
                                                                            }
                                                                        }
                                                                        if (!OnlySTM32)
                                                                        {
                                                                            PortDesc[1] = FriendlyName;
                                                                            try
                                                                            {
                                                                                COMList.Add(PortName, PortDesc);
                                                                            }
                                                                            catch { }
                                                                        }
                                                                        break;
                                                                    }
                                                                }
                                                            }

                                                        }
                                                    }
                                                }
                                                catch { }
                                            }
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }
                        catch { }
                    }
                }
                //COMList.Add("Отключён", ["simple", "Отключить устройство"]);
            }
            catch
            {
                foreach (string Name in SerialPort.GetPortNames())
                {
                    try
                    {
                        string[] PortDesc = ["simple", ""];
                        string PortName = FindComByRegex().Match(Name).Value;
                        COMList.Add(PortName, PortDesc);
                    }
                    catch { }
                }
            }
            return COMList;
        }

        [GeneratedRegex(@"COM\d+")]
        private static partial Regex FindComByRegex();
    }
}
