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
 
 
        public Zoom()
        {
            settings.formZoom = this;
            InitializeComponent();

            //Open up "Open Dialog"

            //process file

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

        public void sendCommand()
        {
            SendKeys.SendWait(this.textBox_cmd.Text);   
        }

 
        private void ExampleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 0);       // Unregister hotkey with id 0 before closing the form. You might want to call this more than once with different id values if you are planning to register more than one hotkey.
        }

        private void textBox_cmd_TextChanged(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScriptManager sm = new ScriptManager(); //I could just reuse the old object if this is a problem.
            sm.loadFile();            
        }
        public Zoom setCommandText(String newText)
        {
            textBox_cmd.Text = newText;
            return this;
        }
        public Zoom setCommandType(String newText)
        {
            comboBox_cmd.Text = newText;
            return this;
        }
        public Zoom setTaskText(String newText)
        {
            //textBox_task.Text = "hey\n" + String.Join(Environment.NewLine,newText);
            textBox_task.Lines = newText.Split(Environment.NewLine.ToCharArray());
            return this;
        }
        public Zoom setScriptTitle(String newText)
        {
            this.Text = newText;
            return this;
        }
    }
}