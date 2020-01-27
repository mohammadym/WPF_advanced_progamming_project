using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
namespace UI
{
 
    public partial class MainWindow : Window
    {
        public List<Info> Persons = new List<Info>();
        public MainWindow()
        {
            InitializeComponent();
            Clock  clock= new Clock(LeftCanvas, ClockDayLabel, SecondCounter, MinuteCounter, MinutePointer, HourCounter, HourPointer);
            clock.Run();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }


        void clear()
        {
            Sheet.Clear();
        }

        
        private void LoadButton_click(object sender, RoutedEventArgs e)
        {
            string equation1="";
            string equation2="";
            List<string> InputInfo = new List<string>();
            var Input = Sheet.Text;
            string [] result = Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            for(int i=0;i<result.Length;i++)
            {
                InputInfo.Add(result[i]);
            }
            List<char> Horof = new List<char>();
            List<int> equations = new List<int>();
            int age=0;
            for(int i=3;i<InputInfo.Count;i++)
            {
                List<char> Moteghayer = new List<char>();
                string str = InputInfo[i];
                if (Info.IsNumber(InputInfo[i])==true)
                {
                    age = int.Parse(InputInfo[i]);
                }
                if(str.Contains("+")&&str.Contains("=")|| str.Contains("-") && str.Contains("="))
                {
                    for (int k = 0; k < str.Length; k++)
                    {
                        if (str[k] == 'a' || str[k] == 'b' || str[k] == 'b' || str[k] == 'c' || str[k] == 'd' || str[k] == 'e' ||
                            str[k] == 'f' || str[k] == 'g' || str[k] == 'h' || str[k] == 'i' || str[k] == 'j' || str[k] == 'k' ||
                            str[k] == 'l' || str[k] == 'm' || str[k] == 'n' || str[k] == 'o' || str[k] == 'p' || str[k] == 'q' || str[k] == 'w' ||
                            str[k] == 'r' || str[k] == 't' || str[k] == 'y' || str[k] == 'u' || str[k] == 'z' || str[k] == 'x' || str[k] == 'v'
                            )
                            Moteghayer.Add(str[k]);
                    }
                    string zarib2="";
                    string[] zaribaval = str.Split(Moteghayer[0]);
                    string[] zaribdovom = zaribaval[1].Split(Moteghayer[1]);
                    string[] constant = str.Split('=');
                    for(int y=0;y<zaribdovom[0].Length;y++)
                    {
                        zarib2 += zaribdovom[0][y];
                    }
                    if(zaribaval[0]=="")
                    {
                        zaribaval[0] = "1";
                    }
                    if (zarib2 == "")
                    {
                        zarib2 = "1";
                    }
                    
                    if (equations.Count == 0)
                    {
                        equations.Add(int.Parse(zaribaval[0]));
                        equations.Add(int.Parse(zarib2));
                        equations.Add(int.Parse(constant[1]));
                        Horof.Add(Moteghayer[0]);
                        Horof.Add(Moteghayer[1]);
                        equation1 = str;
                    }
                    else
                    {
                        if(Horof[0]==Moteghayer[0]&&Horof[1]==Moteghayer[1])
                        {
                            equations.Add(int.Parse(zaribaval[0]));
                            equations.Add(int.Parse(zarib2));
                            equations.Add(int.Parse(constant[1]));
                            equation2 = str;
                        }
                    }
                }
                if(equations.Count==6)
                {
                    break;
                }
            }
            equation s = new equation(equations[0], equations[1], equations[2], equations[3], equations[4], equations[5]);
            s.Solve();
            bool flag = false;
            for (int i = 0; i < Persons.Count; i++)
            {
                if (Persons[i].Name == InputInfo[0] && Persons[i].Family == InputInfo[1] && Persons[i].Age == age &&
                    Persons[i].City == InputInfo[2] && Persons[i].X == equation.Answers[0] && Persons[i].Y ==
                    equation.Answers[1])
                {
                    flag = false;
                    break;
                }
                else
                    flag = true;
            }
            if(flag==true)
                Persons.Add(new Info(InputInfo[0], InputInfo[1], age, InputInfo[2], equation.Answers[0], equation.Answers[1],equation1,equation2));
            if (Persons.Count == 0)
            {
                Persons.Add(new Info(InputInfo[0], InputInfo[1], age, InputInfo[2], equation.Answers[0], equation.Answers[1], equation1, equation2));
            }
        }
        
        private void Queryclick_button(object sender, RoutedEventArgs e)
        {
            List<string> AllResult = new List<string>();
            if(QueryNum.Contains("Checkbox_1"))
            {
                float text = int.Parse(Query_1.Text);
                IEnumerable<string> result = Persons.Where(person => person.Age > text).Select(person => person.Name + " " + person.Family);
                foreach(string output in result)
                {
                    AllResult.Add(output);
                }
            }
            if(QueryNum.Contains("Checkbox_2"))
            {
                float text = int.Parse(Query_2.Text);
                IEnumerable<string> result = Persons.Where(person => person.Age < text).Select(person => person.Name + " " + person.Family);
                foreach (string output in result)
                {
                    AllResult.Add(output);
                }
            }
            if(QueryNum.Contains("Checkbox_3"))
            {
                float age = 2020 - int.Parse(Query_3.Text);
                IEnumerable<string> result = Persons.Where(person => person.Age == age).Select(person => person.Name + " " + person.Family);
                foreach (string output in result)
                {
                    AllResult.Add(output);
                }
            }
            if(QueryNum.Contains("Checkbox_4"))
            {
                double x;
                double y;
                x = double.Parse(Query_4_1.Text);
                y = double.Parse(Query_4_2.Text);
                IEnumerable<string> result = Persons.Where(person => person.X == x && person.Y == y).Select(person => person.Name + " " + person.Family);
                foreach(string output in result)
                {
                    AllResult.Add(output);
                }
            }
            if(QueryNum.Contains("Checkbox_5"))
            {
                string name = Query_5.Text;
                IEnumerable<string> result = Persons.Where(person => string.Equals(person.Name, name)).Select(person => person.Name + " " + person.Family);
                foreach (string output in result)
                {
                    AllResult.Add(output);
                }
            }
            if(QueryNum.Contains("Checkbox_6"))
            {
                string equation=Query_6.Text;
                IEnumerable<string> result = Persons.Where(person =>string.Equals(person.Equation1,equation)||string.Equals(person.Equation2
                    ,equation)).Select( person => person.Name + " " + person.Family);
                foreach(string output in result)
                {
                    AllResult.Add(output);
                }
            }
            List<int> tekrari = new List<int>();
            for(int i = 0; i < AllResult.Count; i++)
            {
                String s = AllResult[i];
                for(int j = i + 1; j < AllResult.Count; j++)
                {
                    if (s.Equals(AllResult[j]))
                        tekrari.Add(j);
                }
            }
            if (QueryNum.Count == 1)
            {
                for (int i = 0; i < AllResult.Count; i++)
                {
                    Result.Text += AllResult[i];
                    Result.Text += Environment.NewLine;
                }
            }
            else
            {
                for (int i = 0; i < tekrari.Count; i++)
                {
                    Result.Text += AllResult[tekrari[i]];
                    Result.Text += Environment.NewLine;
                }
            }
            QueryNum = new List<string>();
        }

        public List<string> QueryNum = new List<string>();
        private void Checkbox_Checked(object sender, RoutedEventArgs e)
        { 
            QueryNum.Add(((CheckBox)sender).Name);
        }
    }
}
