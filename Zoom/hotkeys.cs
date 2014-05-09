using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{

    class Hotkeys
    {
        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetKeyboardState(byte[] lpKeyState);

        public Hotkeys()
        {
            settings.hotkeys = this;
        }

        public void registerHotkeys(IntPtr Handle)
        {
            
            //http://www.fluxbytes.com/csharp/how-to-register-a-global-hotkey-for-your-application-in-c/
            int id = 0;     // The id of the hotkey. 
            RegisterHotKey(Handle, id, (int)KeyModifier.Control, Keys.Q.GetHashCode());       // Register Shift + A as global hotkey. 
            id++;
            RegisterHotKey(Handle, id, (int)KeyModifier.Control, Keys.W.GetHashCode());       // Register Shift + A as global hotkey. 
            id++;
            RegisterHotKey(Handle, id, (int)KeyModifier.Control, Keys.E.GetHashCode());       // Register Shift + A as global hotkey. 
        }

        public void hotkeyPressedLogic(Message m)        
        {            

            if (m.Msg == 0x0312)
            {
                /* Note that the three lines below are not needed if you only want to register one hotkey.
                 * The below lines are useful in case you want to register multiple keys, which you can use a switch with the id as argument, or if you want to know which key/modifier was pressed for some particular reason. */

                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.

                if (key == Keys.W)
                {
                    SetKeyboardState(new byte[256]);
                    settings.formZoom.sendCommand();                        
                }

                //MessageBox.Show("Hotkey has been pressed!" + key);
                // do something
            }
        }
    }
}
