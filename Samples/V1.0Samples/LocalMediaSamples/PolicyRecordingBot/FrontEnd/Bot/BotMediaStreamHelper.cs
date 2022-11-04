// <copyright file="BotMediaStreamHelper.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Sample.PolicyRecordingBot.FrontEnd.Bot
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Skype.Bots.Media;

    /// <summary>
    /// Class which contains helper video methods.
    /// </summary>
    public static class BotMediaStreamHelper
    {
        /// <summary>
        /// Saves video buffers into file.
        /// </summary>
        /// <param name="buffer">Buffer from OnVideoMediaReceived event.</param>
        public static void SaveVideo(VideoMediaBuffer buffer)
        {
            try
            {
                unsafe
                {
                    FileStream file = new FileStream("c:/tmp.h264", FileMode.Append, FileAccess.Write);
                    UnmanagedMemoryStream ustream = new UnmanagedMemoryStream((byte*)buffer.Data, buffer.Length);
                    ustream.CopyTo(file);
                    ustream.Close();
                    file.Close();
                }
            }
            catch
            {
                System.Diagnostics.Trace.WriteLine("Exception during saving the video");
            }
        }
    }
}
