using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace PR._15._11._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class Student
    {
        public string _Id { get; }
        public string _name { get; }
        public string _family { get; }
        public string _age { get; }
        public string _group { get; }
        
        public string GetGroup()
        {
            return _group;
        }
        public Student(string id,string name,string family, string age, string group)
        {
            _Id = id;
            _name = name;
            _family = family;
            _age = age;
            _group = group;
        }
    }
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> students;
        private List<Student> studentsActiveGroup = new List<Student>() { };
        
        private int i = 1;

        public MainWindow()
        {
            InitializeComponent();
            students = new ObservableCollection<string>();
            CB_Group.Items.Add("Isip-302");
            CB_GroupAdd.Items.Add("Isip-302");
            CB_GroupEdit.Items.Add("Isip-302");

            CB_Group.Items.Add("Isip-402");
            CB_GroupAdd.Items.Add("Isip-402");
            CB_GroupEdit.Items.Add("Isip-402");

            Student Students = new Student(i.ToString(), "апва", "ываыва", "ываыва", "Isip-302");
            i++;
            studentsActiveGroup.Add(Students);
            DG_Group.ItemsSource = studentsActiveGroup;
            DG_Group.Items.Refresh();
        }
        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if(TB_NameAdd.Text != string.Empty && TB_FamilyAdd.Text != string.Empty && TB_AgeAdd.Text != string.Empty && CB_GroupAdd.Text != string.Empty)
            {
                
                Student Students = new Student(i.ToString(), TB_NameAdd.Text, TB_FamilyAdd.Text, TB_AgeAdd.Text, CB_GroupAdd.Text);
                studentsActiveGroup.Add(Students);

                students.Add($"№ в группу: {i} | Имя: {TB_NameAdd.Text} | Фамилия: {TB_FamilyAdd.Text} | Возраст: {TB_AgeAdd.Text} | Группа: {CB_GroupAdd.Text}");
                i++;
                LB_Group.ItemsSource = students;
                DG_Group.ItemsSource = studentsActiveGroup;
                DG_Group.Items.Refresh();
            }
            else
            {
                MessageBox.Show("что-то не ввели(","Упс!",MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }
        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btb_Del_Click(object sender, RoutedEventArgs e)
        {
            if (TB_RowDel.Text == string.Empty) 
            { 
                if (DG_Group.SelectedIndex != -1)
                {
                    LB_Group.Items.RemoveAt(DG_Group.SelectedIndex);
                    studentsActiveGroup.RemoveAt(DG_Group.SelectedIndex);
                    
                    DG_Group.Items.Refresh();
                    

                }
                else
                {
                    MessageBox.Show("Вы не выбрали что удалять", "Упс", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                LB_Group.Items.RemoveAt(DG_Group.SelectedIndex);
                studentsActiveGroup.RemoveAt(Convert.ToInt32(TB_RowDel.Text));
                DG_Group.Items.Refresh();
            }
        }

        private void Btn_AddGroup_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new GroupInput();
            dialog.ShowDialog();
            CB_Group.Items.Add($"{dialog.ResponseText}");
            CB_GroupAdd.Items.Add($"{dialog.ResponseText}");
            CB_GroupEdit.Items.Add($"{dialog.ResponseText}");
        }
        
        private void CB_Group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DG_GroupSelectionChanged();
        }
        private void DG_GroupSelectionChanged() 
        {
            if (CB_Group.SelectedItem != Btn_AddGroup)
            {
                for (int i = 0; i < DG_Group.Items.Count; i++)
                {
                    DataGridRow row = (DataGridRow)DG_Group.ItemContainerGenerator.ContainerFromIndex(i);
                    TextBlock id = DG_Group.Columns[0].GetCellContent(row) as TextBlock;
                    TextBlock name = DG_Group.Columns[1].GetCellContent(row) as TextBlock;
                    TextBlock family = DG_Group.Columns[2].GetCellContent(row) as TextBlock;
                    TextBlock age = DG_Group.Columns[3].GetCellContent(row) as TextBlock;
                    TextBlock group = DG_Group.Columns[4].GetCellContent(row) as TextBlock;
                    if (group.Text == CB_Group.SelectedItem.ToString())
                    {
                        LB_Group.Items.Add($"№ в группе: {id.Text} | Имя: {name.Text} | Фамилия: {family.Text} | Возраст: {age.Text} | Группа: {group.Text}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Самый умный?", "Ммм", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void TB_RowEdit_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string txt = TB_RowEdit.Text;
            if (txt != "")
            {
                TB_RowEdit.Text = Regex.Replace(TB_RowEdit.Text, "[^0-9]", "");
                if (txt != TB_RowEdit.Text)
                {
                    TB_RowEdit.Select(TB_RowEdit.Text.Length, 0);
                }
            }
        }
    }
}
