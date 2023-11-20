namespace Sci_Cal.customParts;
using System.Drawing;

public class BottomTopButtons : Panel
{
	public List<BTButtons> buttons;
	private readonly string[] BottomTopButtonsText = new string[] { "sin()", "cos()", "tan()", "log()", "ln()" };
	public EventHandler BottomTopButtonsClick;
	public BottomTopButtons(int x, int y)
	{
		Location = new Point(x, y);
		buttons = new List<BTButtons>();
		Size = new Size (550, 80);
		BackColor = ColorTranslator.FromHtml("#5F7470");
		Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		InitializeButtons();
	}
	
	private void InitializeButtons()
	{
		int buttonWidth = 90;
		int buttonHeight = 60;
		int horizontalSpacing = 10;
		int verticalSpacing = 10;
		buttons = new List<BTButtons>();
		for(int i = 0; i < 5; i++)
		{
			int x = i * (buttonWidth + horizontalSpacing) + horizontalSpacing;
			BTButtons but = new BTButtons(x, 10);
			
			if(i == 4)but.BackColor = ColorTranslator.FromHtml("#607870");
			but.Text = BottomTopButtonsText[i];
			but.Click += (sender, e) => BottomTopButtonsClick?.Invoke(sender, e);
			Controls.Add(but);
			buttons.Add(but);
		}
	}
}

public class BTButtons : Button
{
	public BTButtons(int x, int y)
	{
		Size = new Size(90, 60);
		Location = new Point(x, y);
		FlatStyle = FlatStyle.Flat;
		FlatAppearance.BorderColor = ColorTranslator.FromHtml("#5f7470");
		Anchor =  AnchorStyles.Top | AnchorStyles.Left;
		AutoSize = true;
		ForeColor = ColorTranslator.FromHtml("#e0e2db");
		BackColor = ColorTranslator.FromHtml("#778c85");
		FlatAppearance.BorderSize = 1;
		TextAlign = ContentAlignment.MiddleCenter;
		Font = new Font("Xenara", 13);
	}
}
