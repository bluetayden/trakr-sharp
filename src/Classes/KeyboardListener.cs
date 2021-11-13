using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace trakr_sharp {

    /// <summary>
    /// This implementation was taken directly from the links below and shortened slightly: 
    /// https://stackoverflow.com/a/34290332/17313384                                             
    /// https://stackoverflow.com/a/62509480/17313384
    /// </summary>

    public class KeyboardListener : IDisposable {
        #region Imports/Fields

        public delegate void ErrorEventHandler(Exception e);
        public delegate void LocalKeyEventHandler(Keys key);
        public event LocalKeyEventHandler KeyDown;
        public event LocalKeyEventHandler KeyUp;
        public event ErrorEventHandler OnError;

        public delegate int CallbackDelegate(int Code, IntPtr W, IntPtr L);

        public enum KeyEvents {
            KeyDown = 0x0100,
            KeyUp = 0x0101,
            SKeyDown = 0x0104,
            SKeyUp = 0x0105
        }

        [DllImport("user32", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr SetWindowsHookEx(HookType idHook, CallbackDelegate lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32", CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(IntPtr idHook);

        [DllImport("user32", CallingConvention = CallingConvention.StdCall)]
        private static extern int CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetCurrentThreadId();

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        public enum HookType : int {
            WH_JOURNALRECORD = 0,
            WH_JOURNALPLAYBACK = 1,
            WH_KEYBOARD = 2,
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CBT = 5,
            WH_SYSMSGFILTER = 6,
            WH_MOUSE = 7,
            WH_HARDWARE = 8,
            WH_DEBUG = 9,
            WH_SHELL = 10,
            WH_FOREGROUNDIDLE = 11,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }

        private IntPtr HookID = IntPtr.Zero;
        CallbackDelegate TheHookCB = null;
        #endregion

        #region Constructor
        //Start hook
        public KeyboardListener() {
            TheHookCB = new CallbackDelegate(KeybHookProc);
            IntPtr hInstance = LoadLibrary("User32");
            HookID = SetWindowsHookEx(HookType.WH_KEYBOARD_LL, TheHookCB,
                hInstance, //0 for local hook. or hwnd to user32 for global
                0); //0 for global hook.
        }
        #endregion

        #region Disposal
        bool IsFinalized = false;
        ~KeyboardListener() {
            if (!IsFinalized) {
                UnhookWindowsHookEx(HookID);
                IsFinalized = true;
            }
        }
        public void Dispose() {
            if (!IsFinalized) {
                UnhookWindowsHookEx(HookID);
                IsFinalized = true;
            }
        }
        #endregion

        #region Listener
        [STAThread]
        //The listener that will trigger events
        private int KeybHookProc(int Code, IntPtr W, IntPtr L) {
            if (Code < 0) {
                return CallNextHookEx(HookID, Code, W, L);
            }
            try {
                KeyEvents kEvent = (KeyEvents)W;

                Int32 vkCode = Marshal.ReadInt32((IntPtr)L);

                if (kEvent != KeyEvents.KeyDown && kEvent != KeyEvents.KeyUp && kEvent != KeyEvents.SKeyDown && kEvent != KeyEvents.SKeyUp) {
                }
                if (kEvent == KeyEvents.KeyDown || kEvent == KeyEvents.SKeyDown) {
                    if (KeyDown != null) KeyDown((Keys)vkCode);
                }
                if (kEvent == KeyEvents.KeyUp || kEvent == KeyEvents.SKeyUp) {
                    if (KeyUp != null) KeyUp((Keys)vkCode);
                }
            }
            catch (Exception e) {
                if (OnError != null) OnError(e);
                //Ignore all errors
            }

            return CallNextHookEx(HookID, Code, W, L);
        }
        #endregion
    }
}
