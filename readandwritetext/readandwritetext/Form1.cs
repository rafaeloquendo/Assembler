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
            btnOpen2.Hide();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            String file_name = "\\test.txt"; // provides the location for our file name in this case its test.txt
            String textLine = ""; // creates a textLine of string text
            ArrayList findSubroutine = new ArrayList(); // I am creating an array to insert all individual items into the array. 
            file_name = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + file_name; // gets my specific object txt location
            System.IO.StreamReader objReader; // System.IO.StreamReader creates an objReader which ill use later in the program.
            objReader = new System.IO.StreamReader(file_name);
            
            while (objReader.Peek() != -1)
            {
                textLine = objReader.ReadLine() + "\r\n"; //reads this line by line
                findSubroutine.Add(textLine); // adds each textLine to my arraylist
            }
            
            string[] s1 = new string[10]; //create a string array for better manipulation of the items added to arraylist
            //this forloop adds each item to my string array from arraylist
            for (int i = 0; i <= 9; i++ )
            {
                s1[i] = findSubroutine[i].ToString(); 
            }

            
            string subroutine = "";
            string test = "";
            
            int location = 0;
            int numberOfSubroutine = 0;
            
            for (int i = 0; i < s1.Length; i++)
            {
                test = s1[i];
                //MessageBox.Show(test);
                if (test.Contains(":"))
                {
                    subroutine = test;
                    subroutine = Regex.Replace(subroutine, @"[:]", "");
                    location = i+1;
                    numberOfSubroutine++;
                }
            }
            
            //this looks for multiple subroutines
            string[] subroutines = new string[numberOfSubroutine];
            int[] locations = new int[numberOfSubroutine];
            
            if (numberOfSubroutine > 0)
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    test = s1[i];
                    if (test.Contains(":"))
                    {
                        subroutines[i] = test;
                        locations[i] = i+1;
                    }
                   // MessageBox.Show("Pass One Completed****\nMultiple Subroutine located : " + (i+1) + " subroutine is " + subroutines[i] + "\nIts location is at line number : "+ locations[i]);
                }

            }
            else
            { 
                textBox1.Text = subroutine;
                MessageBox.Show("Pass One Completed*****\n A Subroutine was located: " + subroutine +"\nLocated at line number " + location);
            }
           
            for (int i = 0; i < subroutines.Length; i++)
            {
                MessageBox.Show("Pass One Completed****\nMultiple Subroutine located : " + (i+1) + " subroutine is " + subroutines[i] + "\nIts location is at line number : "+ locations[i]);
            }
            objReader.Close();
            btnOpen2.Show();
            btnOpen.Hide();
        }

        //NOTE is btnOpen2 is clicked before btnOpen1 then I created it to run btnOpen1 first
        private void btnOpen2_Click(object sender, EventArgs e)
        {
            String file_name = "\\test.txt"; 
            String textLine = ""; 

            file_name = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + file_name;
            System.IO.StreamReader objReader; 
            objReader = new System.IO.StreamReader(file_name);
            
            string[] s1 = new string[10];
            for (int i = 0; i <= 9; i++)
            { 
                textLine = objReader.ReadLine() + "\r\n";
                s1[i] = textLine;
            }
            int[] location = new int[10];
            //creates a location for the s1 array
            ArrayList a1 = new ArrayList(); // will be used to print out the messagebox to textbox
            for (int i = 0; i <= 9; i++)
            {
                location[i] = i;
               // MessageBox.Show("SAVED " + s1[i] + "to INDEX " + location[i]);
            }
            //this for loops prints out where we saved the s1 locations
            string text = "";
            for (int i = 0; i <= 9; i++)
            {
                text = text + "SAVED " + s1[i] + "to INDEX " + location[i] + "\r\n";
                textBox2.Text = text;
            }
            objReader.Close();
            MessageBox.Show("Congrats Pass Two Completed. All Index successfully saved Index Array()");
            btnOpen2.Hide();
        }
    }
}
