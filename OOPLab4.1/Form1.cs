namespace OOPLab4._1
{
    public partial class Form1 : Form
    {
        Storage storage; // ��������� � ������������� ������������

        bool isCtrlActive = false;
        bool pressedCtrl = false; 
        public Form1()
        {
            InitializeComponent();
            storage = new Storage();
            this.KeyPreview = true;
        }

        private void PaintBox_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < storage.size; ++i)
            {
                // ������� ����� ������ � Ctrl
                if (isCtrlActive && pressedCtrl) 
                {
                    // ������ ��������� ��� ��������� ����� ������� ���� ��������
                    if (e.Button == MouseButtons.Left && storage.getObject(i).intersects(e.Location))
                    {
                        storage.getObject(i).isActive = true;
                    }
                    // �� �������� �������� ��������, ��� ��� �������� Ctrl
                } else // ������� ����� ��� Ctrl
                {
                    if (e.Button == MouseButtons.Left && storage.getObject(i).intersects(e.Location)) 
                    {
                        storage.getObject(i).isActive = true;
                    }
                    else
                    {
                        storage.getObject(i).isActive = false;
                    }
                }
            }

            // ���������� ���������� �� �������
            if (e.Button == MouseButtons.Right) 
            {
                CCircle element = new CCircle(e.Location.X, e.Location.Y);
                storage.push_back(element);
            }

            // �����������
            PaintBox.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void PaintBox_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("Bebra");
            for (int i = 0; i < storage.size; ++i)
            {
                storage.getObject(i).myPaint(e.Graphics);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                pressedCtrl = true;
                label1.Text = "CtrlDown";
            }
        }

        private void checkBoxCtrl_CheckedChanged(object sender, EventArgs e)
        {
            isCtrlActive = !isCtrlActive;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                pressedCtrl = false;
                label1.Text = "CtrlUp";
            }
        }
    }
}