﻿using AutoHotInterception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public static class TestDevices
    {
        public static TestDevice WyseKeyboard { get; } = new TestDevice { IsMouse = false, Vid = 0x04F2, Pid = 0x0112 };
        public static TestDevice LogitechWheelMouse { get; } = new TestDevice { IsMouse = true, Vid = 0x046D, Pid = 0xC00C };
        public static TestDevice ParbloIslandA609 { get; } = new TestDevice { IsMouse = true, Handle = "HID\\VID_0B57&PID_9091&REV_0101&Col01" };
    }

    public class TestDevice
    {
        public bool IsMouse { get; set; }
        public int? Vid { get; set; }
        public int? Pid { get; set; }
        public string Handle { get; set; }
        public int Instance { get; set; } = 1;

        public int GetDeviceId()
        {
            var im = new Manager();

            if (Vid != null && Pid != null)
            {
                return im.GetDeviceId(IsMouse, (int)Vid, (int)Pid, Instance);
            }
            else
            {
                return im.GetDeviceIdFromHandle(IsMouse, Handle, Instance);
            }
        }

    }

    class DeviceResolver
    {
        public int GetDeviceId(TestDevice device)
        {
            if (device.Vid != null && device.Pid != null)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
