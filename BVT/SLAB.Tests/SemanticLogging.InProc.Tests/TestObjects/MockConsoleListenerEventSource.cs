﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Diagnostics.Tracing;

namespace Microsoft.Practices.EnterpriseLibrary.SemanticLogging.InProc.Tests.TestObjects
{
    public class MockConsoleListenerEventSource : EventSource
    {
        public const int InfoWithKeywordDiagnosticEventId = 1020;
        public const int CriticalWithTaskNameEventId = 1500;

        public static readonly MockConsoleListenerEventSource Logger = new MockConsoleListenerEventSource();

        public class Keywords
        {
            public const EventKeywords Diagnostic = (EventKeywords)4;
            public const EventKeywords Page = (EventKeywords)1;
        }

        public class Tasks
        {
            public const EventTask Page = (EventTask)1;
        }

        [Event(401, Level = EventLevel.Informational, Keywords = EventKeywords.None, Message = "Functional Test", Opcode = EventOpcode.Info, Task = EventTask.None, Version = 1)]
        public void InfoTest(string message) { this.WriteEvent(401, message); }

        //There is no default color mapped to to Informational
        [Event(100, Level = EventLevel.Informational)]
        public void Informational(string message)
        {
            if (this.IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                this.WriteEvent(100, message); 
            }
        }

        [Event(200, Level = EventLevel.Critical, Keywords = EventKeywords.None, Message = "Functional Test", Opcode = EventOpcode.Info, Task = EventTask.None, Version = 0)]
        public void Critical(string message) { this.WriteEvent(200, message); }

        [Event(300, Level = EventLevel.Error, Keywords = EventKeywords.None, Message = "Test Error", Opcode = EventOpcode.Info, Task = EventTask.None, Version = 3)]
        public void Error(string message) { this.WriteEvent(300, message); }

        [Event(400, Level = EventLevel.Verbose, Keywords = EventKeywords.None, Message = "Functional Test", Opcode = EventOpcode.Info, Task = EventTask.None, Version = 1)]
        public void Verbose(string message) { this.WriteEvent(400, message); }

        [Event(500, Level = EventLevel.LogAlways, Keywords = EventKeywords.None, Message = "Test LogAlways", Opcode = EventOpcode.Info, Task = EventTask.None, Version = 5)]
        public void LogAlways(string message) { this.WriteEvent(500, message); }

        [Event(600, Level = EventLevel.Warning, Keywords = EventKeywords.None, Message = "Test Warning", Opcode = EventOpcode.Info, Task = EventTask.None, Version = 6)]
        public void Warning(string message) { this.WriteEvent(600, message); }

        [Event(InfoWithKeywordDiagnosticEventId, Level = EventLevel.Informational, Keywords = Keywords.Diagnostic, Task = Tasks.Page)]
        public void InfoWithKeywordDiagnostic(string message)
        {
            if (this.IsEnabled(EventLevel.Informational, Keywords.Diagnostic))
            {
                this.WriteEvent(InfoWithKeywordDiagnosticEventId, message); 
            }
        }

        [Event(CriticalWithTaskNameEventId, Level = EventLevel.Critical, Keywords = Keywords.Page, Task = Tasks.Page)]
        public void CriticalWithTaskName(string message)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(CriticalWithTaskNameEventId, message); 
            }
        }

        [Event(700, Level = EventLevel.Informational)]
        public void Informational2(string message)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(700, message); 
            }
        }
    }

    public class MockHighEventIdEventSource : EventSource
    {
        public static readonly MockHighEventIdEventSource HigheventIdLogger = new MockHighEventIdEventSource();

        [Event(65535, Level = EventLevel.Warning, Keywords = EventKeywords.None, Message = "Test Warning", Opcode = EventOpcode.Info, Task = EventTask.None, Version = 6)]
        public void Warning() { this.WriteEvent(65535); }
    }

    public class MockNegativeEventIdEventSource : EventSource
    {
        public static readonly MockNegativeEventIdEventSource LoweventIdLogger = new MockNegativeEventIdEventSource();

        [Event(-100, Level = EventLevel.Warning, Keywords = EventKeywords.None, Message = "Test Warning", Opcode = EventOpcode.Info, Task = EventTask.None, Version = 6)]
        public void Warning() { this.WriteEvent(-100); }
    }
}
