using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
namespace Optimism_for_Mental_Health
{
    public partial class ketnoichuyengia : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public ketnoichuyengia()
        {
            InitializeComponent();
            kryptonGroupBox1.Text = "Thông tin tư vấn";
            kryptonGroupBox2.Text = "Hình triệu chứng";
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
        private bool kiemtradieukien()
        {
            if ((hoten.Text == "") || (sdt.Text == "") || (tuoi.Text == "") || (vandetuvan.Text == ""))
                return false;
            else
            {
                string tmp = link.Text.ToString().Substring(link.TextLength - 3, 3);
                if ((tmp == "png") || (tmp == "PNG") || (tmp == "JPG") || (tmp == "jpg"))
                    return true;
                else return false;
            }
        }
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (kiemtradieukien() == false)
            {
                MessageBox.Show("Chưa điền đủ thông tin hoặc file ảnh không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MailMessage mail = new MailMessage("vnhealthndc@gmail.com", "vnhealthndc.chuyengia@gmail.com");
            mail.Subject = "Kết nối chuyên gia VNHEALTH";
            mail.BodyEncoding = UTF8Encoding.UTF8;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mail.Body = "Thông tin người gửi: " + hoten.Text + "|" + sdt.Text + "|" + tuoi.Text + " tuổi" + "\n" + vandetuvan.Text;
            mail.Attachments.Add(new Attachment(link.Text));
            if (IsConnectedToInternet("www.google.com"))
            {
                SendMail(mail);
                MessageBox.Show("Đã gửi đến chuyên gia", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có kết nối internet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void openfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            link.Text = op.FileName;
            string tmp = link.Text.ToString().Substring(link.TextLength - 3, 3);
            if ((tmp == "png") || (tmp == "PNG") || (tmp == "JPG") || (tmp == "jpg"))
            {
                pictureBox1.Image = Image.FromFile(link.Text);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            hoten.Text = "";
            tuoi.Text = "";
            sdt.Text = "";
            link.Text = "";
            vandetuvan.Text = "";
        }

    }
}
