using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
namespace WindowsFormsApplication13
{
    public partial class TaskManager : Form
    {
        //DLL FILE FOR LOG OFF , SHUTDOWN , RESTART
        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int operationFlag, int operationReason);
        Process[] Getprocessess;
        public TaskManager()
        {
            InitializeComponent();
            GetProcessTable();
            timer2.Start();
            GetUserTable();
            GetRunningApplications();
           // timer3.Start();
            HardwareInformation();

        }

        private void HardwareInformation()
        {
            ManagementObjectSearcher obj = new ManagementObjectSearcher("select * from Win32_BIOS");

            foreach (ManagementObject x in obj.Get())
            {

           
             label4.Text = ""+x["Name"].ToString();
             label7.Text = "" + x["Version"].ToString();

             label8.Text = "" + x["Status"].ToString();
             label9.Text = "" + x["Manufacturer"].ToString();
              label14.Text = ""+x["PrimaryBIOS"];
              label16.Text = "" + x["SerialNumber"];

              label18.Text = "" + x["CurrentLanguage".ToString()];
            }
            label6.Text = "Name:";
            label5.Text = "BIOS Information";
            label10.Text = "Version";
            label11.Text = "Status";
            label12.Text = "Company"; 
            label13.Text = "PrimaryBIOS";
            label15.Text = "Serial Number";
            label17.Text = "Language";
            //string OtherTargetOS;
            ManagementObjectSearcher obj1 = new ManagementObjectSearcher("select * from Win32_DiskDrive");

            foreach (ManagementObject x in obj1.Get())
            {

            //    MessageBox.Show(x["Description"].ToString());
                label32.Text = "" + x["Description"].ToString();
                label30.Text = "" + x["Size"].ToString()+" bytes";

                label29.Text = "" + x["SerialNumber"].ToString();
                label28.Text = "" + x["TotalCylinders"].ToString();
                label23.Text = "" + x["SystemName"];
                label21.Text = "" + x["TracksPerCylinder"].ToString();

                label19.Text = "" + x["Partitions".ToString()];
            }
            label31.Text = "Name ";
           label27.Text = "Size ";
            label26.Text = "Serial ";
           label25.Text = "Total Cylinders ";
           label24.Text = "System Name";
            label22.Text = "Tracks/Cylinder ";
            label20.Text = "Drive Partitions";
         //   label17.Text = "Language";
            //string OtherTargetOS;


            ManagementObjectSearcher obj2 = new ManagementObjectSearcher("select * from Win32_Processor");

            foreach (ManagementObject x in obj2.Get())
            {


                label47.Text = "" + x["Name"].ToString();
                  label45.Text = "" + x["NumberOfCores"].ToString();

                  label44.Text = "" + Convert.ToInt32(x["L2CacheSize"])+" Bytes";
                  label43.Text = "" + x["L3CacheSize"].ToString();
                  label38.Text = "" + x["Caption"].ToString();
                  label36.Text = "" + x["Manufacturer"].ToString();

                  label34.Text = "" + x["MaxClockSpeed".ToString()];/* */
            }
            label46.Text = "Processor: ";
           label42.Text = "Number of Cores ";
            label41.Text = "L2 Cache Size ";
            label40.Text = "L3 Cache Size ";
                label39.Text = "Caption ";
             label37.Text = "Company ";
                        label35.Text = "Max Clock Speed ";
            /*       label17.Text = "Language";*/

                        ManagementObjectSearcher obj3 = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

                        foreach (ManagementObject x in obj3.Get())
                        {


                            label62.Text = "" + x["Name"].ToString();
                            label60.Text = "" + x["TotalVirtualMemorySize"].ToString();
                            
                                                                                       label59.Text = "" + Convert.ToInt32(x["FreePhysicalMemory"]);
                                                                                       label58.Text = "" + x["NumberOfUsers"].ToString();
                                                                                       label53.Text = "" + x["Version"].ToString();
                                                                                       label51.Text = "" + x["WindowsDirectory"].ToString();

                                                                                       label49.Text = "" + x["SerialNumber".ToString()];                             /*  */
                        }
                label61.Text = "Operating System: ";
           label57.Text = "Company ";
            label56.Text = "Free Physical Memory ";
           label55.Text = "No of User Accounts ";

            label54.Text = "Version ";
                    label52.Text = "Windows Directory ";
                              label50.Text = "Serial # ";        
            /*  */

                              ManagementObjectSearcher obj4 = new ManagementObjectSearcher("select * from Win32_VideoController ");

                              foreach (ManagementObject x in obj4.Get())
                              {


    label77.Text = "" + x["Name"].ToString();
    label75.Text = "" + ((Convert.ToInt32(x["AdapterRAM"])) / 1048576 +" MByte");

    label74.Text = "" + x["AdapterCompatibility"].ToString();
                                                                              label73.Text = "" + x["DriverVersion"].ToString();
                                                                                  label68.Text = "" + x["InstalledDisplayDrivers"].ToString();
                                                                                  label66.Text = "" +x["Status"].ToString();

                                                                                                 /*                        label64.Text = "" + x["SerialNumber".ToString()];                             */

                              }
           label76.Text = "Video Card  ";
            label72.Text = "Size ";
            label71.Text = "Adapter Compatibility";
                             label70.Text = "Driver Version ";

                            label69.Text = "Installed Display Driver ";
                     label67.Text = "Status ";
            /*         label65.Text = "Serial # ";         */ 
        }
    

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GetUserTable()
        {
            listView2.Items.Clear();
            ListViewItem lvl = null;
            ManagementObjectSearcher obj = new ManagementObjectSearcher("select * from Win32_UserAccount");

            foreach (ManagementObject x in obj.Get())
            {

                lvl = new ListViewItem(x["name"].ToString());
                //MessageBox.Show(""+lvl);
                lvl.SubItems.Add(x["SID"].ToString());
                lvl.SubItems.Add(x["Status"].ToString());
                listView2.Items.Add(lvl);
            }

       
        }

        private void GetProcessTable()
        {
            listView1.Items.Clear();
            ListViewItem lvl = null;
            ManagementObjectSearcher obj = new ManagementObjectSearcher("select * from Win32_Process");

            foreach (ManagementObject x in obj.Get())
            {

                lvl = new ListViewItem(x["ProcessId"].ToString());
                lvl.SubItems.Add(x["Name"].ToString());
                lvl.SubItems.Add(x["ThreadCount"].ToString());
                listView1.Items.Add(lvl);
            }

            ManagementObjectSearcher obj1 = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");

            foreach (ManagementObject x in obj1.Get())
            {
                lvl.SubItems.Add(x["PercentProcessorTime"].ToString());

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            GetProcessTable();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true && checkBox1.Checked == true)
            {
                timer1.Stop();
                timer1.Interval = 10000;
                timer1.Start();
            }

            else if (radioButton2.Checked == true && checkBox1.Checked == true)
            {
                timer1.Stop();
                timer1.Interval = 5000;
                timer1.Start();
            }

            else if (radioButton3.Checked == true && checkBox1.Checked == true)
            {
                timer1.Stop();
                timer1.Interval = 3000;
                timer1.Start();
            }
            if (checkBox1.Checked == true)
            {
                if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true)
                    timer1.Start();
                else
                    MessageBox.Show("Please Select Time Below", "Note");
            }

            else if (checkBox1.Checked == false)
            {
                timer1.Stop();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String a = listView1.SelectedItems[0].Text;
            Process p = Process.GetProcessById(Convert.ToInt32(a));

            p.Kill();
            MessageBox.Show("" + a);
            GetProcessTable();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            GetProcessTable();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            {
                double x=0;
                try { 
                PerformanceCounter memory = new PerformanceCounter("Memory", "Available Mbytes");
                int AvailableMemory = Convert.ToInt32(memory.NextValue());
                int UsedMemory;
                ManagementObjectSearcher obj1 = new ManagementObjectSearcher("select * from Win32_ComputerSystem");
                foreach (ManagementObject y in obj1.Get())
                {
                        x = double.Parse(y["TotalPhysicalMemory"].ToString());
                    progressBar1.Maximum =(int) (x / 1048576);
                    UsedMemory = (int)(x / 1048576) - AvailableMemory;
                    label1.Text = UsedMemory + "/" +(int) (x / 1048576) + " MBytes";
                    progressBar1.Value = UsedMemory;
                    if (UsedMemory >= (x / 1048576) * 0.75)
                        {
                          //  progressBar1.ForeColor = Color.Red;
                          //  progressBar1.BackColor = Color.FromArgb(217, 83, 79);

                        }
                    else
                    {
                       // progressBar1.ForeColor = Color.FromArgb(50, 205, 50);
                    }

                    chart1.Series["Series1"].Points.AddXY(0, UsedMemory);

                }

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message+" "+ x);
                }
                progressBar1.Minimum = 0;

         //       PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
              
                progressBar2.Maximum = 100;
                progressBar2.Minimum = 0;
                String s2=null;
                int u=0;
                ManagementClass mc = new ManagementClass("Win32_PerfFormattedData_PerfOS_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject item in moc)
                {
                   u=Convert.ToInt16(Math.Round(Convert.ToDouble(item.Properties["PercentProcessorTime"].Value)));

                }
                progressBar2.Value = u;
                label65.Text = ""+u+"%";
                chart2.Series["Series1"].Points.AddXY(0, u);
                progressBar2.ForeColor = Color.FromArgb(50, 205, 50);

             //   progressBar2.Value = u;
           //     cpuCounter.NextValue();
             //    System.Threading.Thread.Sleep(5000);
            }

        }
        ///////////////////////////////////
        //0 : LOG OFF
        // 1: Shut Down
        // 2: Restart
        // 4: Force Log Off
     
        
        
        private void button2_Click(object sender, EventArgs e)
        {
            ExitWindowsEx(0, 1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ExitWindowsEx(0, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExitWindowsEx(0, 4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ExitWindowsEx(0, 2);
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

            String a = listView3.SelectedItems[0].Text;
            int saveID = 0;
            var processes = Process.GetProcesses().Where(p => !string.IsNullOrEmpty(p.MainWindowTitle)).ToList();
            foreach (var process in processes)
            {

                var id = process.Id;
                var Wintitle = process.MainWindowTitle;

                if (Wintitle.Equals(a))
                {
                    saveID = id;
                    break;
                }
                //    Console.WriteLine("title: {0}, id: {1}", Wintitle, id);
                //  MessageBox.Show("" + id+ " ...."+Wintitle );

                GetRunningApplications();

            }


            Process p1 = Process.GetProcessById(Convert.ToInt32(saveID));
            p1.Kill();
        }

        private void GetRunningApplications()
        {

            listView3.Items.Clear();
            Getprocessess = Process.GetProcesses();
            foreach (Process p in Getprocessess)
            {
                if (!String.IsNullOrEmpty(p.MainWindowTitle))
                {
                    listView3.Items.Add(p.MainWindowTitle);
                }
            }

          
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            GetRunningApplications();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            GetRunningApplications();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try { 
            Process newProcess = new Process();
            newProcess.StartInfo.FileName=textBox1.Text;
            newProcess.Start();
                }
            catch
            {
                MessageBox.Show("Invalid Task Name!");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick_1(object sender, EventArgs e)
        {
        //  MessageBox.Show(""+ new ManagementObjectSearcher("SELECT PercentProcessorTime FROM Win32_PerfFormattedData_PerfOS_Processor WHERE Name='_Total'").Get().Cast<ManagementObject>().First().Prope‌​rties["PercentProces‌​sorTime"].Value.ToSt‌​ring() .Properties["PercentProcessorTime"] .Value.ToString());
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
