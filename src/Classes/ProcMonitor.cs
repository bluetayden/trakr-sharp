using System;
using System.Collections.Generic;
using System.Management;
using System.Timers;
using Timer = System.Timers.Timer;

namespace trakr_sharp {
    public class ProcMonitor {
        public delegate void OnTrackedProcEventDelegate(ProcMonitor sender, string msg);
        public event OnTrackedProcEventDelegate OnTrackedProcEvent;
        private List<string> _trackedProcs;
        private Dictionary<string, int> _runningTrackedPairs;

        #region Init
        public ProcMonitor() {
            UpdateTrackingFields();
            WatchProcessCreations();
            WatchProcessDeletions();
        }
        #endregion

        #region Get/Set
        /// <summary>
        /// Used by MainForm to print a msg for trackedProcs that were already running before trakr started
        /// </summary>
        public string GetStartupString() {
            Utils.SysCalls.Print(_trackedProcs.Count + " processes are currently being tracked");
            return _trackedProcs.Count + " processes are currently being tracked";
        }

        public List<string> GetRunningProcs() {
            List<string> keyList = new List<string>(_runningTrackedPairs.Keys);
            return keyList;
        }

        public int GetRunningCount() {
            return _runningTrackedPairs.Count;
        }

        public int GetTrackedCount() {
            return _trackedProcs.Count;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Used to update _trackedProcs and _runningTrackedPairs when a db update ocurrs or on init
        /// </summary>
        public void UpdateTrackingFields() {
            _trackedProcs = Utils.Database.GetProcessNameList();
            _runningTrackedPairs = Utils.SysCalls.GetRunningTrackedPairs();
        }

        /// <summary>
        /// Forces the instance counts of the provided procs to zero
        /// </summary>
        public void ForceCountsToZero(List<string> procNames) {
            foreach (string name in procNames) {
                if (_runningTrackedPairs.ContainsKey(name)) {
                    // remove key from _runningTrackedPairs
                    _runningTrackedPairs.Remove(name);
                    // print process stopped
                    Utils.SysCalls.Print(name + " stopped");
                    OnTrackedProcEvent?.Invoke(this, name + " stopped");
                }
            }
        }

        /// <summary>
        /// Watches for when any new process is created
        /// </summary>
        private void WatchProcessCreations() {
            ManagementEventWatcher startWatch = new ManagementEventWatcher(
                "SELECT * FROM __InstanceCreationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_Process'");
            startWatch.EventArrived += startWatch_EventArrived;
            startWatch.Start();
        }

        /// <summary>
        /// Watches for when any processes are closed
        /// </summary>
        private void WatchProcessDeletions() {
            ManagementEventWatcher stopWatch = new ManagementEventWatcher(
                "SELECT * FROM __InstanceDeletionEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_Process'");
            stopWatch.EventArrived += stopWatch_EventArrived;
            stopWatch.Start();
        }
        #endregion

        #region Local Event Handlers
        /// <summary>
        /// Fired when a new process is received
        /// </summary>
        private void startWatch_EventArrived(object sender, EventArrivedEventArgs e) {
            ManagementBaseObject targetInstance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            string name = targetInstance["Name"]?.ToString();

            //  If the new process is in _trackedProcs
            if (_trackedProcs.Contains(name)) {
                // If process has not yet been added to _runningTrackedProcs
                if (!_runningTrackedPairs.ContainsKey(name)) {
                    // Add KVP of name with instance count of 1
                    _runningTrackedPairs.Add(name, 1);
                    // Send message that proc has started to MainForm
                    Utils.SysCalls.Print(name + " started");
                    OnTrackedProcEvent?.Invoke(this, name + " started");
                }
                // else if process is already in _runningTrackedProcs, inc count
                else {
                    _runningTrackedPairs[name] += 1;
                    Utils.SysCalls.Print("Updated instance count of " + name + " to " + _runningTrackedPairs[name]);
                }
            }

            // Cleanup event args
            targetInstance.Dispose();
            e.NewEvent.Dispose();
        }

        /// <summary>
        /// Fired when a process is stopped
        /// </summary>
        private void stopWatch_EventArrived(object sender, EventArrivedEventArgs e) {
            ManagementBaseObject targetInstance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            string name = targetInstance["Name"]?.ToString();

            // If stopped process in _runningTrackedPairs
            if (_runningTrackedPairs.ContainsKey(name)) {
                // Decrease instance count
                _runningTrackedPairs[name] -= 1;
                Utils.SysCalls.Print("Updated instance count of " + name + " to " + _runningTrackedPairs[name]);

                // If instance count is now 0, or an explicit check shows the proc is not running
                if (_runningTrackedPairs[name] == 0 || !Utils.SysCalls.ProcIsRunning(name)) {
                    // remove key from _runningTrackedPairs
                    _runningTrackedPairs.Remove(name);
                    // print process stopped
                    Utils.SysCalls.Print(name + " stopped");
                    OnTrackedProcEvent?.Invoke(this, name + " stopped");
                }
            }

            // Cleanup event args
            targetInstance.Dispose();
            e.NewEvent.Dispose();
        }
        #endregion
    }
}
