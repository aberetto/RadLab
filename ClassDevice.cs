using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RadLab
{
    public class ClassDevice
    {
        public class ConnectTimeouts()
        {
            public int BtwIter = 200;
            public int AfterError = 5000;
            public int BeforeRetry = 5000;
            public int WaitConnect = 5000;
            public int WaitData = 5000;
            public int NoPacketError = 5000;
        }

        public class PointsBuferT
        {
            public DateTime Time { get; set; }
            public uint CntPerSec { get; set; }
        }

        public enum ConnectStatus
        {
            Unknown,
            Connect,
            Connecting,
            Reconnecting,
            Disconnect,
            Disconnecting,
            WaitData
        }

        public class SerialPortDetector(string Name)
        {
            public string Name = Name;
            public bool PortIsOpen;
            public bool ReadyToConnect;
            public bool NeedToConnect;  // true - Надо подключаться
            public string PortName = "";
            public volatile ConnectStatus Status = ConnectStatus.Unknown;
            public volatile ConnectStatus StatusPrev = ConnectStatus.Unknown;
            public DateTime lastPackedReceivedAt;
            public DateTime lastPacketCommandStartAt;

            public bool NewPacketReady = false;

            public byte[] ValidPacket = new byte[65535];
            public byte[] LastCommand = new byte[65535];
            public int PacketLength = 0;
            public int lastPacketCommandStarted = 0;

            public ConnectTimeouts Timeout = new();
            public ConcurrentQueue<byte> Bufer = new();
            public ConcurrentQueue<PointsBuferT> PointsBufer = new();
            public SerialPort Port = new();

            public void ConnectionThread()
            {
                // Запускаем поток подключения к детектору
                Thread.CurrentThread.Name = Name + "ConnectThread";
                Thread.CurrentThread.IsBackground = true;
                bool LastConnectOK = true; // Считаем что это первое переподключение, а не после неудачной попытки
                while (true)
                {
                    try
                    {
                        if (!ReadyToConnect) Thread.Sleep(Timeout.BtwIter);
                        if (NeedToConnect)
                        {
                            if (!PortName.Equals("") && !$"{Port.PortName}".Equals(PortName))
                            {
                                if (Port.IsOpen)
                                {
                                    Disconnect();
                                    Status = ConnectStatus.Disconnect;
                                }
                                Port.PortName = PortName;
                                ReadyToConnect = true;
                                lastPackedReceivedAt = DateTime.Now;
                                Status = ConnectStatus.Connecting;
                            }
                        }
                        else
                        {
                            if (Port.IsOpen) { Disconnect(); }
                            Status = ConnectStatus.Disconnect;
                        }

                        if (NeedToConnect)
                        {
                            DateTime a = DateTime.Now;
                            a = a.AddMilliseconds(-Timeout.NoPacketError);
                            if ((lastPackedReceivedAt.CompareTo(a) < 0) | ReadyToConnect)
                            {
                                if (!ReadyToConnect)
                                {
                                    Status = ConnectStatus.Reconnecting;
                                    // Отключаемся от порта
                                    if (Port.IsOpen) { Disconnect(); }
                                    if (NeedToConnect)
                                    {
                                        if (LastConnectOK)
                                        { // Ждём после первого отключения
                                            Thread.Sleep(Timeout.AfterError);
                                        }
                                        else
                                        { // Ждём перед повторным подключением
                                            Thread.Sleep(Timeout.BeforeRetry);
                                        }
                                    };
                                }
                                if (NeedToConnect)
                                {
                                    PortIsOpen = false;
                                    Connect();
                                    int i = 0;
                                    if (PortIsOpen)
                                    {
                                        while (i < Timeout.WaitConnect)
                                        {
                                            Thread.Sleep(Timeout.BtwIter);
                                            i += Timeout.BtwIter;
                                            if (Status == ConnectStatus.Connect)
                                            { // Успешное подключение
                                                break;
                                            }
                                        }
                                    }


                                    if (PortIsOpen && Status != ConnectStatus.Connect)
                                    {
                                        Status = ConnectStatus.WaitData;
                                        i = 0;
                                        while (i < Timeout.WaitConnect)
                                        {
                                            Thread.Sleep(Timeout.BtwIter);
                                            i += Timeout.BtwIter;
                                            if (Status == ConnectStatus.Connect)
                                            { // Успешное подключение
                                                break;
                                            }
                                        }
                                    }
                                    LastConnectOK = false;
                                }
                            }
                            else
                            {
                                LastConnectOK = true;
                            }
                        }
                        else
                        {
                            LastConnectOK = true;
                        }
                    }
                    catch
                    {
                        if (NeedToConnect == false) Status = ConnectStatus.Disconnect;
                        else Status = ConnectStatus.Reconnecting;
                    }
                    ReadyToConnect = false;
                }

            }

            public void PortReaderThread()
            {
                // Запуск потока чтения порта
                Thread.CurrentThread.Name = Name + "ReadThread";
                Thread.CurrentThread.IsBackground = true;
                while (true)
                {
                    try
                    {
                        if (!Bufer.IsEmpty)
                        {
                            FindPackInReceived(this);
                        }
                    }
                    catch { }
                    Thread.Sleep(10);
                }
            }

            public void PacketRead(object? s, EventArgs e)
            {
                try
                {
                    if (Port.IsOpen)
                    {
                        Port.ReadTimeout = 100;
                        Port.BaseStream.ReadTimeout = 100;
                        int b = Port.BytesToRead;
                        byte[] tmp = new byte[b];
                        Port.BaseStream.Read(tmp, 0, b);
                        for (int i = 0; i < tmp.Length; i++)
                        {
                            Bufer.Enqueue(tmp[i]);
                        }
                    }
                }
                catch
                {
                    NewPacketReady = false;
                }
            }

            public void Connect()
            {
                try
                {
                    if (!Port.IsOpen)
                    {
                        Port.ReadBufferSize = 65536;
                        Port.Open();
                        PortIsOpen = Port.IsOpen;
                    }
                }
                catch { }
            }

            public void Disconnect()
            {
                try
                {
                    Port.BaseStream.Close();
                }
                catch { }
                try
                {
                    Port.BaseStream.Dispose();
                }
                catch { }
                try
                {
                    Port.Close();
                    if (NeedToConnect == false) Status = ConnectStatus.Disconnect;
                }
                catch { }
                try
                {
                    Port.Dispose();
                }
                catch { }
            }
        }

        public static void FindPackInReceived(SerialPortDetector dev)
        {
            if (dev.lastPacketCommandStarted == 1)
            {
                DateTime a = DateTime.Now;
                a = a.AddMilliseconds(-500);
                if (dev.lastPacketCommandStartAt.CompareTo(a) < 0)
                {
                    dev.Bufer.TryDequeue(out byte b);
                    dev.lastPacketCommandStarted = 0;
                }
            }
            while (dev.Bufer.Count > 12)
            {
                List<byte> pilotF0 = [0xF0, 0xF0, 0xF0];
                int packType = 0;
                if (dev.Bufer.Take(3).SequenceEqual(pilotF0))
                {
                    packType = 1;
                }
                else
                {
                    dev.Bufer.TryDequeue(out byte b);
                }
                if (packType != 0)
                {
                    int lengthPacket = dev.Bufer.ElementAt(3) + (dev.Bufer.ElementAt(4) << 8) + 3;
                    if (dev.Bufer.Count >= lengthPacket)
                    {
                        for (int i = 0; i < lengthPacket; i++)
                        {
                            dev.Bufer.TryDequeue(out dev.LastCommand[i]);
                        }
                        if (CheckCRC(dev.LastCommand, lengthPacket))
                        {
                            dev.PacketLength = lengthPacket;
                            dev.lastPacketCommandStarted = 0;
                            dev.lastPackedReceivedAt = DateTime.Now;
                            dev.Status = ConnectStatus.Connect;
                            if (packType == 1)
                            {
                                UnPackReceived(dev);
                            }
                        }
                    }
                    else
                    {
                        if (dev.lastPacketCommandStarted == 0)
                        {
                            dev.lastPacketCommandStarted = 1;
                            dev.lastPacketCommandStartAt = DateTime.Now;
                            break;
                        }
                        else
                        {
                            DateTime a = DateTime.Now;
                            a = a.AddMilliseconds(-500);
                            if (dev.lastPacketCommandStartAt.CompareTo(a) < 0)
                            {
                                dev.Bufer.TryDequeue(out byte b);
                                dev.lastPacketCommandStarted = 0;
                            }
                        }
                    }
                }
            }
        }
        private static bool CheckCRC(byte[] packet, int lengthPacket)
        {
            uint c1 = CalculateCRC32(packet, 3, lengthPacket - 7);
            uint c2 = ArrayToValue(packet.Skip(lengthPacket - 4).Take(4).Reverse().ToList(), typeof(uint));
            bool b = c1 == c2;
            return b;
        }

        public static dynamic? ArrayToValue(List<byte> arr, Type t)
        {
            dynamic? value = null;
            if (t.Equals(typeof(byte)))
            {
                value = arr[0];
                arr.RemoveRange(0, 1);
            }
            else if (t.Equals(typeof(ushort)))
            {
                value = (ushort)(arr[0] + (arr[1] << 8));
                arr.RemoveRange(0, 2);
            }
            else if (t.Equals(typeof(uint)))
            {
                value = (uint)(arr[0] + (arr[1] << 8) + (arr[2] << 16) + (arr[3] << 24));
                arr.RemoveRange(0, 4);
            }
            else if (t.Equals(typeof(float)))
            {
                float[] floatArray = new float[1];
                Buffer.BlockCopy(arr.Take(4).ToArray(), 0, floatArray, 0, 4);
                value = (float)floatArray[0];
                arr.RemoveRange(0, 4);
            }
            return value;
        }

        public static void UnPackReceived(SerialPortDetector dev)
        {
            if (dev.NewPacketReady) return;
            dev.LastCommand.CopyTo(dev.ValidPacket, 0);
            if (CheckCRC(dev.ValidPacket, dev.PacketLength))
            {
                dev.NewPacketReady = true;
            }
            else
            {
                dev.NewPacketReady = false;
            }
            if (dev.NewPacketReady)
            {
                uint CntPerSec = ArrayToValue(dev.ValidPacket.Skip(7).Take(2).Reverse().ToList(), typeof(ushort));
                PointsBuferT point = new()
                {
                    Time = dev.lastPackedReceivedAt,
                    CntPerSec = CntPerSec,
                };
                dev.PointsBufer.Enqueue(point);
                dev.NewPacketReady = false;
            }
        }

        public static uint CalculateCRC32(byte[] data, int Cursor, int Length)
        {
            uint t;
            uint crc32 = 0xFFFFFFFF;
            int End = Cursor + Length;
            while (Cursor < End)
            {
                t = crc32;
                crc32 <<= 8;
                crc32 |= (t >> 24);
                crc32 ^= data[Cursor];
                Cursor++;
                crc32 ^= crc32Table[crc32 & 0xFF];
            }
            return crc32;
        }

        readonly static uint[] crc32Table =
        [
            0x00000000,
            0x04C11DB6,
            0x09823B6C,
            0x0D4326DA,
            0x130476D8,
            0x17C56B6E,
            0x1A864DB4,
            0x1E475002,
            0x2608EDB0,
            0x22C9F006,
            0x2F8AD6DC,
            0x2B4BCB6A,
            0x350C9B68,
            0x31CD86DE,
            0x3C8EA004,
            0x384FBDB2,
            0x4C11DB60,
            0x48D0C6D6,
            0x4593E00C,
            0x4152FDBA,
            0x5F15ADB8,
            0x5BD4B00E,
            0x569796D4,
            0x52568B62,
            0x6A1936D0,
            0x6ED82B66,
            0x639B0DBC,
            0x675A100A,
            0x791D4008,
            0x7DDC5DBE,
            0x709F7B64,
            0x745E66D2,
            0x9823B6C0,
            0x9CE2AB76,
            0x91A18DAC,
            0x9560901A,
            0x8B27C018,
            0x8FE6DDAE,
            0x82A5FB74,
            0x8664E6C2,
            0xBE2B5B70,
            0xBAEA46C6,
            0xB7A9601C,
            0xB3687DAA,
            0xAD2F2DA8,
            0xA9EE301E,
            0xA4AD16C4,
            0xA06C0B72,
            0xD4326DA0,
            0xD0F37016,
            0xDDB056CC,
            0xD9714B7A,
            0xC7361B78,
            0xC3F706CE,
            0xCEB42014,
            0xCA753DA2,
            0xF23A8010,
            0xF6FB9DA6,
            0xFBB8BB7C,
            0xFF79A6CA,
            0xE13EF6C8,
            0xE5FFEB7E,
            0xE8BCCDA4,
            0xEC7DD012,
            0x34867037,
            0x30476D81,
            0x3D044B5B,
            0x39C556ED,
            0x278206EF,
            0x23431B59,
            0x2E003D83,
            0x2AC12035,
            0x128E9D87,
            0x164F8031,
            0x1B0CA6EB,
            0x1FCDBB5D,
            0x018AEB5F,
            0x054BF6E9,
            0x0808D033,
            0x0CC9CD85,
            0x7897AB57,
            0x7C56B6E1,
            0x7115903B,
            0x75D48D8D,
            0x6B93DD8F,
            0x6F52C039,
            0x6211E6E3,
            0x66D0FB55,
            0x5E9F46E7,
            0x5A5E5B51,
            0x571D7D8B,
            0x53DC603D,
            0x4D9B303F,
            0x495A2D89,
            0x44190B53,
            0x40D816E5,
            0xACA5C6F7,
            0xA864DB41,
            0xA527FD9B,
            0xA1E6E02D,
            0xBFA1B02F,
            0xBB60AD99,
            0xB6238B43,
            0xB2E296F5,
            0x8AAD2B47,
            0x8E6C36F1,
            0x832F102B,
            0x87EE0D9D,
            0x99A95D9F,
            0x9D684029,
            0x902B66F3,
            0x94EA7B45,
            0xE0B41D97,
            0xE4750021,
            0xE93626FB,
            0xEDF73B4D,
            0xF3B06B4F,
            0xF77176F9,
            0xFA325023,
            0xFEF34D95,
            0xC6BCF027,
            0xC27DED91,
            0xCF3ECB4B,
            0xCBFFD6FD,
            0xD5B886FF,
            0xD1799B49,
            0xDC3ABD93,
            0xD8FBA025,
            0x690CE06E,
            0x6DCDFDD8,
            0x608EDB02,
            0x644FC6B4,
            0x7A0896B6,
            0x7EC98B00,
            0x738AADDA,
            0x774BB06C,
            0x4F040DDE,
            0x4BC51068,
            0x468636B2,
            0x42472B04,
            0x5C007B06,
            0x58C166B0,
            0x5582406A,
            0x51435DDC,
            0x251D3B0E,
            0x21DC26B8,
            0x2C9F0062,
            0x285E1DD4,
            0x36194DD6,
            0x32D85060,
            0x3F9B76BA,
            0x3B5A6B0C,
            0x0315D6BE,
            0x07D4CB08,
            0x0A97EDD2,
            0x0E56F064,
            0x1011A066,
            0x14D0BDD0,
            0x19939B0A,
            0x1D5286BC,
            0xF12F56AE,
            0xF5EE4B18,
            0xF8AD6DC2,
            0xFC6C7074,
            0xE22B2076,
            0xE6EA3DC0,
            0xEBA91B1A,
            0xEF6806AC,
            0xD727BB1E,
            0xD3E6A6A8,
            0xDEA58072,
            0xDA649DC4,
            0xC423CDC6,
            0xC0E2D070,
            0xCDA1F6AA,
            0xC960EB1C,
            0xBD3E8DCE,
            0xB9FF9078,
            0xB4BCB6A2,
            0xB07DAB14,
            0xAE3AFB16,
            0xAAFBE6A0,
            0xA7B8C07A,
            0xA379DDCC,
            0x9B36607E,
            0x9FF77DC8,
            0x92B45B12,
            0x967546A4,
            0x883216A6,
            0x8CF30B10,
            0x81B02DCA,
            0x8571307C,
            0x5D8A9059,
            0x594B8DEF,
            0x5408AB35,
            0x50C9B683,
            0x4E8EE681,
            0x4A4FFB37,
            0x470CDDED,
            0x43CDC05B,
            0x7B827DE9,
            0x7F43605F,
            0x72004685,
            0x76C15B33,
            0x68860B31,
            0x6C471687,
            0x6104305D,
            0x65C52DEB,
            0x119B4B39,
            0x155A568F,
            0x18197055,
            0x1CD86DE3,
            0x029F3DE1,
            0x065E2057,
            0x0B1D068D,
            0x0FDC1B3B,
            0x3793A689,
            0x3352BB3F,
            0x3E119DE5,
            0x3AD08053,
            0x2497D051,
            0x2056CDE7,
            0x2D15EB3D,
            0x29D4F68B,
            0xC5A92699,
            0xC1683B2F,
            0xCC2B1DF5,
            0xC8EA0043,
            0xD6AD5041,
            0xD26C4DF7,
            0xDF2F6B2D,
            0xDBEE769B,
            0xE3A1CB29,
            0xE760D69F,
            0xEA23F045,
            0xEEE2EDF3,
            0xF0A5BDF1,
            0xF464A047,
            0xF927869D,
            0xFDE69B2B,
            0x89B8FDF9,
            0x8D79E04F,
            0x803AC695,
            0x84FBDB23,
            0x9ABC8B21,
            0x9E7D9697,
            0x933EB04D,
            0x97FFADFB,
            0xAFB01049,
            0xAB710DFF,
            0xA6322B25,
            0xA2F33693,
            0xBCB46691,
            0xB8757B27,
            0xB5365DFD,
            0xB1F7404B
        ];

    }
}
