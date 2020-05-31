using Prj_BenhVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MSMQ_Received
{
    public partial class Received : Form
    {
        MessageQueue queue = null;
        public Received()
        {
            InitializeComponent();
            init();
        }
        void init()
        {
            string path = @".\private$\phongkehoach";
            queue = new MessageQueue(path);
            queue.BeginReceive();
            queue.ReceiveCompleted += Queue_ReceiveCompleted;
        }
        private void Queue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            var msg = e.Message;
            int type = msg.BodyType;
            XmlMessageFormatter fmt = new XmlMessageFormatter(
            new Type[] { typeof(string), typeof(benhnhan) }
            );
            msg.Formatter = fmt;
            var result = msg.Body;
            var t = result.GetType();
            if (t.Equals(typeof(benhnhan)))
            {
                SetText((benhnhan)result);
            }
            
            queue.BeginReceive();//loop back
        }
        private void SetText(benhnhan bn)
        {
            listBox1.DisplayMember = "hoten";
            listBox1.ValueMember = "cmnd";
            listBox1.Items.Add(bn);
        }


        private void bt_load_Click(object sender, EventArgs e)
        {
            benhnhan bn = (benhnhan)listBox1.SelectedItem;
            if (bn != null)
            {
                tb_maso.Text = bn.maso;
                tb_cmnd.Text = bn.cmnd;
                tb_hoten.Text = bn.hoten;
                tb_diachi.Text = bn.diachi;
            }
        }


    }
}
