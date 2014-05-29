using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class settings
    {
        public static Zoom formZoom;
        public static Hotkeys hotkeys;
        public static ScriptManager scriptManager;

    }
    static class FileFormat
    {
        public static String newlineCharacter = Environment.NewLine;
        public static String postTitle = "==";
        public static String taskStart = "```sh";
        public static String taskEnd = "```";
        public static String cmdTypePost = ":";

        public static String argumentPre = "- ";
        //arguments        
        public static String copyTo = "to:   ";
        public static String copyFrom = "from: ";

        public static String newFileFormat = "started\n\nCopy:\n- from: here\n- to:   there";

    }
    public enum CommandType
    {
        String, Run, Copy, Delete, Mouse
    }

    //int promptValue = Prompt.ShowDialog("Test", "123");
    public static class Prompt
    {
        public static String ShowDialog(string text, string caption, string defaultText)
        {
            Form prompt = new Form();
            prompt.Width = 220;
            prompt.Height = 130;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 0, Top = 10, Text = text };
            TextBox inputBox = new TextBox() { Left = 10, Top = 35, Width = 190 };
            inputBox.Text = defaultText;
            //NumericUpDown inputBox = new NumericUpDown() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 0, Top = 70, Width = 200 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.ShowDialog();
            prompt.AcceptButton = confirmation;
            return inputBox.Text;
        }
    }
}
