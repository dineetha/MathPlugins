using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

// First build this test program and other 4 plugin assemblies. Then copy 4 assemblies to test program debug folder and try.
//All plugins for addition, subtraction, multiplication adn division should be loaded and 4 button will be displayed.
//This repository contains 4 example plugin assemblies and a test program. For educational purpose. Specially for students learning C# and .NET
// Written by Dineetha 2019


namespace MathPlugins
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Get all dll files in the current directory and add to list
            string[] dllFiles = Directory.GetFiles(Application.StartupPath, "*.dll");
            var assemblyList = new List<Assembly>();

            // Loop through files
            for (int i = 0; i < dllFiles.Length; i++)
            {
                //Load assembly and get methods
                assemblyList.Add(Assembly.LoadFrom(dllFiles[i]));
                Type type = assemblyList[i].GetType(assemblyList[i].GetName().Name + ".MathOperation");
                object instance = Activator.CreateInstance(type);
                MethodInfo[] methods = type.GetMethods();

                // Add a button for the current assembly method
                var button = new Button();
                button.Name = methods[0].Name;
                button.Text = methods[0].Name;
                button.Location = new Point(100 * i + 100, 75);

                // Add button click event
                button.Click += delegate(object sender1, EventArgs e1)
                {
                    double d1=0, d2=0;
                    if (Double.TryParse(textBox1.Text, out d1) && Double.TryParse(textBox2.Text, out d2))
                    {
                        object result = methods[0].Invoke(instance, new object[] { d1, d2 });
                        textBox3.Text = result.ToString();
                        d1 = 0;
                        d2 = 0;
                    }
                    else
                    {
                        MessageBox.Show("Please enter two valid numbers");
                    }
                };
                this.Controls.Add(button);
            }
          
        }
    }
}
