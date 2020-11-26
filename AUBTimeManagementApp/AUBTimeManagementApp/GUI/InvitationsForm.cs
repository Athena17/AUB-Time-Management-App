﻿using AUBTimeManagementApp.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AUBTimeManagementApp.GUI
{
    public partial class InvitationsForm : Form
    {
        mainForm _parent;
        public Dictionary<Button, Invitation> AcceptButtonToInvitation;
        public Dictionary<Button, Invitation> DeclineButtonToInvitation;
        List<Button> AcceptButtons; // To know which button is pressed
        List<Button> DeclineButtons;
        List<Label> Labels;
        public InvitationsForm(mainForm parent)
        {
            _parent = parent;
            AcceptButtonToInvitation = new Dictionary<Button, Invitation>();
            DeclineButtonToInvitation = new Dictionary<Button, Invitation>();
            AcceptButtons = new List<Button>();
            DeclineButtons = new List<Button>();
            Labels = new List<Label>();
            InitializeComponent();
            DisplayInvitations();
            
        }

        public void DisplayInvitations()
        {
            AcceptButtonToInvitation.Clear();
            DeclineButtonToInvitation.Clear();
            List<Invitation> userInvitations = Client.Client.Instance.GetInvitations();
            foreach (Invitation invitation in userInvitations) { AddInvitationEntry(invitation); }
        }
        public void AddInvitationEntry(Invitation invitation)
        {

            GroupBox groupBox1 = new GroupBox();
            Button AcceptButton = new Button();
            Button DeclineButton = new Button();
            Label invitationLabel = new Label();

            AcceptButtons.Add(AcceptButton);
            DeclineButtons.Add(DeclineButton);
            Labels.Add(invitationLabel);

            // 
            // AcceptButton
            // 
            AcceptButton.BackColor = Color.LimeGreen;
            AcceptButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            AcceptButton.ForeColor = Color.White;
            AcceptButton.Location = new Point(550, 7);
            AcceptButton.Name = "AcceptButton";
            AcceptButton.Size = new Size(87, 27);
            AcceptButton.TabIndex = 4;
            AcceptButton.Text = "Accept";
            AcceptButton.UseVisualStyleBackColor = false;
            AcceptButton.Click += AcceptButton_Click;
            // 
            // DeclineButton
            // 
            DeclineButton.BackColor = Color.LightCoral;
            DeclineButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            DeclineButton.ForeColor = Color.White;
            DeclineButton.Location = new Point(650, 7);
            DeclineButton.Name = "DeclineButton";
            DeclineButton.Size = new Size(87, 27);
            DeclineButton.TabIndex = 3;
            DeclineButton.Text = "Decline";
            DeclineButton.UseVisualStyleBackColor = false;
            DeclineButton.Click += DeclineButton_Click;
            // 
            // invitationLabel
            // 
            invitationLabel.AutoSize = true;
            invitationLabel.BackColor = Color.Transparent;
            invitationLabel.ForeColor = Color.Black;
            invitationLabel.Location = new Point(20, 10);
            invitationLabel.Name = "invitationLabel";
            invitationLabel.Size = new Size(36, 13);
            invitationLabel.TabIndex = 2;
            invitationLabel.Text = "Event: " + invitation.Event.eventName + "  |  In team: " + invitation.TeamID + "  |  Sent by: " + invitation.InvitationSender;
            invitationLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            

            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(invitationLabel);
            groupBox1.Controls.Add(AcceptButton);
            groupBox1.Controls.Add(DeclineButton);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(760, 36);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;

            flowLayoutPanel1.Controls.Add(groupBox1);
            AcceptButtonToInvitation[AcceptButton] = invitation;
            DeclineButtonToInvitation[DeclineButton] = invitation;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            int idx = AcceptButtons.FindIndex(a => a == sender);
            AcceptButtons[idx].Hide();
            DeclineButtons[idx].Hide();
            Labels[idx].Hide();
            Client.Client.Instance.AcceptInvitation(AcceptButtonToInvitation[AcceptButtons[idx]]);
        }

        private void DeclineButton_Click(object sender, EventArgs e)
        {
            int idx = DeclineButtons.FindIndex(a => a == sender);
            AcceptButtons[idx].Hide();
            DeclineButtons[idx].Hide();
            Labels[idx].Hide();
            Client.Client.Instance.DeclineInvitation(AcceptButtonToInvitation[AcceptButtons[idx]]);
        }

        private void InvitationButton_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}