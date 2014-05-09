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
    public partial class Zoom : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        Hotkeys hotkeys = new Hotkeys();
 
        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }
 
        public Zoom()
        {
            InitializeComponent();


            hotkeys.registerHotkeys(this.Handle);
            
        }
 
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            hotkeys.hotkeyPressedLogic(m);
            
        }
 
        private void ExampleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 0);       // Unregister hotkey with id 0 before closing the form. You might want to call this more than once with different id values if you are planning to register more than one hotkey.
        }
    }
}