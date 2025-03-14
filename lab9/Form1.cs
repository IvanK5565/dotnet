namespace lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double func(double R)
        {
            return R;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Козловський Іван Вікторович");
        }

        private void inputReset_Click(object sender, EventArgs e)
        {
            inputRadius.Value = 0;
        }

        private void inputRadius_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                double R = Convert.ToDouble(inputRadius.Value);
                double res = func(R);
                output.Text = $"{res}";
            }
            catch (Exception err)
            {
                output.Text = err.Message;
            }
        }
    }
}
