namespace GRandEddie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.BackColor = System.Drawing.Color.FromArgb(255, 000, 000);
        }
    }
}
