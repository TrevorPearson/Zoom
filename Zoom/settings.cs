using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
}
