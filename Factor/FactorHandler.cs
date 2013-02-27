using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Factor
{
    public class FactorHandler
    {
        TextBox input;
        TextBox output;

        public FactorHandler(TextBox xinput, TextBox xoutput)
        {
            input = xinput;
            output = xoutput;
        }

        public void Run()
        {
            List<int> nums = ParseInput(input.Lines.ToList());
            string results = "";
            foreach (int n in nums)
            {
                List<List<int>> result = new List<List<int>>();
                double value = (double) n;
                bool done = false;
                List<int> factors = new List<int>();
                List<int> temp = new List<int>() { (int) value };
                result.Add(temp);
                while (!done)
                {
                    done = true;
                    for (double c = 2; c < value/2 + 1; c++)
                    {
                        bool s = value / c == Math.Round(value / c, 0);
                        if (s)
                        {
                            value = value / c;
                            List<int> current = new List<int>();
                            factors.Insert(0, (int)c);
                            current.Add((int)value);
                            current.AddRange(factors);
                            result.Add(current);
                            done = false;
                            break;
                        }
                        done = true;
                    }
                }
                results = results + StringParse(result);
            }
            char[] chars = { '\r', '\n' };
            output.Text = results; results.TrimEnd(chars);
        }

        public string StringParse(List<List<int>> results)
        {
            string result = "";
            foreach (List<int> list in results)
            {
                string line = "";
                int index = 0;
                foreach (int n in list)
                {
                    line = line + n;
                    if (index != (list.Count - 1))
                        line = line + " x ";
                    index++;
                }
                result = result + line + "\r\n";
            }
            List<int> last = results[results.Count - 1].ToList();
            string s = "";
            bool success = false;
            while (last.Count > 0)
            {
                int n = last[0];
                Predicate<int> isequal =
                    x => x == n;
                int count = last.FindAll(isequal).Count;
                last.RemoveAll(isequal);
                s = s + n;
                if (count > 1)
                {
                    s = s + " ^ " + count;
                    success = true;
                }
                if (last.Count > 0)
                    s = s + " x ";
            }
            if (success)
                result = result + s + "\r\n";
            result = result + "\r\n";
            return result;
        }

        public List<int> ParseInput(List<string> xinput)
        {
            List<int> list = new List<int>();
            foreach (string s in xinput)
            {
                try { list.Add(int.Parse(s)); }
                catch { }
            }
            return list;
        }
    }
}
