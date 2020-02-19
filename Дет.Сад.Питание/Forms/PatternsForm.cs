using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Дет.Сад.Питание.Models;

namespace Дет.Сад.Питание.Forms
{
    public partial class PatternsForm : Form
    {
        Pattern pattern;
        List<Pattern> patterns;
        MainForm main;
        public PatternsForm(MainForm main)
        {
            this.main = main;
            InitializeComponent();
            InitializeListBoxes();
        }

        private void PatternsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.WindowState = FormWindowState.Normal;
        }

        public void InitializeListBoxes()
        {
            lBPatterns.Items.Clear();
            if (File.Exists(Application.StartupPath + "\\Local Data\\patterns.pat"))
            {
                Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\patterns.pat", FileMode.Open);
                patterns = new BinaryFormatter().Deserialize(stream) as List<Pattern>;
                stream.Close();
            }
            lBPatterns.Items.Add(new Pattern
            {
                Name = "Новый вариант меню"
            });
            foreach (Pattern pattern in patterns)
                lBPatterns.Items.Add(pattern);
            lBPatterns.SelectedIndex = 0;
            cLBDishes.Items.Clear();
            foreach (DishDTO dish in MainForm.DB.Dishes.GetAll())
                cLBDishes.Items.Add(dish);
        }

        private void LBPatterns_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lBPatterns.SelectedItem != null)
            {
                pattern = (lBPatterns.SelectedItem as Pattern);
                lBZ.Items.Clear();
                lBO.Items.Clear();
                lBP.Items.Clear();
                tBName.Text = pattern.Name;
                cLBDishes.Items.Clear();
                foreach (DishDTO item in MainForm.DB.Dishes.GetAll())
                {
                    cLBDishes.Items.Add(item);
                }
                if (lBPatterns.SelectedIndex != 0)
                {
                    foreach (DishDTO dish in pattern.DishesZ)
                    {
                        lBZ.Items.Add(dish);
                        cLBDishes.Items.Remove(dish);
                    }
                    foreach (DishDTO dish in pattern.DishesO)
                    {
                        lBO.Items.Add(dish);
                        cLBDishes.Items.Remove(dish);
                    }
                    foreach (DishDTO dish in pattern.DishesP)
                    {
                        lBP.Items.Add(dish);
                        cLBDishes.Items.Remove(dish);
                    }
                }
                else
                {
                    pattern.DishesZ = new List<DishDTO>();
                    pattern.DishesO = new List<DishDTO>();
                    pattern.DishesP = new List<DishDTO>();
                }
            }
        }

        private void ButNew_Click(object sender, System.EventArgs e)
        {
            lBPatterns.SelectedIndex = 0;
            lBZ.Items.Clear();
            lBO.Items.Clear();
            lBP.Items.Clear();
            tBName.Text = lBPatterns.SelectedItem.ToString();
        }

        private void ButDel_Click(object sender, EventArgs e)
        {
            if (lBPatterns.SelectedItem != null)
            {
                patterns.Remove(lBPatterns.SelectedItem as Pattern);
                SavePatterns();
                InitializeListBoxes();
            }
        }

        public void SavePatterns()
        {
            if (File.Exists(Application.StartupPath + "\\Local Data\\patterns.pat"))
            {
                File.Delete(Application.StartupPath + "\\Local Data\\patterns.pat");
            }
            Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\patterns.pat", FileMode.CreateNew);
            var serializer = new BinaryFormatter();
            serializer.Serialize(stream, patterns);
            stream.Close();

        }

        private void ButClear_Click(object sender, EventArgs e)
        {
            foreach ( int item in cLBDishes.CheckedIndices)
            {
                cLBDishes.SetItemChecked(item, false);
            }
        }

        private void ButAddZ_Click(object sender, EventArgs e)
        {
            List<object> removedList = new List<object>();
            foreach (object item in cLBDishes.CheckedItems)
            {
                lBZ.Items.Add(item as DishDTO);
                lBO.Items.Remove(item as DishDTO);
                lBP.Items.Remove(item as DishDTO);
                removedList.Add(item);
            }
            foreach (object item in removedList)
            {
                cLBDishes.Items.Remove(item);
            }

        }

        private void ButAddO_Click(object sender, EventArgs e)
        {
            List<object> removedList = new List<object>();
            foreach (object item in cLBDishes.CheckedItems)
            {
                lBO.Items.Add(item as DishDTO);
                lBZ.Items.Remove(item as DishDTO);
                lBP.Items.Remove(item as DishDTO);
                removedList.Add(item);
            }
            foreach (object item in removedList)
            {
                cLBDishes.Items.Remove(item);
            }
        }

        private void ButAddP_Click(object sender, EventArgs e)
        {
            List<object> removedList = new List<object>();
            foreach (object item in cLBDishes.CheckedItems)
            {
                lBP.Items.Add(item as DishDTO);
                lBO.Items.Remove(item as DishDTO);
                lBZ.Items.Remove(item as DishDTO);
                removedList.Add(item);
            }
            foreach (object item in removedList)
            {
                cLBDishes.Items.Remove(item);
            }
        }

        private void ButDelZ_Click(object sender, EventArgs e)
        {
            if (lBZ.SelectedItems.Count > 0)
            {
                List<DishDTO> selectedItems = new List<DishDTO>(); 
                foreach (DishDTO item in lBZ.SelectedItems)
                {
                    cLBDishes.Items.Add(item);
                    selectedItems.Add(item);
                }
                foreach (DishDTO item in selectedItems)
                {
                    lBZ.Items.Remove(item);
                }
            }
        }

        private void ButDelO_Click(object sender, EventArgs e)
        {
            if (lBO.SelectedItems.Count > 0)
            {
                List<DishDTO> selectedItems = new List<DishDTO>();
                foreach (DishDTO item in lBO.SelectedItems)
                {
                    cLBDishes.Items.Add(item);
                    selectedItems.Add(item);
                }
                foreach (DishDTO item in selectedItems)
                {
                    lBO.Items.Remove(item);
                }
            }
        }

        private void ButDelP_Click(object sender, EventArgs e)
        {
            if (lBP.SelectedItems.Count > 0)
            {
                List<DishDTO> selectedItems = new List<DishDTO>();
                foreach (DishDTO item in lBP.SelectedItems)
                {
                    cLBDishes.Items.Add(item);
                    selectedItems.Add(item);
                }
                foreach (DishDTO item in selectedItems)
                {
                    lBP.Items.Remove(item);
                }
            }
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            if (tBName.Text != "")
            {
                patterns.Remove(pattern);
                pattern = new Pattern
                {
                    Name = tBName.Text,
                    DishesZ = new List<DishDTO>(),
                    DishesO = new List<DishDTO>(),
                    DishesP = new List<DishDTO>()
                };
                foreach (DishDTO item in lBZ.Items)
                {
                    pattern.DishesZ.Add(item);
                }
                foreach (DishDTO item in lBO.Items)
                {
                    pattern.DishesO.Add(item);
                }
                foreach (DishDTO item in lBP.Items)
                {
                    pattern.DishesP.Add(item);
                }
                patterns.Add(pattern);
                SavePatterns();
                InitializeListBoxes();
                MessageBox.Show("Вариант меню успешно сохранён");
            }
            else
                MessageBox.Show("Не заполнено имя варианта меню!","Ошибка");
        }
    }
}
