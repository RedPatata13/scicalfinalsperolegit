using System.Runtime.InteropServices;


namespace Sci_Cal.customParts
{
    using System.Drawing;
    using System.Windows.Forms;

    public class InOutField : UserControl
    {
        private TextBox invisInputField;
        private Label outputField;

        public InOutField(int x, int y)
        {
            this.Size = new Size(490, 170);
            this.Location = new Point(x, y);
            this.BackColor = ColorTranslator.FromHtml("#5F7470");
            this.ForeColor = ColorTranslator.FromHtml("#e0e2db");
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;

            InitializeInputField();
            this.Click += InOutField_Click;

            outputField = new Label
            {
                Location = new Point(0, 60),
                Size = new Size(498, 80),
                Font = new Font("Xenara Bold", 18),
                TextAlign = ContentAlignment.MiddleRight,
                Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left,
                BorderStyle = BorderStyle.None,
                BackColor = ColorTranslator.FromHtml("#5F7470"),
                ForeColor = ColorTranslator.FromHtml("#F2E9E4")
            };
            Controls.Add(outputField);
			
        }
		public string getExpression()
		{
			return invisInputField.Text;
		}
		public void InsertAns(string text)
		{
			int nexPos = invisInputField.SelectionStart + text.Length;
			invisInputField.Text = invisInputField.Text.Insert(invisInputField.SelectionStart,text);
			invisInputField.SelectionStart = nexPos;
			invisInputField.Focus();
		}
		public void concatenateTextFromButton(string text){
			int nextPos = invisInputField.SelectionStart + 1;
			invisInputField.Text = invisInputField.Text.Insert(invisInputField.SelectionStart, text);
			invisInputField.SelectionStart = nextPos;
			invisInputField.Focus();
		}
		public void InsertLong(string text)
		{
			int nextPos = invisInputField.SelectionStart + text.Length - 1;
			invisInputField.Text = invisInputField.Text.Insert(invisInputField.SelectionStart, text);
			invisInputField.SelectionStart = nextPos;
			invisInputField.Focus();
		}
		public void DelChar(){
			if(invisInputField.SelectionStart > 0)
			{
				int newCaretPos = invisInputField.SelectionStart - 1;
				invisInputField.Text = invisInputField.Text.Remove(newCaretPos, 1);
				invisInputField.SelectionStart = newCaretPos;
				invisInputField.Focus();
			}
		}
		public void ClearField()
		{
			invisInputField.Text = "";
			invisInputField.Focus();
		}
		public void UpdateOutField(string text)
		{
			outputField.Text = text;
		}

        private void InitializeInputField()
        {
            invisInputField = new TextBox()
            {
                Location = new Point(-523, 10),
                Size = new Size(1010, 40),
                Font = new Font("Xenara", 18),
                TextAlign = HorizontalAlignment.Right,
                Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left,
                BorderStyle = BorderStyle.None,
                BackColor = ColorTranslator.FromHtml("#5F7470"),
                ForeColor = ColorTranslator.FromHtml("#F2E9E4"),
				ScrollBars = ScrollBars.None
            };

            Controls.Add(invisInputField);
        }

        private void InOutField_Click(object sender, EventArgs e)
        {
            invisInputField.Focus();
        }
    }
}
