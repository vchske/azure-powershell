﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class InstallOciDriverTaskCmdlet : DynamicCmdlet, ITaskCmdlet
    {
        private readonly string DriverPackageName = "DriverPackageName";

        public InstallOciDriverTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.SimpleParam(DriverPackageName, typeof(string), "Name of the uploaded driver package to install.", true);
        }

        public ProjectTaskProperties ProcessTaskCmdlet()
        {
            InstallOCIDriverTaskInput input = null;

            if (MyInvocation.BoundParameters.ContainsKey(DriverPackageName))
            {
                input = new InstallOCIDriverTaskInput((string)MyInvocation.BoundParameters[DriverPackageName]);
            }

            return new InstallOCIDriverTaskProperties { Input = input };
        }
    }
}
