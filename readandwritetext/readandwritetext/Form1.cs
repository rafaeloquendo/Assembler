using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace readandwritetext
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            String file_name = "\\test.txt"; // provides the location for our file name in this case its test.txt
            String textLine = ""; // creates a textLine of string text
            ArrayList findSubroutine = new ArrayList(); // Only saves the  subroutines
            
            file_name = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + file_name; // gets my specific object txt location
            System.IO.StreamReader objReader; // System.IO.StreamReader creates an objReader which ill use later in the program.
            objReader = new System.IO.StreamReader(file_name);
            ArrayList location = new ArrayList();

            string[] insructions = {"NOP", "MULS","ADD","SUB","LDI","AND","OR","RJMP","SLEEP","TST"};
            string[] opcodes = {"0000000000000000","00000010","000011","000110","1110","001000","001010","1100","1001010110001000","001000"};

            
            string test = ""; // created to test if we are able to attach opcodes from function together *which was successful*
            
            for (int i = 0; i < opcodes.Length; i++)
            {
                if (opcodes[i].Count() < 16)
                {
                    MessageBox.Show("This mother fucker has less than 16 characters " + i);
                    test = getOp(opcodes[i], "something", "somethingelse");
                }
            }

            MessageBox.Show(test);

            int x = 1;
            while (objReader.Peek() != -1)
            {
                textLine = objReader.ReadLine() + "\r\n"; //reads this line by line
                if (textLine.Contains(":"))
                {
                    findSubroutine.Add(textLine);
                    location.Add(x);
                }
                x++;
            }

            //code just for testing location and subroutine.
            for (int i = 0; i < findSubroutine.Count; i++)
            {
                //MessageBox.Show(findSubroutine[i].ToString());
                //MessageBox.Show(location[i].ToString());
            }
            objReader.Close();
        }
        // this function is to complete the missing opcodes
        public string getOp(string opcodes, string p1, string p2) //parameter 1, param 2
        {
            string send = opcodes + p1 + p2; //we assume we get registers in hex
            return send;
        }

        //convert from hex to binary
        public string hex2binary(string hexvalues)
        {
            string binaryValue = "";
            binaryValue = Convert.ToString(Convert.ToInt32(hexvalues,16),2);
            return binaryValue;
        }

        
        //we need a function that determines if have less than 16 characters to call the getOp function. 
    }
}
