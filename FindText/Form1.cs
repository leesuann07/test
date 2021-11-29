using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindText
{
    public partial class Form1 : Form
    {
        int iFindStartIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            richTextBox1.Text = "richTextbox1, Textbox";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //찾는 문자열 길이
            int iFindLength = textbox1.Text.Length;
            iFindStartIndex = FindMyText(textbox1.Text, iFindStartIndex, richTextBox1.Text.Length);
            if (iFindStartIndex == -1)
            {
                iFindStartIndex = 0;
                return;
            }

            //찾은 문자열 선택해서 붉은색으로 바꾸기
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.Select(iFindStartIndex, iFindLength);

            //다음 찾기를 위해 찾은 문자열 위치 저장
            iFindStartIndex += iFindLength;
        }

        private int FindMyText(string searchText, int searchStart, int searchEnd)
        {
            // Initialize the return value to false by default.
            int returnValue = -1;

            // Ensure that a search string and a valid starting point are specified.
            if (searchText.Length > 0 && searchStart >= 0)
            {
                // Ensure that a valid ending value is provided.
                if (searchEnd > searchStart || searchEnd == -1)
                {
                    // Obtain the location of the search string in richTextBox1.
                    int indexToText = richTextBox1.Find(searchText, searchStart, searchEnd, RichTextBoxFinds.MatchCase);
                    // Determine whether the text was found in richTextBox1.
                    if (indexToText >= 0)
                    {
                        // Return the index to the specified search text.
                        returnValue = indexToText;
                    }
                }
            }

            return returnValue;
        }
    }
}

