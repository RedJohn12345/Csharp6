using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            object[] classes = new object[Program.subclasses.Count];

            for (int i = 0; i < classes.Length; i++)
            {
                classes[i] = Program.subclasses[i].Name;
            }
            this.comboBox1.Items.AddRange(classes);
        }

        private ITransport transport;
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();

            Type subclass = Program.subclasses.FirstOrDefault(t => t.Name == selectedState);
            Console.WriteLine(selectedState);

            if (subclass != null)
            {
                PublicTransport publicTransport = (PublicTransport)Activator.CreateInstance(subclass);
                this.transport = publicTransport;
                this.button1.Visible = true;
                this.label2.Visible = true;
                this.label2.Text = "Введите максимальную скорость";
                this.textBox1.Visible = true;

                if (transport is PublicTransport)
                {
                    this.label3.Visible = true;
                    this.textBox2.Visible = true;
                    this.label3.Text = "Введите вместимость";
                    this.label4.Visible = true;
                    this.textBox3.Visible = true;
                    this.label4.Text = "Введите количество остановок";
                    this.label5.Visible = true;
                    this.textBox4.Visible = true;
                    this.label5.Text = "Введите название компании";
                    this.label6.Visible = true;
                    this.textBox5.Visible = true;
                    this.label6.Text = "Введите количество пассажиров";

                    if (this.transport is Bus)
                    {
                        this.label7.Visible = true;
                        this.textBox6.Visible = true;
                        this.label7.Text = "Введите расход топлива";
                        this.label8.Visible = true;
                        this.textBox7.Visible = true;
                        this.label8.Text = "Введите номер автобуса";
                    }
                    else if (this.transport is Tram)
                    {
                        this.label7.Visible = true;
                        this.textBox6.Visible = true;
                        this.label7.Text = "Введите количество вагонов";
                        this.label8.Visible = true;
                        this.textBox7.Visible = true;
                        this.label8.Text = "Введите расход электричества";
                    }
                    else if (this.transport is Metro)
                    {
                        this.label7.Visible = true;
                        this.textBox6.Visible = true;
                        this.label7.Text = "Введите название ветки";
                        this.label8.Visible = true;
                        this.textBox7.Visible = true;
                        this.label8.Text = "Введите ширина колеи";
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.label9.Text = transport.Start();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            transport.MaxSpeed = Int32.Parse(textBox1.Text);
            this.label9.Visible = true;
            if (transport is PublicTransport)
            {
                PublicTransport publicTransport = transport as PublicTransport;
                publicTransport.Capacity = Int32.Parse(textBox2.Text);
                publicTransport.NumberOfStops = Int32.Parse(textBox3.Text);
                publicTransport.CompanyName = textBox4.Text;
                publicTransport.CountPassengers = Int32.Parse(textBox5.Text);
                this.button2.Visible = true;
                this.button3.Visible = true;
                this.button4.Visible = true;
                this.button5.Visible = true;
                this.button6.Visible = true;
                this.button8.Visible = true;
                this.textBox8.Visible = true;
                if (transport is Bus)
                {
                    this.button8.Text = "Посигналить";
                    Bus bus = transport as Bus;
                    bus.FielConsumption = Double.Parse(textBox6.Text, CultureInfo.InvariantCulture);
                    bus.Number = textBox7.Text;
                    this.button9.Visible = true;
                    this.button9.Text = "Припарковаться на стоянке";
                }
                else if (transport is Tram)
                {
                    this.button8.Text = "Позвонить";
                    this.button9.Visible = true;
                    this.button9.Text = "Остановиться в депо";
                    Tram tram = transport as Tram;
                    tram.ElectricityConsumption = Double.Parse(textBox7.Text, CultureInfo.InvariantCulture);
                    tram.NumberOfWagons = Int32.Parse(textBox6.Text);
                }
                else if (transport is Metro)
                {
                    this.button8.Text = "Погудеть";
                    this.button9.Visible = true;
                    this.button9.Text = "Остановиться на конечной станции";
                    Metro metro = transport as Metro;
                    metro.TrackWidth = Double.Parse(textBox7.Text, CultureInfo.InvariantCulture);
                    metro.BranchName = textBox6.Text;
                }
            }
                this.button7.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.label9.Text = transport.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PublicTransport publicTransport = transport as PublicTransport;

            this.label9.Text = publicTransport.MoveToNextStop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PublicTransport publicTransport = transport as PublicTransport;

            this.label9.Text = publicTransport.LoadPassengers(Int32.Parse(this.textBox8.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PublicTransport publicTransport = transport as PublicTransport;

            this.label9.Text = publicTransport.UnloadPassengers(Int32.Parse(this.textBox8.Text));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (transport is Tram)
            {
                Tram tram = transport as Tram;
                this.label9.Text = tram.RingTheBell();
            }
            else if (transport is Bus)
            {
                Bus bus = transport as Bus;
                this.label9.Text = bus.DoBeepBeep();
            }
            else if (transport is Metro)
            {
                Metro metro = transport as Metro;
                this.label9.Text = metro.DoHorn();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (transport is Tram)
            {
                Tram tram = transport as Tram;
                this.label9.Text = tram.StopAtTheDepot();
            }
            else if (transport is Bus)
            {
                Bus bus = transport as Bus;
                this.label9.Text = bus.Park();
            }
            else if (transport is Metro)
            {
                Metro metro = transport as Metro;
                this.label9.Text = metro.StopAtTerminalStation();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.label9.Text = transport.GetInfo();
        }

    }
}
