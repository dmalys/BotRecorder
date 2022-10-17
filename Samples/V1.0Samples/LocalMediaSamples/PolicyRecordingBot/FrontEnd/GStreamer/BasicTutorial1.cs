// <copyright file="BasicTutorial1.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Sample.PolicyRecordingBot.FrontEnd.GStreamer
{
    using Gst;

    /// <summary>
    /// Test gstreamer class.
    /// </summary>
    public static class BasicTutorial1
    {
        /// <summary>
        /// Example run class.
        /// </summary>
        public static void Run()
        {
            // Initialize Gstreamer
            Application.Init();

            // Build the pipeline
            // uri from CS samples
            //            var pipeline = Parse.Launch("playbin uri=http://download.blender.org/durian/trailer/sintel_trailer-1080p.mp4");
            // original uri
            var pipeline = Parse.Launch("playbin uri=http://freedesktop.org/software/gstreamer-sdk/data/media/sintel_trailer-480p.webm");

            // Start playing
            pipeline.SetState(State.Playing);

            // Wait until error or EOS
            var bus = pipeline.Bus;
            var msg = bus.TimedPopFiltered(Constants.CLOCK_TIME_NONE, MessageType.Eos | MessageType.Error);

            // Free resources
            pipeline.SetState(State.Null);
        }
    }
}
