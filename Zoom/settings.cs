﻿using System;
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
    public enum CommandType
    {
        String, Run, Copy, Delete, Mouse
    }
}
