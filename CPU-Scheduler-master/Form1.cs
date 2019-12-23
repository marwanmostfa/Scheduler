using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CPU_Scheduler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        Rectangle r;
        bool Clicked = false;

        void Sorting_Arrival(List<double> arrival, List<double> burst, List<int> priority, List<int> process, int rows, int n)
        {
            for (int i = n; i < rows; i++)
            {


                for (int j = i + 1; j < rows; j++)
                {
                    if (arrival[j] < arrival[i] || (process[j] < process[i] && arrival[j] == arrival[i]))
                    {
                        double temp = arrival[i];
                        arrival[i] = arrival[j];
                        arrival[j] = temp;

                        double temp2 = burst[i];
                        burst[i] = burst[j];
                        burst[j] = temp2;

                        int temp3 = process[i];
                        process[i] = process[j];
                        process[j] = temp3;

                        int temp4 = priority[i];
                        priority[i] = priority[j];
                        priority[j] = temp4;


                    }

                }
            }
        }

        void Sorting_Burst(List<double> arrival, List<double> burst, List<int> process, int rows, int n)
        {

            for (int i = n; i < rows; i++)
            {


                for (int j = i + 1; j < rows; j++)
                {
                    if (arrival[j] == arrival[i] && burst[j] < burst[i])
                    {

                        double temp2 = burst[i];
                        burst[i] = burst[j];
                        burst[j] = temp2;

                        int temp3 = process[i];
                        process[i] = process[j];
                        process[j] = temp3;


                    }

                }
            }

        }
        void Sorting_Priority(List<double> arrival, List<double> burst, List<int> priority, List<int> process, int rows, int n)
        {

            for (int i = n; i < rows; i++)
            {


                for (int j = i + 1; j < rows; j++)
                {
                    if (arrival[j] == arrival[i] && priority[j] < priority[i])
                    {

                        double temp2 = burst[i];
                        burst[i] = burst[j];
                        burst[j] = temp2;

                        int temp3 = process[i];
                        process[i] = process[j];
                        process[j] = temp3;

                        int temp4 = priority[i];
                        priority[i] = priority[j];
                        priority[j] = temp4;
                    }

                }
            }

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Clicked = true;
            int rows = 0;
            if (algrothim.Text == "")
            {
                MessageBox.Show("You must Choose a Scheduling Algrothim");
            }
            else if (num.Text == "" || num.Text == "Write a Number (Ex. 5)")
            {
                MessageBox.Show("You must Enter the number of Processes");
            }
            else if (!int.TryParse(num.Text, out rows) || Convert.ToInt32(num.Text) <= 0)
            {

                MessageBox.Show("You must Enter a valid number of Processes");
            }
            else
            {
                rows = Convert.ToInt32(num.Text);
                dataGridView1.RowCount = rows;
                for (int i = 0; i < rows; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = "P" + (i + 1).ToString();
                }

            }

        }

        private void algrothim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (algrothim.Text == "Round Robin")
                TimeQauntum.Enabled = true;
            else
            {
                TimeQauntum.Text = null;
                TimeQauntum.Enabled = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clear_Click(object sender, EventArgs e)
        {
            Clicked = false;
            algrothim.Text = null;
            num.Text = "";
            dataGridView1.RowCount = 0;
            dataGridView1.ColumnCount = 3;
            dataGridView1.Width = 344;
            num.ForeColor = Color.Gray;
            num.Text = "Write a Number (Ex. 5)";

        }

        private void schedule_Click(object sender, EventArgs e)
        {
            if (!Clicked)
            {
                MessageBox.Show("You must generate Table first");
            }
            else
            {
                int rows = dataGridView1.RowCount;
                int checked1 = rows, checked2 = rows, checked3 = rows;
                List<double> arrival = new List<double>();
                List<double> NewArrival = new List<double>();
                List<double> burst = new List<double>();
                List<double> reman_burst = new List<double>();
                List<double> store = new List<double>();
                List<int> priority = new List<int>();
                List<int> process = new List<int>();
                List<int> counter = new List<int>();

                double parsed;

                chart c = new chart();

                for (int i = 0; i < rows; i++)
                    priority.Add(0);


                for (int i = 0; i < rows; i++)
                {
                    string ArrTime = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                    if (ArrTime == "")
                        MessageBox.Show("Please Enter an arrival time in process P" + (i + 1).ToString());
                    else if (!double.TryParse(ArrTime, out parsed) || Convert.ToDouble(ArrTime) < 0)
                        MessageBox.Show("Please Enter a valid number of arrival time in process P" + (i + 1).ToString());
                    else
                    {
                        arrival.Add(Convert.ToDouble(ArrTime));
                        NewArrival.Add(Convert.ToDouble(ArrTime));
                        process.Add(i + 1);
                        checked1--;
                    }

                }

                for (int i = 0; i < rows; i++)
                {
                    string BurTime = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    if (BurTime == "")
                        MessageBox.Show("Please Enter a burst time in process P" + (i + 1).ToString());
                    else if (!double.TryParse(BurTime, out parsed) || Convert.ToDouble(BurTime) < 0)
                        MessageBox.Show("Please Enter a valid number of burst time in process P" + (i + 1).ToString());
                    else
                    {
                        burst.Add(Convert.ToDouble(BurTime));
                        reman_burst.Add(Convert.ToDouble(BurTime));
                        checked2--;
                    }

                }
                if (dataGridView1.ColumnCount == 4)
                {

                    int parsed2;
                    for (int i = 0; i < rows; i++)
                    {
                        string Prio = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                        if (Prio == "")
                            MessageBox.Show("Please Enter the number of priority in process P" + (i + 1).ToString());
                        else if (!int.TryParse(Prio, out parsed2) || Convert.ToInt32(Prio) < 0)
                            MessageBox.Show("Please Enter a valid number of priority in process P" + (i + 1).ToString());
                        else
                        {
                            priority[i] = Convert.ToInt32(Prio);
                            checked3--;
                        }
                    }
                }

                /* FCFS Implenetation */
                if (algrothim.Text == "FCFS" && checked1 == 0 && checked2 == 0)
                {

                    int x = 20, y = 20, n = 0;
                    double increment = 0, AvgTime = 0,TurnAround=0;

                    if (rows > 5)
                    { c.Width += 55 * (rows - 5); }

                    c.Show();
                    g = c.CreateGraphics();
                    g.DrawString("Avg. Waiting Time = ", new Font("Arial", 9), Brushes.Black, new Point(x, y + 100));
                    g.DrawString("Avg. TurnAround Time = ", new Font("Arial", 9), Brushes.Black, new Point(x, y + 130));

                    Sorting_Arrival(arrival, burst, priority, process, rows, n);
                    increment = arrival[0];

                    for (int i = 0; i < rows; i++)
                    {
                  
                        r = new Rectangle(x, y, 50, 50);
                        g.DrawRectangle(new Pen(Brushes.Blue, 3), r);
                        g.DrawString('P' + process[i].ToString(), new Font("Arial", 12), Brushes.Black, new Point(x + 12, y + 15));
                        g.DrawString((burst[i] + increment).ToString(), new Font("Arial", 9), Brushes.Black, new Point(x + 45, y + 55));
                        increment += burst[i];
                        x += 50;

                        TurnAround += (increment - arrival[i]);
                        if (i < rows - 1)
                            AvgTime += (increment - arrival[i + 1]);


                    }
                    AvgTime /= rows;
                    TurnAround /= rows;
                    g.DrawString(AvgTime.ToString() + " s", new Font("Arial", 9), Brushes.Black, new Point(135, y + 100));
                    g.DrawString(TurnAround.ToString() + " s", new Font("Arial", 9), Brushes.Black, new Point(155, y + 130));
                }

                  /* SJF(NP) Implenetation */
                else if (algrothim.Text == "SJF (NP)" && checked1 == 0 && checked2 == 0)
                {
                    int x = 20, y = 20;
                    double increment = 0, AvgTime = 0, waiting, burst2,TurnAround = 0;
                    int check = 0, n = 0;

                    if (rows > 5)
                    { c.Width += 55 * (rows - 5); }

                    c.Show();
                    g = c.CreateGraphics();
                    g.DrawString("Avg. Waiting Time = ", new Font("Arial", 9), Brushes.Black, new Point(x, y + 100));
                    g.DrawString("Avg. TurnAround Time = ", new Font("Arial", 9), Brushes.Black, new Point(x, y + 130));




                    Sorting_Arrival(arrival, burst, priority, process, rows, n);
                    Sorting_Burst(arrival, burst, process, rows, n);
                    increment = arrival[0];
                    waiting = burst[0]; burst2 = burst[0];
                    for (int i = 0; i < rows; i++)
                    {
                        check = 0;
                        if (i >= 1 || (rows > 1 && arrival[i] == arrival[i + 1]))
                        {
                            if (i < rows - 1)
                                if (arrival[i] == arrival[i + 1])
                                    check = 1;

                            burst2 = burst[i];
                            for (int j = i + 1; j < rows; j++)
                            {
                                if ((arrival[j] <= increment && burst[j] < burst2) || (process[i] > process[j] && burst[j] == burst[i]))
                                {
                                    if (arrival[j] != arrival[i]) check = 0;

                                    if (check == 0 || (check == 1 && arrival[j] == arrival[i]))
                                    {
                                        // (arrival[j] <= increment)
                                        burst2 = burst[j];

                                        int temp3 = process[i];
                                        process[i] = process[j];
                                        process[j] = temp3;

                                        double temp2 = burst[i];
                                        burst[i] = burst[j];
                                        burst[j] = temp2;


                                        double temp = arrival[i];
                                        arrival[i] = arrival[j];
                                        arrival[j] = temp;
                                    }

                                }
                            }
                            waiting += burst[i];

                        }
                        
                        if (i < rows && i > 0)
                        {
                            // MessageBox.Show((increment - arrival[i]).ToString());
                            AvgTime += (increment - arrival[i]);
                        }
                        r = new Rectangle(x, y, 50, 50);
                        g.DrawRectangle(new Pen(Brushes.Blue, 3), r);
                        g.DrawString('P' + process[i].ToString(), new Font("Arial", 12), Brushes.Black, new Point(x + 12, y + 15));
                        g.DrawString((burst[i] + increment).ToString(), new Font("Arial", 9), Brushes.Black, new Point(x + 45, y + 55));
                        increment += burst[i];
                        x += 50;

                        TurnAround += (increment - arrival[i]);



                    }
                    AvgTime /= rows;
                    TurnAround /= rows;
                    g.DrawString(AvgTime.ToString() + " s", new Font("Arial", 9), Brushes.Black, new Point(135, y + 100));
                    g.DrawString(TurnAround.ToString() + " s", new Font("Arial", 9), Brushes.Black, new Point(155, y + 130));


                }
                /* Priority (NP) */
                else if (algrothim.Text == "Priority (NP)" && checked1 == 0 && checked2 == 0 && checked3 == 0)
                {
                    int x = 20, y = 20, n = 0;
                    double increment = 0, AvgTime = 0, waiting, priority2,TurnAround = 0;
                    int check = 0;

                    if (rows > 5)
                    { c.Width += 55 * (rows - 5); }

                    c.Show();
                    g = c.CreateGraphics();
                    g.DrawString("Avg. Waiting Time = ", new Font("Arial", 9), Brushes.Black, new Point(x, y + 100));
                    g.DrawString("Avg. TurnAround Time = ", new Font("Arial", 9), Brushes.Black, new Point(x, y + 130));

                    Sorting_Arrival(arrival, burst, priority, process, rows, n);
                    Sorting_Priority(arrival, burst, priority, process, rows, n);
                    increment = arrival[0];
                    waiting = priority[0]; priority2 = priority[0];
                    for (int i = 0; i < rows; i++)
                    {
                        check = 0;
                        if (i >= 1 || (rows > 1 && arrival[i] == arrival[i + 1]))
                        {
                            if (i < rows - 1)
                                if (arrival[i] == arrival[i + 1])
                                    check = 1;

                            priority2 = priority[i];
                            for (int j = i + 1; j < rows; j++)
                            {
                                if ((arrival[j] <= increment && priority[j] < priority2) || (process[i] > process[j] && priority[j] == priority[i]))
                                {
                                    if (arrival[j] != arrival[i]) check = 0;

                                    if (check == 0 || (check == 1 && arrival[j] == arrival[i]))
                                    {
                                        priority2 = priority[j];

                                        int temp3 = process[i];
                                        process[i] = process[j];
                                        process[j] = temp3;

                                        double temp2 = burst[i];
                                        burst[i] = burst[j];
                                        burst[j] = temp2;

                                        int temp4 = priority[i];
                                        priority[i] = priority[j];
                                        priority[j] = temp4;

                                        double temp1 = arrival[i];
                                        arrival[i] = arrival[j];
                                        arrival[j] = temp1;
                                    }


                                }
                            }
                            waiting += priority[i];

                        }
                        if (i < rows && i > 0)
                        {
                            // MessageBox.Show((increment - arrival[i]).ToString());
                            AvgTime += (increment - arrival[i]);
                        }
                        r = new Rectangle(x, y, 50, 50);
                        g.DrawRectangle(new Pen(Brushes.Blue, 3), r);
                        g.DrawString('P' + process[i].ToString(), new Font("Arial", 12), Brushes.Black, new Point(x + 12, y + 15));
                        g.DrawString((burst[i] + increment).ToString(), new Font("Arial", 9), Brushes.Black, new Point(x + 45, y + 55));
                        increment += burst[i];
                        x += 50;

                        TurnAround += (increment - arrival[i]);

                    }
                    AvgTime /= rows;
                    TurnAround /= rows;

                    g.DrawString(AvgTime.ToString() + " s", new Font("Arial", 9), Brushes.Black, new Point(135, y + 100));
                    g.DrawString(TurnAround.ToString() + " s", new Font("Arial", 9), Brushes.Black, new Point(155, y + 130));

                }
                /* SJF (P) Implenetation */
                else if (algrothim.Text == "SJF (P)" && checked1 == 0 && checked2 == 0)
                {
                    int x = 20, y = 20;
                    double increment = 0, AvgTime = 0, burst2,TurnAround = 0;
                    double remain = 0, arrival2 = 0, arrival3 = 0;
                    int inn = 0, check = 0, n = 0, check2 = 0;
                    int rows2 = dataGridView1.RowCount;

                    if (rows > 5)
                    { c.Width += 55 * (rows - 5); }


                    Sorting_Arrival(arrival, burst, priority, process, rows, n);
                    Sorting_Burst(arrival, burst, process, rows, n);
                    increment = arrival[0];
                    burst2 = burst[0];
                    for (int i = 0; i < rows; i++)
                    {

                        if (arrival[i] > increment)
                        {
                            n = i;
                            Sorting_Arrival(arrival, burst, priority, process, rows, n);
                            Sorting_Burst(arrival, burst, process, rows, n);
                        }
                        check = 0;

                        if (i < rows - 1)
                            if (arrival[i] == arrival[i + 1])
                                check = 1;

                        inn = 0;
                        burst2 = burst[i];
                        //if(inn==0)
                        for (int j = i + 1; j < rows; j++)
                        {
                            if (arrival[j] < burst[i] + increment && burst[j] < burst2 || (process[i] > process[j] && burst[j] == burst[i]))
                            {
                                if (arrival[j] != arrival[i]) check = 0;
                                if (check == 0 || (check == 1 && arrival[j] == arrival[i]))
                                {
                                    burst2 = burst[j];

                                    if ((arrival[j] - arrival[i]) <= burst[i] && burst[j] < Math.Abs((burst[i] - Math.Abs(arrival[j] - increment))) && (arrival[j] - arrival[i]) >= 0 && !(arrival[j] <= increment))
                                    {
                                        inn = 1;
                                        remain = burst[i] - (arrival[j] - increment);
                                        arrival2 = arrival[j] - increment;
                                        arrival3 = arrival[j] - (increment - arrival[i]);
                                        break;

                                    }


                                    else if (arrival[j] <= increment)
                                    {

                                        int temp3 = process[i];
                                        process[i] = process[j];
                                        process[j] = temp3;

                                        double temp2 = burst[i];
                                        burst[i] = burst[j];
                                        burst[j] = temp2;

                                        double temp1 = arrival[i];
                                        arrival[i] = arrival[j];
                                        arrival[j] = temp1;


                                    }

                                }


                            }
                        }

                        if (inn == 1)
                        {

                            rows++;
                            process.Add(process[i]);
                            store.Add(process[i]);
                            burst.Add(remain);
                            counter.Add(i);
                            priority.Add(0);
                            NewArrival.Add(NewArrival[i]);
                            arrival.Add(arrival3);
                            burst[i] = arrival2;
                            c.Width += 55;


                        }
                        increment += burst[i];
                    }
                    int flag = 0;
                    c.Show();
                    g = c.CreateGraphics();
                    g.DrawString("Avg. Waiting Time = ", new Font("Arial", 9), Brushes.Black, new Point(x, y + 100));
                    g.DrawString("Avg. TurnAround Time = ", new Font("Arial", 9), Brushes.Black, new Point(x, y + 130));

                    increment = 0;
                    for (int i = 0; i < rows; i++)
                    {
                        //  MessageBox.Show((arrival[i]).ToString());
                        flag = 0;
                        r = new Rectangle(x, y, 50, 50);
                        g.DrawRectangle(new Pen(Brushes.Blue, 3), r);
                        g.DrawString('P' + process[i].ToString(), new Font("Arial", 12), Brushes.Black, new Point(x + 12, y + 15));
                        g.DrawString((burst[i] + increment).ToString(), new Font("Arial", 9), Brushes.Black, new Point(x + 45, y + 55));
                        increment += burst[i];
                        x += 50;
                        check2 = 0;
                        for (int j = i + 1; j < rows; j++)
                        {
                            if (process[i] == process[j])
                            { flag = 1; break; }

                        }
                            for (int j = 0; j < store.Count; j++)
                            {
                                if (process[i] == store[j] && check2 == 0 && i <= counter[j]) { check2 = 1; break; }
                            }
                        if ((i < rows - 1 && i > 0 && check2 == 0) || (i == 0 && rows2 > 1 && arrival[i] == arrival[i + 1]))
                        {
                            //MessageBox.Show((increment - arrival[i+1]).ToString());
                            AvgTime += (increment - arrival[i + 1]);
                        }

                        if (flag == 0)
                        {
                            TurnAround += (increment - NewArrival[i]);
                        }


                    }

                    AvgTime /= rows2;
                    TurnAround /= rows2;
                    g.DrawString(AvgTime.ToString() + " s", new Font("Arial", 9), Brushes.Black, new Point(135, y + 100));
                    g.DrawString(TurnAround.ToString() + " s", new Font("Arial", 9), Brushes.Black, new Point(155, y + 130));

                }
                /* Priority (P) Implenetation*/
                else if (algrothim.Text == "Priority (P)" && checked1 == 0 && checked2 == 0 && checked3 == 0)
                {
                    int x = 20, y = 20;
                    double increment = 0, AvgTime = 0, TurnAround=0;
                    int priority2;
                    double remain = 0, arrival2 = 0, arrival3 = 0;
                    int inn = 0, check = 0, n = 0, check2 = 0;
                    int rows2 = dataGridView1.RowCount;

                    if (rows > 5)
                    { c.Width += 55 * (rows - 5); }



                    Sorting_Arrival(arrival, burst, priority, process, rows, n);
                    Sorting_Priority(arrival, burst, priority, process, rows, n);
                    increment = arrival[0];
                    priority2 = priority[0];
                    for (int i = 0; i < rows; i++)
                    {


                        if (arrival[i] > increment)
                        {
                            n = i;
                            Sorting_Arrival(arrival, burst, priority, process, rows, n);
                            Sorting_Priority(arrival, burst, priority, process, rows, n);
                        }
                        check = 0;

                        if (i < rows - 1)
                            if (arrival[i] == arrival[i + 1])
                                check = 1;

                        inn = 0;
                        priority2 = priority[i];

                        for (int j = i + 1; j < rows; j++)
                        {
                            if (arrival[j] < burst[i] + increment && priority[j] < priority2 || (process[i] > process[j] && priority[j] == priority[i]))
                            {
                                if (arrival[j] != arrival[i]) check = 0;
                                if (check == 0 || (check == 1 && arrival[j] == arrival[i]))
                                {

                                    priority2 = priority[j];


                                    if (arrival[j] > increment)
                                    {
                                        inn = 1;
                                        remain = burst[i] - (arrival[j] - increment);
                                        arrival2 = arrival[j] - increment;
                                        arrival3 = arrival[j] - (increment - arrival[i]);
                                        break;
                                    }


                                    else if (arrival[j] <= increment)
                                    {

                                        int temp3 = process[i];
                                        process[i] = process[j];
                                        process[j] = temp3;

                                        double temp2 = burst[i];
                                        burst[i] = burst[j];
                                        burst[j] = temp2;

                                        int temp1 = priority[i];
                                        priority[i] = priority[j];
                                        priority[j] = temp1;

                                        double temp4 = arrival[i];
                                        arrival[i] = arrival[j];
                                        arrival[j] = temp4;



                                    }

                                }


                            }
                        }

                        if (inn == 1)
                        {

                            rows++;
                            process.Add(process[i]);
                            store.Add(process[i]);
                            priority.Add(priority[i]);
                            burst.Add(remain);
                            counter.Add(i);
                            NewArrival.Add(NewArrival[i]);
                            arrival.Add(arrival3);
                            burst[i] = arrival2;
                            c.Width += 55;

                        }
                        increment += burst[i];
                    }
                    c.Show();
                    g = c.CreateGraphics();
                    g.DrawString("Avg. Waiting Time = ", new Font("Arial", 9), Brushes.Black, new Point(x, y + 100));
                    g.DrawString("Avg. TurnAround Time = ", new Font("Arial", 9), Brushes.Black, new Point(x, y + 130));
                    int flag = 0;
                    increment = 0;
                    for (int i = 0; i < rows; i++)
                    {
                        flag = 0;
                        r = new Rectangle(x, y, 50, 50);
                        g.DrawRectangle(new Pen(Brushes.Blue, 3), r);
                        g.DrawString('P' + process[i].ToString(), new Font("Arial", 12), Brushes.Black, new Point(x + 12, y + 15));
                        g.DrawString((burst[i] + increment).ToString(), new Font("Arial", 9), Brushes.Black, new Point(x + 45, y + 55));
                        increment += burst[i];
                        x += 50;
                        check2 = 0;
                        for (int j = i + 1; j < rows; j++)
                        {
                            if (process[i] == process[j])
                            { flag = 1; break; }

                        }
                        for (int j = 0; j < store.Count; j++)
                        {
                            if (process[i] == store[j] && check2 == 0 && i <= counter[j]) { check2 = 1; break; }
                        }
                        if ((i < rows - 1 && i > 0 && check2 == 0) || (i == 0 && rows2 > 1 && arrival[i] == arrival[i + 1]))
                        {
                            //MessageBox.Show((increment - arrival[i+1]).ToString());
                            AvgTime += (increment - arrival[i + 1]);
                        }

                        if(flag==0)
                            TurnAround += (increment - arrival[i]);

                    }

                    AvgTime /= rows2;
                    TurnAround /= rows2;
                    g.DrawString(AvgTime.ToString() + " s", new Font("Arial", 9), Brushes.Black, new Point(135, y + 100));
                    g.DrawString(TurnAround.ToString() + " s", new Font("Arial", 9), Brushes.Black, new Point(155, y + 130));


                }
                /* Round Robin Implenetation */
                else if (algrothim.Text == "Round Robin" && checked1 == 0 && checked2 == 0)
                {
                    double parsed3;
                    double Time;
                    if (TimeQauntum.Text == "")
                    {
                        MessageBox.Show("You must Enter a Time Quantum");
                    }
                    else if (!double.TryParse(TimeQauntum.Text, out parsed3) || Convert.ToDouble(TimeQauntum.Text) <= 0)
                    {

                        MessageBox.Show("You must Enter a valid number of Time Quantum");
                    }
                    else
                    {
                        Time = Convert.ToDouble(TimeQauntum.Text);


                        int x = 20, y = 20;
                        double increment = 0, AvgTime = 0, inc2 = 0, TurnAround = 0;
                        int n = 0;
                        int rows2 = dataGridView1.RowCount;
                        List<double> wait_time = new List<double>();
                        
                        //  reman_burst = burst;

                        if (rows > 5)
                        { c.Width += 55 * (rows - 5); }

                        Sorting_Arrival(arrival, burst, priority, process, rows, n);
                        increment = arrival[0];
                        inc2 = arrival[0];


                        for (int i = 0; i < rows; i++)
                        {
                            if (arrival[i] > inc2)
                                Sorting_Arrival(arrival, burst, priority, process, rows, n);

                            if (burst[i] > Time)
                            {
                                rows++;
                                process.Add(process[i]);
                                priority.Add(0);
                                burst.Add(burst[i] - Time);
                                reman_burst.Add(reman_burst[i]);
                                arrival.Add(arrival[i]);
                                burst[i] = Time;
                                c.Width += 55;
                                inc2 += burst[i];

                            }
                            //else if(process[i]!=process[i+1])
                            else
                            {
                                inc2 += burst[i];
                                wait_time.Add(inc2 - reman_burst[i] - arrival[i]);

                            }

                        }

                        for (int i = 0; i < rows2; i++)
                        {
                            AvgTime += wait_time[i];
                        }

                        c.Show();
                        g = c.CreateGraphics();
                        g.DrawString("Avg. Waiting Time = ", new Font("Arial", 9), Brushes.Black, new Point(x, y + 100));
                        g.DrawString("Avg. TurnAround Time = ", new Font("Arial", 9), Brushes.Black, new Point(x, y + 130));
                        int flag = 0;
                        for (int i = 0; i < rows; i++)
                        {
                            flag=0;
                            r = new Rectangle(x, y, 50, 50);
                            g.DrawRectangle(new Pen(Brushes.Blue, 3), r);
                            g.DrawString('P' + process[i].ToString(), new Font("Arial", 12), Brushes.Black, new Point(x + 12, y + 15));
                            g.DrawString((burst[i] + increment).ToString(), new Font("Arial", 9), Brushes.Black, new Point(x + 45, y + 55));
                            increment += burst[i];
                            x += 50;
                            for (int j = i + 1; j < rows; j++)
                            {
                                if (process[i] == process[j])
                                { flag = 1; break; }

                            }

                            if (flag == 0)
                                TurnAround += increment - arrival[i];

                        }

                        AvgTime /= rows2;
                        TurnAround /= rows2;

                        g.DrawString(AvgTime.ToString() + " s", new Font("Arial", 9), Brushes.Black, new Point(135, y + 100));
                        g.DrawString(TurnAround.ToString() + " s", new Font("Arial", 9), Brushes.Black, new Point(155, y + 130));
                    }
                }


            }
        }


        private void num_Enter(object sender, EventArgs e)
        {
            if (num.Text == "Write a Number (Ex. 5)")
            {
                num.ForeColor = Color.Black;
                num.Text = "";
            }
        }

        private void num_Leave(object sender, EventArgs e)
        {
            if (num.Text.Length == 0)
            {
                num.ForeColor = Color.Gray;
                num.Text = "Write a Number (Ex. 5)";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        private void TimeQauntum_TextChanged(object sender, EventArgs e)
        {

        }

        private void num_TextChanged(object sender, EventArgs e)
        {

        }

        private void algrothim_SelectedValueChanged(object sender, EventArgs e)
        {
            if (algrothim.Text == "Priority (NP)" || algrothim.Text == "Priority (P)")
            {

                dataGridView1.ColumnCount = 4;
                dataGridView1.Columns[3].HeaderText = "Priority";
                dataGridView1.Width = 443;
            }

            else
            {
                dataGridView1.ColumnCount = 3;
                dataGridView1.Width = 343;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tips t = new Tips();
            t.Show();
        }


    }
}