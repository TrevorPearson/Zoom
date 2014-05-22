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
        public Zoom setCommandText(String newText, CommandType type)
        {
            Boolean error = false;
            if (type == CommandType.Copy)
            {
                string[] lines = newText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                if (lines.Length != 2)
                    error = true;

                if (error)
                {
                    textBox_primary.Text = "error" + lines.Length;
                    return this;
                }

                lines[0]= lines[0].Replace("from:", "");
                lines[1] = lines[1].Replace("to:", "");

                textBox_primary.Text = lines[0].Trim();
                textBox_secondary.Text = lines[1].Trim();

                return this;
            }
            textBox_primary.Text = newText;
            return this;
        }
        public String getCommandText()
        {
            return textBox_primary.Text;
        }
        public String getCmd2Text()
        {
            return textBox_secondary.Text;
        }
        public String getTaskText()
        {
            String output = "";
            foreach (String line in textBox_task.Lines)
            {
                output = output + "\n" + line;
            }
            return output.Trim();
        }
        public Zoom setCommandType(CommandType cmdType)
        {
            comboBox_cmd.Text = cmdType.ToString();
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
        private void comboBox_cmd_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO make this more object oriented
            ComboBox comboBox = (ComboBox)sender;
            CommandType pick = (CommandType)comboBox.SelectedIndex;
            switch (pick)
            {
                case CommandType.Copy: //copy
                    label_primary.Text = "From:";
                    label_secondary.Visible = true;
                    textBox_secondary.Visible = true;
                    break;
                default:
                    label_primary.Text = "Command:";
                    label_secondary.Visible = false;
                    textBox_secondary.Visible = false;
                    break;
            }
        }
    }
}