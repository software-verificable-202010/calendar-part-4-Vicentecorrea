﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using CalendarApp.Models;

namespace CalendarApp.Views
{
    public partial class AppointmentsInDayForm : Form
    {
        List<Appointment> appointments = new List<Appointment>();
        public AppointmentsInDayForm(List<Appointment> appointmentsInDay, DateTime day)
        {
            InitializeComponent();
            appointments = appointmentsInDay;
            appointmentSelectionLabel.Text = "Select one of the events of " + day.ToString(Constants.DayAndMonthFormat, new CultureInfo(Constants.EnglishLanguageCode));
            AddappointmentsToListBox();
            //appointmentsListBox.SelectedIndex = Constants.DefaultInitialIndex;
        }

        private void AddappointmentsToListBox()
        {
            foreach (Appointment appointment in appointments)
            {
                LinkLabel appointmentLink = new LinkLabel();
                appointmentLink.Text = appointment.Title;
                appointmentsListBox.Tag = appointment;
                appointmentsListBox.Items.Add(appointmentLink.Text);
            }
        }

        private void appointmentslistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Constants.DefaultInitialIndex <= appointmentsListBox.SelectedIndex && appointmentsListBox.SelectedIndex < appointments.Count)
            {
                AppointmentInformationForm appointmentInformationForm = new AppointmentInformationForm(appointments[appointmentsListBox.SelectedIndex]);
                appointmentInformationForm.Show();
            }
        }
    }
}