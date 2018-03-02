﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayPauseCommand.cs" company="Hukano">
// Copyright (c) Hukano. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MpcNET.Commands.Playback
{
    using System.Collections.Generic;

    internal class PlayPauseCommand : IMpcCommand<string>
    {
        public string Serialize() => string.Join(" ", "pause");

        public string Deserialize(IReadOnlyList<KeyValuePair<string, string>> response)
        {
            return string.Join(", ", response);
        }
    }
}