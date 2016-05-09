using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net.NetworkInformation;
namespace Optimism_for_Mental_Health
{
    public partial class hopthuoc : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public hopthuoc()
        {
            InitializeComponent();
        }

        private void hopthuoc_Load(object sender, EventArgs e)
        {
            txtOutput.Enabled = true;
            kryptonGroupBox2.Text = "Kết nối hộp thuốc";
            kryptonGroupBox1.Text = "Cập nhật";
            timer1.Start();
            SerialPort tmp;
            foreach (string str in SerialPort.GetPortNames())
            {
                tmp = new SerialPort(str);
                if (tmp.IsOpen == false)
                    port_combobox.Items.Add(str);
            }

        }
        private long[] point = new long[100];
        int point_length = -1;
        bool start = true;
        int root = 0;
        long thoihan= 600000000;
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if (this.txtOutput.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                //txtOutput.AppendText(text);
                txtOutput.Text = "";
                txtOutput.AppendText(text);
            }
        }
        public string Get_Time()
        {
            string str = DateTime.Now.ToShortTimeString().Trim();
            str = str.Substring(0, 5);
            string tmp = "";
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= '0') && (str[i] <= '9')) tmp = tmp + str[i];
            }
            if (tmp.Length == 3) tmp = "0" + tmp;
            return tmp;
        }
        private void sent_arduino(char t)
        {
            string s = Get_Time();
            if (t == '1') s = s + "a";
            else s = s + "d";
            if (t == '1') s = s + list_boxcount.Items[0].Text;
            else s = s + "0";
            //label5.Text = s;
            serialPort.Write(s + "\n");
        }

        public bool IsConnectedToInternet(string host)
        {
            Ping p = new Ping();
            try
            {
                PingReply pr = p.Send(host, 3000);
                if (pr.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            catch (Exception)
            {


            }
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToLongTimeString();
            /*if((txtOutput.Text!="")&&(txtOutput.Text[0] == '1'))
            {
                sent_arduino('0');
                list_time.Items[0].Remove();
                list_available.Items[0].Remove();
                list_boxcount.Items[0].Remove();
                root++;
                return;
            }*/
            if (trangthai.Text == "Đang kết nối")
            {
                if ((list_time.Items.Count > 0) && (list_available.Items[0].Text == "Đang báo"))
                {
                    if ((txtOutput.Text != "") && (txtOutput.Text[0] == '1'))
                    {
                        sent_arduino('0');
                    }
                    else sent_arduino('1');
                }

                else sent_arduino('0');
                //string s = serialPort.ReadTo("#");

                if (list_time.Items.Count > 0)
                {
                    long tmp = point[root];
                    if (tmp <= DateTime.Now.ToFileTime())
                    {

                        if (DateTime.Now.ToFileTime() - tmp <= thoihan)
                        {
                            list_time.Items[0].BackColor = Color.Blue;
                            list_available.Items[0].BackColor = Color.Blue;
                            list_boxcount.Items[0].BackColor = Color.Blue;
                            if (txtOutput.Text != "") list_available.Items[0].Text = "Đã lấy thuốc";
                            else list_available.Items[0].Text = "Đang báo";
                        }
                        else
                        {
                            if (list_time.Items.Count > 0)
                            {
                                if (IsConnectedToInternet("www.google.com"))
                                {
                                    MailMessage mail = new MailMessage("vnhealthndc@gmail.com", dcmail.Text);
                                    mail.Subject = "Kết nối chuyên gia VNHEALTH";
                                    mail.BodyEncoding = UTF8Encoding.UTF8;
                                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                                    mail.Body = "Người dùng chưa uống thuốc ô số: " + list_boxcount.Items[0].ToString() + " lúc: " + list_time.Items[0].ToString();
                                    SendMail(mail);
                                    list_time.Items[0].Remove();
                                    list_available.Items[0].Remove();
                                    list_boxcount.Items[0].Remove();
                                    root++;
                                }
                                else
                                {
                                    MessageBox.Show("Không có kết nối internet", "Thông báo", MessageBoxButtons.OK);

                                    list_time.Items[0].Remove();
                                    list_available.Items[0].Remove();
                                    list_boxcount.Items[0].Remove();
                                    root++;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            thoihan = thoihan * Convert.ToInt32(thoigianbao.Text);
            if (button1.Text == "Kết nối")
            {
                serialPort.PortName = port_combobox.Text;
                serialPort.BaudRate = 9600;
                //SerialPort port = new SerialPort(port_combobox.Text, 9600, Parity.None, 9, StopBits.One);
                //serialPort.Parity = Parity.None;
                //serialPort.DataBits = 5;
                //serialPort.StopBits = StopBits.One;
                serialPort.Open();
                port_combobox.Enabled = false;
                button1.Text = "Ngắt kết nối";
                trangthai.Text = "Đang kết nối";
            }
            else
            {
                serialPort.Close();
                button1.Text = "Kết nối";
                trangthai.Text = "Ngắt kết nối";
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string tmp = "";
            //Đưa thời gian vào hàng chờ!
            tmp = dateTimePicker1.Text.Substring(0, 2);
            int ngay = Convert.ToInt32(tmp);
            tmp = dateTimePicker1.Text.Substring(3, 2);
            int thang = Convert.ToInt32(tmp);
            tmp = dateTimePicker1.Text.Substring(6, 4);
            int nam = Convert.ToInt32(tmp);
            int gio = Convert.ToInt32(cb_gio.Text);
            int phut = Convert.ToInt32(cb_phut.Text);
            DateTime tam = new DateTime(nam, thang, ngay, gio, phut, 0);
            if (tam.ToFileTime() <= DateTime.Now.ToFileTime())
            {
                MessageBox.Show("Thời gian vừa chọn đã xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Push(tam.ToFileTime());

            list_time.Items.Add(tam.ToString());
            list_available.Items.Add("Đang chờ");
            list_boxcount.Items.Add(othuoc.Text);
            point_length++;
            point[point_length] = tam.ToFileTime();
            Array.Sort(point, 0, point_length + 1);
            start = true;
        }

        public static void SendMail(MailMessage Message)
        {

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("vnhealthndc@gmail.com", "huynhvonhathuy1561997");
            client.Send(Message);
        }
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SetText(serialPort.ReadExisting());
            }

            catch (Exception ex)
            {
                SetText(ex.ToString());
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "huongdansudung.pdf";
            proc.Start();
        }

        private void thôngTinSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infomation fr = new infomation();
            fr.ShowDialog();
        }


    }
}
