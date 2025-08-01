﻿using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RE_manager
{
    public partial class formApartmentSevicesDisplay2 : Form
    {
        private readonly int _apartmentNumber;
        private readonly int _buildingNumber;
        public formApartmentSevicesDisplay2(int apartmentNumber, int buildingNumber)
        {
            InitializeComponent();
            _apartmentNumber = apartmentNumber;
            _buildingNumber = buildingNumber;
        }

        private void formApartmentSevicesDisplay2_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;
            LoadData();
            dataGridView1.Columns["ApartmentNumber"].Visible = false;
        }

        private void LoadData()
        {
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                var services = ctx.ApartmentServices2
                    .Where(s => s.ApartmentNumber == _apartmentNumber && s.BuildingNumber == _buildingNumber)
                    .OrderBy(s => s.ServiceDate)
                    .ToList();

                bindingSource1.DataSource = services;
            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingSource1.Current is ApartmentService edited)
            {
                using (var ctx = new PeopleContextFactory().CreateDbContext(null))
                {
                    edited.ApartmentNumber = _apartmentNumber;
                    edited.BuildingNumber = _buildingNumber;
                    ctx.ApartmentServices2.Update(edited);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
