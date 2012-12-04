﻿
/* Copyright 2011-2012 Roman Kuzmin
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Management.Automation;
using MongoDB.Driver;
namespace Mdbc.Commands
{
	public abstract class AbstractWriteCommand : AbstractCollectionCommand
	{
		[Parameter]
		public WriteConcern WriteConcern { get; set; }
		[Parameter]
		public SwitchParameter Result { get; set; }
		protected void WriteResult(WriteConcernResult value)
		{
			if (Result && value != null)
				WriteObject(value);
		}
		protected void WriteException(Exception value)
		{
			WriteError(new ErrorRecord(value, "Driver", ErrorCategory.WriteError, null));
		}
	}
}