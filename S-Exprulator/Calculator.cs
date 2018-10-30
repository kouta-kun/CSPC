using System.Windows.Forms;

namespace S_Exprulator
{
    /// <remarks>
    /// GPLv3 (R) koutakun &lt;darkfm@vera.com.uy&gt;
    /// </remarks>
    public partial class Calculator : Form
    {
        private SExpr.Interpreter Interpreter = new SExpr.Interpreter();
        public Calculator()
        {
            InitializeComponent();
        }

        private void ExecuteFunction()
        {
            try
            {
                var input = SExpr.Parser.ParseString(textBox1.Text);
                var result = Interpreter.RunFunction(input);
                textBox1.Text = result.ToString();
            } catch (System.Exception e)
            {
                textBox1.Text = e.ToString();
            }
        }

        private void button10_Click(object sender, System.EventArgs e)
        {
            ExecuteFunction();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button7_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button8_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void buttonOPar_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += "(";
        }

        private void buttonCPar_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += ")";
        }

        private void buttonPlus_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void buttonMinus_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void buttonMult_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void buttonDiv_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void button11_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += " ";
        }

        private void button12_Click(object sender, System.EventArgs e)
        {
            textBox1.Text += ".";
        }

        private void keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ExecuteFunction();

        }
    }
}
