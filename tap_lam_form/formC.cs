using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tap_lam_form
{
    public partial class formC : Form
    {
        public formC()
        {
            InitializeComponent();
        }

        private Form currentFormChild;
        private void OpenFormChild(Form child)
        { //nếu form đang hiện hành thì đóng
            if(currentFormChild != null)
            {
              currentFormChild.Close();
            }
            currentFormChild = child;
            child.TopLevel = false; //xác định form cấp cao nhất hay không
            child.FormBorderStyle = FormBorderStyle.None;//xóa đường viền 
            child.Dock = DockStyle.Fill;//form con tự động lấp đầy khoảng trống trong panel
            panel4.Controls.Add(child);//form con sẽ hiện trong panel4
            panel4.Tag = child;//tag sử dụng để lưu trữ dữ liệu liên quan đến một điều khiển
            child.BringToFront();//đưa form con lên trước để nhìn thấy
            child.Show();//hiện form
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void formA_Click(object sender, EventArgs e)
        {
            OpenFormChild(new formA());
            label1.Text = formA.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFormChild(new formB());
            label1.Text = button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFormChild(new Form1());
            label1.Text=button3.Text;
           
        }

        private void formC_Load(object sender, EventArgs e)
        {
            for(int i = 0;i< imlDSHA.Images.Count; i++)
            {
                cbbChonHinh.Items.Add("Hình: " + i);
            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            label1.Text = "Trang chủ";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("chào mừng "+ textBox1.Text + " đến khóa học " + this.comboBox1.SelectedItem.ToString() + " của chúng tôi ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Welcome: " + this.textBox1.Text + "\n";
                if (radioButton1.Checked == true) str += "Giới tính: Nam\n";
            else str += "Giới tính: Nữ\n";
            if (comboBox1.SelectedItem != null) str += "Khóa học: " + this.comboBox1.SelectedItem.ToString();
            else
            {
                MessageBox.Show( "Thí sinh không chọn khóa học");
                return;
            }
            if (maskedTextBox1.Text==null)
            {
                MessageBox.Show("Vui lòng nhập ngày sinh.");
                return; // Ngừng xử lý nếu không có ngày sinh
            }
            else
            {
                str += "\nNgày sinh: " + maskedTextBox1.Text.ToString();
            }
            MessageBox.Show(str);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClickOK_Click(object sender, EventArgs e)
        {
            timer1_Tick.Start();
        }

        private void timer1_Tick_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1_Tick.Stop();
                MessageBox.Show("Đã chạy xong");
                progressBar1.Value = progressBar1.Minimum;
                lblTienDo.Text = "0%";
            }
            else
            {
                progressBar1.PerformStep();
                lblTienDo.Text=progressBar1.Value.ToString();
            }
        }

        private void lblTienDo_Click(object sender, EventArgs e)
        {

        }

        private void cbbChonHinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbHinhanh.Image = imlDSHA.Images[cbbChonHinh.SelectedIndex];
        }

        private void btnMSSV_Click(object sender, EventArgs e)
        {
            ListViewItem lv=new ListViewItem(txtMSSV.Text);
            //Thêm các ô tiếp
            lv.SubItems.Add(txtHoTen.Text);
            lv.SubItems.Add(txtLop.Text);
            lv.SubItems.Add(txtGoiTinh.Text);
            LvDanhSach.Items.Add(lv);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //Xem danh sách có thành viên để xóa không
            if(LvDanhSach.SelectedItems.Count > 0)
            {
                LvDanhSach.Items.Remove(LvDanhSach.SelectedItems[0]);
                MessageBox.Show("Đã xóa một dòng");
            }
            else
            {
                MessageBox.Show("Không có ai trong danh sách","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (LvDanhSach.SelectedItems.Count > 0)
            {
                ListViewItem lv = LvDanhSach.SelectedItems[0];
                lv.SubItems[0].Text = txtMSSV.Text;
                lv.SubItems[1].Text = txtHoTen.Text;
                lv.SubItems[2].Text = txtLop.Text;
                lv.SubItems[3].Text = txtGoiTinh.Text;
            }
            else
            {
                MessageBox.Show("Không có ai trong danh sách", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LvDanhSach.SelectedItems.Count > 0)
            {
                ListViewItem lv = LvDanhSach.SelectedItems[0];
                txtMSSV.Text = lv.SubItems[0].Text;
                txtHoTen.Text = lv.SubItems[1].Text;
                txtLop.Text= lv.SubItems[2].Text;   
                txtGoiTinh.Text= lv.SubItems[3].Text;
            }
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void pbHinhanh_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
