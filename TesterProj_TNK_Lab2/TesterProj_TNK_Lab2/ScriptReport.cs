using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesterProj_TNK_Lab2
{
    public class ScriptReport
    {
        public List<string> Report { get; private set; }
        public ScriptReport()
        {
            Report = new List<string>();
        }
        public void AddTopic(string topicName)
        {
            Report.Add("-----"+topicName+"-----");
        }
        public void AddContent(string content)
        {
            Report.Add(content);
        }
        public override string ToString()
        {
            return Report.ToString();
        }
    }
}
