﻿//-------------------------------------------------------------------------------------------------
// <copyright file="ProcessMsuPackage.cs" company="Outercurve Foundation">
//   Copyright (c) 2004, Outercurve Foundation.
//   This software is released under Microsoft Reciprocal License (MS-RL).
//   The license and further copyright text can be found in the file
//   LICENSE.TXT at the root directory of the distribution.
// </copyright>
//-------------------------------------------------------------------------------------------------

namespace WixToolset.Bind
{
    using System;
    using WixToolset.Data;
    using WixToolset.Data.Rows;

    /// <summary>
    /// Processes the Msu packages to add properties and payloads from the Msu packages.
    /// </summary>
    internal class ProcessMsuPackage : ICommand
    {
        public RowDictionary<PayloadRow> AuthoredPayloads { private get; set; }

        public ChainPackageFacade Facade { private get; set; }

        public void Execute()
        {
            PayloadRow packagePayload = this.AuthoredPayloads.Get(this.Facade.ChainPackage.PackagePayloadId);

            if (String.IsNullOrEmpty(this.Facade.ChainPackage.CacheId))
            {
                this.Facade.ChainPackage.CacheId = packagePayload.Hash;
            }

            this.Facade.ChainPackage.PerMachine = YesNoDefaultType.Yes; // MSUs are always per-machine.
        }
    }
}