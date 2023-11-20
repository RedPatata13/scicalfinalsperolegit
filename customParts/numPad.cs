namespace Sci_Cal.customParts;
using System.Drawing;

public class NumPad : Panel
{
	public List<List<numButton>> NumButtons;
	private readonly string[] numText = new string[] { "7", "8", "9", "4", "5", "6", "1", "2", "3", "0", "." };
	public EventHandler NumButtonClick;
	
	public NumPad(int x, int y)
	{
		Size = new Size(360, 400);
		Location = new Point(x, y);
		BackColor = ColorTranslator.FromHtml("#5f7470");
		NumButtons = new List<List<numButton>>();
		Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		
		InitializeNumPad();
	}
	
	private void InitializeNumPad()
	{
		int buttonWidth = 90;
		int buttonHeight = 60;
		int horizontalSpacing = 10;
		int verticalSpacing = 10;

		for (int rows = 0; rows < 3; rows++)
		{
			List<numButton> buttonRow = new List<numButton>();
			for (int cols = 0; cols < 3; cols++)
			{
				int x = cols * (buttonWidth + horizontalSpacing) + horizontalSpacing;
				int y = rows * (buttonHeight + verticalSpacing) + verticalSpacing;

				numButton but = new numButton(x, y);
				but.Text = numText[rows * 3 + cols];
				buttonRow.Add(but);
				but.Click += (sender, e) => NumButtonClick?.Invoke(sender, e);
				Controls.Add(but);
			}
			NumButtons.Add(buttonRow);
		}
		
		List<numButton> moreNumButs = new List<numButton>();
		
		numButton zero = new numButton(10, 220);
		zero.Text = numText[9];
		zero.Click += (sender, e) => NumButtonClick?.Invoke(sender, e);
		zero.Width += zero.Width + 10;
		
		moreNumButs.Add(zero);
		Controls.Add(zero);
		
		numButton point = new numButton(210, 220);
		point.Text = numText[10];
		zero.Click += (sender, e) => NumButtonClick?.Invoke(sender, e);
		moreNumButs.Add(point);
		Controls.Add(point);
		
		NumButtons.Add(moreNumButs);
		
		this.Width = point.Width * 3 + 40;
		this.Height = point.Height * 4 + 50;
		
		
	}
	
}

public class numButton : Button
{
	public numButton(int x, int y)
	{
		Size = new Size(90, 60);
		Location = new Point(x, y);
		FlatStyle = FlatStyle.Flat;
		FlatAppearance.BorderColor = ColorTranslator.FromHtml("#5f7470");
		Anchor =  AnchorStyles.Top | AnchorStyles.Left;
		AutoSize = true;
		ForeColor = ColorTranslator.FromHtml("#e0e2db");
		BackColor = ColorTranslator.FromHtml("#889696");
		FlatAppearance.BorderSize = 1;
		TextAlign = ContentAlignment.MiddleCenter;
		Font = new Font("Xenara", 14);
	}
}		
