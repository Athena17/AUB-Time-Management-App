﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUBTimeManagementApp.GUI {
    public partial class TeamsForm : Form {
        public TeamsForm() {
            Client.Client.Instance.setForm(this);
            InitializeComponent();
            addTeamButton.BringToFront();
        }

        private void addTeamButton_Click(object sender, EventArgs e) {
            Button newB = new Button();
            newB.Margin = new Padding(0);
            newB.Text = "New Team!";
            newB.Size = new Size(485, 46);
            TeamsLayout.Controls.Add(newB);
        }

        private void backButton_Click(object sender, EventArgs e) {
            mainForm mF = new mainForm();
            mF.Show();
            Close();
        }
    }
}