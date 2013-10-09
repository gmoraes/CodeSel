using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickCodeSel.Util
{
    public class QuickCodeSelCommand
    {
        public string Line { get; private set; }
        public string Command { get; set; }
        public string[] Commands { get; set; }
        public string[] Params { get; set; }
        private int CurrentValue { get; set; }

        public QuickCodeSelCommand(string Line) 
        {
            this.Line = Line;
            Command = StringHelper.GetCommand(Line);
            Commands = Command.Split('|');
            Params = StringHelper.GetParams(Line);
            CurrentValue = 0;
        }

        public string Next
        {
            get
            {
                CurrentValue++;
                return Current;
            }
        }
        
        public string Previous
        {
            get
            {
                CurrentValue--;
                return Current;
            }
        }      

        public string Current
        { 
            get 
            {
                return Commands[CurrentValue];
            } 
        }
    }
}
