﻿using System.Collections.Generic;
using IVeraControl.Model;
using UpnpModels.Model.UpnpService.Base;

namespace UpnpModels.Model.UpnpService
{

    public enum Dimming1Action
    {
        SetLoadLevelTarget,
    }

    public enum Dimming1StateVariable
    {
        LoadLevelTarget,
        LoadLevelStatus
    }

    public class Dimming1Service : UpnpServiceBase, IUpnpService
    {
        public string ServiceUrn => "urn:upnp-org:serviceId:Dimming1";
        public string ServiceName { get; } = ServiceType.Dimmer1.ToString();

        public Dimming1Service(IVeraController controller, IUpnpDevice device)
        {
            StateVariables = new List<IUpnpStateVariable>
            {
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = Dimming1StateVariable.LoadLevelStatus.ToString(),
                    Type = typeof(byte)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = Dimming1StateVariable.LoadLevelTarget.ToString(),
                    Type = typeof(byte)
                },
            };

            Actions = new List<IUpnpAction>
            {
                new UpnpAction(controller, this, device)
                {
                    ActionName = Dimming1Action.SetLoadLevelTarget.ToString(),
                    ArgumentName = "newLoadlevelTarget",
                    Type = typeof(byte),
                    Value = null,
                    Direction = Direction.In
                },
            };
        }
    }
}
