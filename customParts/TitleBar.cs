using System.Drawing;
using System.Windows.Forms;

namespace Sci_Cal.customParts
{
    public class TitleBar : Panel
    {
		public TabButton exitButton;
		public TabButton maxButton;
		public TabButton minButton;
		public string backColor = "#b8bdb5";
        public TitleBar()
        {
            Size = new Size(510, 50);
            BackColor = ColorTranslator.FromHtml("#5f7470");
            Location = new Point(0, 0);
            Anchor = AnchorStyles.Top | AnchorStyles.Right |AnchorStyles.Left;
			
			Label title = new Label{
				Size = new System.Drawing.Size(100, 50),
				Location = new System.Drawing.Point(5, -5),
				Text = "Calculator",
				Font = new Font("bodoni", 10),
				ForeColor = ColorTranslator.FromHtml("#e0e2db"),
				Anchor = AnchorStyles.Top | AnchorStyles.Left,
				TextAlign = ContentAlignment.MiddleCenter
			};
			Controls.Add(title);

            exitButton = new TabButton(470, 0);
			minButton = new TabButton(420, 0);

			minButton.Text = "-";

            exitButton.Click += (sender, e) => {
                Application.Exit();
            };
			Controls.Add(exitButton);
			Controls.Add(minButton);
			

        }
    }

    public class TabButton : Button
    {
        public TabButton(int x, int y)
        {
			FlatStyle = FlatStyle.Flat;
            Text = "X";
            Location = new Point(x, y);
            Size = new Size(40, 40);
            ForeColor = ColorTranslator.FromHtml("#e0e2db");
			Anchor = AnchorStyles.Top | AnchorStyles.Right;
			AutoSize = false;
			Font = new Font("Montserrat", 10);
			FlatAppearance.BorderColor = ColorTranslator.FromHtml("#5f7470");
			FlatAppearance.BorderSize = 1;
        }
    }
}
