using System;
using System.Collections.Generic;
using System.Management;
using System.Timers;
using Timer = System.Timers.Timer;

namespace trakr_sharp {
    public class ProcMonitor {
        #region Init
        public delegate void OnTrackedProcEventDelegate(ProcMonitor sender, string msg); // Create delegator for public OnTrackedProc event
        public event OnTrackedProcEventDelegate OnTrackedProcEvent; // Create instance of that event from delegator
        private List<string> _trackedProcs;
        private List<string> _runningTrackedProcs;

        public ProcMonitor() {
            _trackedProcs = Utils.Database.GetProcessNameList();
            _runningTrackedProcs = Utils.SysCalls.GetRunningTrackedProcList();

            WatchProcessCreations();
            WatchProcessDeletions();
        }
        #endregion

        #region Methods
        // Used by MainForm to print a msg for trackedProcs that were already running before trakr started
        public string GetStartupString() {
            Utils.SysCalls.Print(_trackedProcs.Count + " processes are currently being tracked.");
            return _trackedProcs.Count + " processes are currently being tracked.";
        }

        public List<string> GetRunningProcs() {
            return _runningTrackedProcs;
        }

        // Watches for when any new process is created
        private void WatchProcessCreations() {
            ManagementEventWatcher startWatch = new ManagementEventWatcher(
                "SELECT * FROM __InstanceCreationEvent WITHIN 5 WHERE TargetInstance ISA 'Win32_Process'");
            startWatch.EventArrived += startWatch_EventArrived;
            startWatch.Start();
        }

        private void WatchProcessDeletions() {
            ManagementEventWatcher stopWatch = new ManagementEventWatcher(
                "SELECT * FROM __InstanceDeletionEvent WITHIN 5 WHERE TargetInstance ISA 'Win32_Process'");
            stopWatch.EventArrived += stopWatch_EventArrived;
            stopWatch.Start();
        }
        #endregion

        #region LocalEventHandlers
        // Fired when a new process is received
        private void startWatch_EventArrived(object sender, EventArrivedEventArgs e) {
            ManagementBaseObject targetInstance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            string name = targetInstance["Name"]?.ToString();

            // If the new process is in _trackedProcs and has not yet been added to _runningTrackedProcs
            if (_trackedProcs.Contains(name) && !_runningTrackedProcs.Contains(name)) {
                _runningTrackedProcs.Add(name);

                // Send message that proc has started to MainForm
                Utils.SysCalls.Print(name + " started");
                OnTrackedProcEvent?.Invoke(this, name + " started");
            }

            // Cleanup event args
            e.NewEvent.Dispose();
        }

        private void stopWatch_EventArrived(object sender, EventArrivedEventArgs e) {
            ManagementBaseObject targetInstance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            string name = targetInstance["Name"]?.ToString();

            if (_trackedProcs.Contains(name) && _runningTrackedProcs.Contains(name)) {
                _runningTrackedProcs.Remove(name);

                Utils.SysCalls.Print(name + " stopped");
                OnTrackedProcEvent?.Invoke(this, name + " stopped");
            }

            // Cleanup event args
            e.NewEvent.Dispose();
        }
        #endregion
    }
}
