﻿using System;
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
        //List<string> words = new string[] { "Hello", "world" }.ToList();
        List<ScriptTask> tasks = null;
        //ScriptTask[] tasks = null;
        int currentTask = 0;
        String scriptTitle = "Unloaded";
        String filePath = null;
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
        public void loadNewScript()
        {
            scriptTitle = "New";

            tasks = new List<ScriptTask>();
            tasks.Add(new ScriptTask(FileFormat.newFileFormat));
            //tasks[0] = new ScriptTask(FileFormat.newFileFormat);

            initializeScript();
        }
        public ScriptManager setScriptTitle(String newTitle)
        {
            scriptTitle = newTitle;
            settings.formZoom.setScriptTitle(scriptTitle);
            return this;
        }
        public void loadFile(String inputPath)
        {
            Boolean invalidFile = false; //set to true
            //String inputPath = "E:\\Downloads\\Zoom.md";
            fileText = System.IO.File.ReadAllText(inputPath);
            filePath = inputPath;
            //Regex regTitle = new Regex("[^==]*");
            Regex regTitle = new Regex("[^=]*");
            Regex regTask = new Regex("```sh[^(```)]*");

            scriptTitle = regTitle.Match(fileText).Value.Trim();

            //Load in modes, vars...
            //TODO

            //Load in tasks
            {
                tasks = new List<ScriptTask>();
                
                //tasks = new ScriptTask[regTask.Matches(fileText).Count];
                int taskCtr = 0;
                
                foreach (Match match in regTask.Matches(fileText))
                {
                    //String thisMatch = match.ToString().Substring(5);
                    String thisMatch = match.ToString().Substring(5).Trim();  //TODO fix hard coded 5

                    tasks.Add(new ScriptTask(thisMatch));
                    //tasks[taskCtr] = new ScriptTask(thisMatch);
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
        public void loadTask()
        {
            settings.formZoom.setCommandText(getLoadedCommandText(), getLoadedCommandType()).setTaskText(getLoadedTaskPrompt()).setCommandType(getLoadedCommandType());
        }
        private void initializeScript()
        {
            settings.formZoom.setScriptTitle(scriptTitle);
            loadTask();
        }
        public void saveScriptToFile()
        {
            saveAsScriptToFile(filePath);
        }
        public ScriptManager insertNewTaskBefore()
        {
            insertNewTaskAt(currentTask);
            loadTask();
            return this;
        }
        private ScriptManager insertNewTaskAt(int location)
        {

            tasks.Insert(location, new ScriptTask());
            return this;
        }
        public void saveAsScriptToFile(String saveFilePath)
        {
            Boolean invalidFile = false; //set to true
            //fileText = System.IO.File.ReadAllText("E:\\Downloads\\Zoom.md");

            String fileString = ""; //Save this string to the file

            //TITLE
            fileString += scriptTitle + FileFormat.newlineCharacter ;
            fileString += FileFormat.postTitle + FileFormat.newlineCharacter;

            //Mode and vars

            //Tasks
            foreach (ScriptTask task in tasks)
            {
                fileString += task.taskToSaveString();
                fileString += FileFormat.newlineCharacter;
            }

            if (invalidFile)
            {
                //TODO make an error
                return;
            }
            File.WriteAllText(saveFilePath, fileString.Trim());
        }
        public void runTask()
        {
            CommandType currentCmd = getCurrentCommandType();
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
        public void stepForward()
        {
            if (settings.formZoom.getSaveMode())
                saveTaskData();

            currentTask += 1;
            if (currentTask >= tasks.Count)
                currentTask = tasks.Count - 1;
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
            setCmdType(settings.formZoom.getCommandType());
            setCmdText(settings.formZoom.getCommandTextAll());

        }
        public String[] getLoadedCommandText()
        {
            return getLoadedCommandText(currentTask);
        }
        public String[] getLoadedCommandText(int taskNum)
        {
            return tasks[taskNum].cmdsText;
        }
        private CommandType getCurrentCommandType()
        {
            return settings.formZoom.getCommandType();
        }

        public CommandType getLoadedCommandType()
        {
            return getLoadedCommandType(currentTask);
        }
        public CommandType getLoadedCommandType(int taskNum)
        {
            return tasks[taskNum].cmdType;
        }
        public String getLoadedTaskPrompt()
        {
            return getLoadedTaskPrompt(currentTask);
        }
        public String getLoadedTaskPrompt(int taskNum)
        {
            return tasks[taskNum].promptText;
        }
        private ScriptManager setTaskPrompt(String newPrompt)
        {
            setTaskPrompt(newPrompt,currentTask);
            return this;
        }
        private ScriptManager setTaskPrompt(String newPrompt, int taskNum)
        {
            tasks[taskNum].promptText = newPrompt;
            return this;
        }
        private ScriptManager setCmdType(CommandType newPrompt)
        {
            setCmdType(newPrompt, currentTask);
            return this;
        }
        private ScriptManager setCmdType(CommandType newPrompt, int taskNum)
        {
            tasks[taskNum].cmdType = newPrompt;
            return this;
        }
        private ScriptManager setCmdText(String[] newPrompt)
        {
            tasks[currentTask].setCmd(newPrompt);
            return this;
        }
        private ScriptManager setCmdText(String newPrompt)
        {
            setCmdText(newPrompt, currentTask);
            return this;
        }
        private ScriptManager setCmdText(String newPrompt, int taskNum)
        {
            tasks[taskNum].setCmd(0, newPrompt);
            return this;
        }

        internal string getScriptTitle()
        {
            return scriptTitle;
        }
    }
    class ScriptTask
    {
        //Dictionary<string,string> cmdLines = new Dictionary<string, string>();

        public String promptText = null;
        public CommandType cmdType;
        //public String cmdText = null;
        public String[] cmdsText = new String[1];


        //Regex regTask = new Regex("[^("+Environment.NewLine+Environment.NewLine+")]*");
        //Regex regTask = new Regex("^\\s{14}(?<(?!\\n\\n)>(?s)(?:(?!\\n\\n).)*)");
        Regex regTask = new Regex("Stop.*");

//        private static Regex _newlinesLeadingTrailing = new Regex(@"^\n+|\n+\z", RegexOptions.Compiled);
 //       private static Regex _newlinesMultiple = new Regex(@"\n{2,}", RegexOptions.Compiled);
  //      private static Regex _leadingWhitespace = new Regex(@"^[ ]*", RegexOptions.Compiled);

        public ScriptTask()
        {
            promptText = "";
            cmdType = CommandType.String;
            cmdsText[0] = "";
        }
        public ScriptTask(String bulkText)
        {
            Clipboard.SetText(bulkText);
            promptText = "";
            String[] lines = bulkText.Split(Environment.NewLine.ToCharArray());
            {
                int mode = 0;
                int cmdCtr = 0;
                foreach (String line in lines)
                {
                    if (mode == 0 && line == "")
                    {
                        mode = 1;
                        continue;
                    }
                    if (line == "")
                    {                        
                        continue;
                    }        
                    if (mode ==0)
                        promptText += line + "\n";
                    if (mode == 1)
                    {
                        mode = 2;
                        cmdType = (CommandType)Enum.Parse(typeof(CommandType), line.Substring(0, line.Length - 1),true); //Don't be all case sensitive

                        if (cmdType == CommandType.Copy)
                            cmdsText = new String[2];
                        //cmdType += line.Substring(0, line.Length-1);
                        continue;
                    }
                    if (mode == 2)
                    {
                        String temp = line.Substring(FileFormat.argumentPre.Length);
                        if (cmdType == CommandType.Copy)
                        {
                            //temp = line.Substring(FileFormat.copyFrom.Length);
                            temp = temp.Replace(FileFormat.copyFrom, "");
                            temp = temp.Replace(FileFormat.copyTo, "");
                        }
                        cmdsText[cmdCtr] = temp;
                        cmdCtr++;
                    }
                }
            }
            
            //promptText = regTask.Match(bulkText).Value.Trim();
            //promptText = bulkText;
            //cmdText = regTask.Match(bulkText).Value.Trim(); //bulkText;

        }
        public String getCmd(int number)
        {
            return cmdsText[number];
        }
        public ScriptTask setCmd(String[] newString)
        {
            cmdsText = newString;
            return this;
        }
        public ScriptTask setCmd(int number, String newString)
        {
            cmdsText[number] = newString;
            return this;
        }
        private String getCmdSaveString()
        {
            String[] lines = new String[1];// cmdText.Trim().Split(Environment.NewLine.ToCharArray());

            if (cmdType == CommandType.Copy)
            {
                lines = new String[2];
                lines[0] = FileFormat.copyFrom + cmdsText[0];
                lines[1] = FileFormat.copyTo + cmdsText[1];
                //lines[0] = FileFormat.copyFrom + lines[0];
                //lines[1] = FileFormat.copyTo + lines[1];
            }
            else
            {
                lines[0] = cmdsText[0];
            }

            for (int ctr = 0; ctr < lines.Count(); ctr++)
            {
                lines[ctr] = FileFormat.argumentPre + lines[ctr];
            }

            return String.Join(FileFormat.newlineCharacter, lines);
            
        }
        public String taskToSaveString()
        {
            String taskText = FileFormat.taskStart + FileFormat.newlineCharacter;

            //save prompt
            taskText += promptText.Trim();
            taskText += FileFormat.newlineCharacter + FileFormat.newlineCharacter;
            //save cmd type
            taskText += cmdType.ToString() + FileFormat.cmdTypePost;
            taskText += FileFormat.newlineCharacter;
            //save cmd text
            taskText += getCmdSaveString();
            taskText += FileFormat.newlineCharacter;

            taskText += FileFormat.taskEnd;
            

            return taskText;
        }
    }
}
