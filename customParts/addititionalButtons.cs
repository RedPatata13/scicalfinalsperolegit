namespace Sci_Cal.customParts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
public class AdditionalButtons : Panel
{
	private readonly string[] OpButtonText = new string[]{ "/", "*", "-", "+" , "DEG", "%", "=", "c" };
	public EventHandler OpButtonClick;
	public EventHandler EqualButtonClick;
	public EventHandler DegRadSwitch;
	public List<List<OpButton>> OpButtons;
	
	public AdditionalButtons(int x, int y){
		Location = new Point(x, y);
		Size = new Size(180, 260);
		BackColor = ColorTranslator.FromHtml("#5F7470");
		OpButtons = new List<List<OpButton>>();
		
		InitializeAdditionalButtons();
		
	}
	public void CleanUp()
	{
		for(int i = 0; i < OpButtons.Count; i++)
		{
			OpButtons[i] = null;
		}
		OpButtons = null;
	}
	
	
	public void InitializeAdditionalButtons(){
		int buttonWidth = 90;
		int buttonHeight = 60;
		int horizontalSpacing = 10;
		int verticalSpacing = 10;
		
		for(int cols = 0; cols < 2; cols++){
			List<OpButton> buts = new List<OpButton>();
			int rows = 0;
			while(rows < 4)
			{
				int x = cols * (buttonWidth + horizontalSpacing) + horizontalSpacing;
				int y = rows * (buttonHeight + verticalSpacing) + verticalSpacing;
				
				OpButton but = new OpButton(x, y);
				if(cols* 4 + rows > 3){
					but.BackColor = ColorTranslator.FromHtml("#607870");
				}
				if(cols * 4 + rows == 6 || cols *4 + rows == 4){
					if(cols * 4 + rows == 6)
					{
						but.Height += but.Height + verticalSpacing;
						but.Click += (sender, e) => EqualButtonClick?.Invoke(sender, e);
						
					}
					else 
					{
						but.Click += (sender, e) => DegRadSwitch?.Invoke(sender, e);
					}
				}else {
					but.Click += (sender, e) => OpButtonClick?.Invoke(sender, e);
				}
				but.Text = OpButtonText[cols * 4 + rows];

				buts.Add(but);
				Controls.Add(but);
				if(cols * 4 + rows == 7) Controls.Remove(but);
				rows++;
			}
			rows = 0;
			OpButtons.Add(buts);
		}
		

		
		this.Width = buttonWidth * 2 + horizontalSpacing + 20;
		this.Height = buttonHeight * 4 + 40;
	}
	
	public string[] getTextArray(){
		return OpButtonText;
	}
}

public class OpButton : Button
{
	public OpButton(int x, int y)
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