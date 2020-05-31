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

namespace MSMQ_Sender
{
    public partial class Sender : Form
    {
        MessageQueue queue = null;
        public Sender()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            string path = @".\private$\phongkehoach";
            //string path = @"hbmnl\private$\phongkehoach";
            if (MessageQueue.Exists(path))
            {
                queue = new MessageQueue(path, QueueAccessMode.Send);
            }
            else
                queue = MessageQueue.Create(path, true);
        }
        private void bt_luu_Click(object sender, EventArgs e)
        {
            benhnhan bn = new benhnhan();
            bn.maso = tb_maso.Text;
            bn.cmnd = tb_cmnd.Text;
            bn.hoten = tb_hoten.Text;
            bn.diachi = tb_diachi.Text;
            MessageQueueTransaction transaction = new MessageQueueTransaction();
            transaction.Begin();
            queue.Send(bn, transaction);
            transaction.Commit();
        }

    }
}
