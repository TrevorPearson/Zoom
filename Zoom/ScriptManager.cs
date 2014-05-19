using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class ScriptManager
    {
        ScriptTask[] tasks = null;
        int currentTask = 0;
        String scriptTitle = "Unloaded";
        String fileText = null;

        public ScriptManager()
        {
            settings.scriptManager = this;
        }
        public ScriptManager(Boolean setGlobal)
        {
            if (setGlobal==true)
                settings.scriptManager = this;
        }
        public void loadFile()
        {
            Boolean invalidFile = false; //set to true
            fileText = System.IO.File.ReadAllText("E:\\Downloads\\Zoom.md");

            //Regex regTitle = new Regex("[^==]*");
            Regex regTitle = new Regex("[^=]*");
            Regex regTask = new Regex("```sh[^(```)]*");

            scriptTitle = regTitle.Match(fileText).Value.Trim();

            //Load in modes, vars...
            //TODO

            //Load in tasks
            {              
                tasks = new ScriptTask[regTask.Matches(fileText).Count];
                int taskCtr = 0;
                
                foreach (Match match in regTask.Matches(fileText))
                {
                    //String thisMatch = match.ToString().Substring(5);
                    String thisMatch = match.ToString().Substring(5).Trim();
                    tasks[taskCtr] = new ScriptTask(thisMatch);
                    taskCtr += 1;
                }
            }


            if (invalidFile)
            {
                //TODO make an error
                return;
            }
            initializeScript();
        }
        private void initializeScript()
        {
            settings.formZoom.setScriptTitle(scriptTitle);
            settings.formZoom.setCommandText(getCommandText()).setTaskText(getTaskPrompt()).setCommandType(getCommandType());
        }

        public String getCommandText()
        {
            return getCommandText(currentTask);
        }
        public String getCommandText(int taskNum)
        {
            return tasks[taskNum].cmdText;
        }
        public String getCommandType()
        {
            return getCommandType(currentTask);
        }
        public String getCommandType(int taskNum)
        {
            return tasks[taskNum].cmdType;
        }
        public String getTaskPrompt()
        {
            return getTaskPrompt(currentTask);
        }
        public String getTaskPrompt(int taskNum)
        {
            return tasks[taskNum].promptText;
        }
    }
    class ScriptTask
    {
        //Dictionary<string,string> cmdLines = new Dictionary<string, string>();

        public String promptText = null;
        public String cmdType = null;
        public String cmdText = null;


        //Regex regTask = new Regex("[^("+Environment.NewLine+Environment.NewLine+")]*");
        //Regex regTask = new Regex("^\\s{14}(?<(?!\\n\\n)>(?s)(?:(?!\\n\\n).)*)");
        Regex regTask = new Regex("Stop.*");

//        private static Regex _newlinesLeadingTrailing = new Regex(@"^\n+|\n+\z", RegexOptions.Compiled);
 //       private static Regex _newlinesMultiple = new Regex(@"\n{2,}", RegexOptions.Compiled);
  //      private static Regex _leadingWhitespace = new Regex(@"^[ ]*", RegexOptions.Compiled);

        public ScriptTask(String bulkText)
        {

            promptText = "";
            String[] lines = bulkText.Split(Environment.NewLine.ToCharArray());
            {
                int mode = 0;
                foreach (String line in lines)
                {
                    if (line == "")
                    {
                        mode = 1;
                        continue;
                    }                    

                    if (mode ==0)
                        promptText += line + "\n";
                    if (mode == 1)
                    {
                        mode = 2;
                        cmdType += line.Substring(0, line.Length-1);
                        continue;
                    }
                    if (mode == 2)
                        cmdText += line.Substring(2) + "\n";
                }
            }
            //promptText = regTask.Match(bulkText).Value.Trim();
            //promptText = bulkText;
            //cmdText = regTask.Match(bulkText).Value.Trim(); //bulkText;

        }
    }
}
