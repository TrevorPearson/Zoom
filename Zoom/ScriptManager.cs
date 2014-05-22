using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

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
            settings.formZoom.setCommandText(getCommandText(), getCommandType()).setTaskText(getTaskPrompt()).setCommandType(getCommandType());
        }
        public void runTask()
        {
            CommandType currentCmd = getCommandType();
            switch (currentCmd)
            {
                case CommandType.Run: 
                    Process.Start(settings.formZoom.getCommandText());
                    break;
                case CommandType.String:
                    SendKeys.SendWait(settings.formZoom.getCommandText());
                    break;
                case CommandType.Copy:
                    //TODO support wildcards
                    File.Copy(settings.formZoom.getCommandText(),settings.formZoom.getCmd2Text(),true); //overwrite
                    break;
                default:
                    break;
            }
            
        }
        public void loadTask()
        {
            settings.formZoom.setCommandText(getCommandText(), getCommandType()).setTaskText(getTaskPrompt()).setCommandType(getCommandType());
        }
        public void stepForward()
        {
            saveTaskData();

            currentTask += 1;
            if (currentTask >= tasks.Length)
                currentTask = tasks.Length -1;
            loadTask();
        }
        public void stepBackward()
        {
            saveTaskData();
            currentTask -= 1;
            if (currentTask < 0)
                currentTask = 0;
            loadTask();
        }
        private void saveTaskData()
        {
            //we need to be smarter than this
            setTaskPrompt(settings.formZoom.getTaskText());

        }
        public String getCommandText()
        {
            return getCommandText(currentTask);
        }
        public String getCommandText(int taskNum)
        {
            return tasks[taskNum].cmdText.Trim();
        }
        public CommandType getCommandType()
        {
            return getCommandType(currentTask);
        }
        public CommandType getCommandType(int taskNum)
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
        public ScriptManager setTaskPrompt(String newPrompt)
        {
            setTaskPrompt(newPrompt,currentTask);
            return this;
        }
        public ScriptManager setTaskPrompt(String newPrompt, int taskNum)
        {
            tasks[taskNum].promptText = newPrompt;
            return this;
        }
    }
    class ScriptTask
    {
        //Dictionary<string,string> cmdLines = new Dictionary<string, string>();

        public String promptText = null;
        public CommandType cmdType;
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
                        cmdType = (CommandType)Enum.Parse(typeof(CommandType), line.Substring(0, line.Length - 1),true); //Don't be all case sensitive
                        //cmdType += line.Substring(0, line.Length-1);
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
