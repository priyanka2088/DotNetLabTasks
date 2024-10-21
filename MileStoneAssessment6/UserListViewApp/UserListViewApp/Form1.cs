using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace UserListViewApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the text from the TextBox
            string itemText = txtItem.Text.Trim();

            // Check if the TextBox is not empty
            if (!string.IsNullOrEmpty(itemText))
            {
                // Add the item to the ListView
                listViewItems.Items.Add(itemText);
                txtItem.Clear(); // Clear the TextBox after adding
            }
            else
            {
                MessageBox.Show("Please enter an item.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if any item is selected
            if (listViewItems.SelectedItems.Count > 0)
            {
                // Remove the selected item
                listViewItems.Items.Remove(listViewItems.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Please select an item to remove.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
