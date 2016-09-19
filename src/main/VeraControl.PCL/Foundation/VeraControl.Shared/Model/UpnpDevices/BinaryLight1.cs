﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using VeraControl.Model.UpnpDevices.Base;
using VeraControl.Model.UpnpService;


namespace VeraControl.Model.UpnpDevices
{
    //Specification: http://upnp.org/specs/ha/UPnP-ha-BinaryLight-v1-Device.pdf
    public class BinaryLight1 : UpnpDeviceBase, IUpnpDevice
    {
        public string DeviceUrn => "urn:schemas-upnp-org:device:BinaryLight:1";

        public string DeviceName => nameof(BinaryLight1);
        public uint DeviceNumber { get; set; }

        

        public BinaryLight1(IVeraController controller)
        {
            Services = new List<IUpnpService> { new SwitchPower1(controller, this) };
        }

        public async Task ActionAsync(dynamic actionName, dynamic target, ConnectionType connectionType)
        {
            var action = this.LookupService(nameof(SwitchPower1)).LookupAction(actionName);

            action.Value = target ? "1" : "0";

            await action.SendAction(connectionType);
        }
    }
}
