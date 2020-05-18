using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab10_var3
{
    /// <summary>
    /// Interaction logic for UpdateNote.xaml
    /// </summary>
    public partial class UpdateNote : Window
    {
        public UpdateNote()
        {
            InitializeComponent();

            var list = Repository.GetAllName();
            ChooseNote.ItemsSource = list;
        }


        private void Button_Click_Choose(object sender, SelectionChangedEventArgs e)
        {
            SetActualNoteData(Repository.GetMed(ChooseNote.SelectedItem.ToString()));
        }


        private void SetActualNoteData(MedModel med)
        {
            Id.Text = med.Id.ToString();
            Name.Text = med.Name;          
            Adres.Text = med.Adress;
            Type.Text = med.Type;
            Description.Text = Description.Text;
        }


        private void Button_Click_DeleteNote(object sender, RoutedEventArgs e)
        {
            // Check dont choose note
            if (FormatVerification.IsEmpty(ChooseNote.Text))
            {
                MessageBox.Show("Выбирете запись для обновления");

                return;
            }


            MessageBoxButton modalConfirm = MessageBoxButton.YesNo;
            MessageBoxResult modalConfirmResult = MessageBox.Show($"Вы хотите удалить запись \"{Name.Text}\" из базы?", "Удаление записи", modalConfirm);

            if (modalConfirmResult == MessageBoxResult.Yes)
            {
                Repository.DeleteByName(Name.Text);

                MessageBox.Show($"Запись с именем {Name.Text} успешно удаленна");

                this.Hide();
            }
        }


        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            if (!CheckData())
            {
                return;
            }


            MessageBoxButton modalConfirm = MessageBoxButton.YesNo;
            MessageBoxResult modalConfirmResult = MessageBox.Show($"Вы хотите обновить запись \"{Name.Text}\" в базе?", "Удаление записи", modalConfirm);

            if (modalConfirmResult == MessageBoxResult.Yes)
            {
                // TODO: FIX query
                Repository.DeleteByName(ChooseNote.Text);

                var model = new MedModel();

                model.Id = Int32.Parse(Id.Text);
                model.Name = Name.Text;
                model.Adress = Adres.Text;
                model.Type = Type.Text;
                model.Description = Description.Text;

                Repository.Add(model);

                MessageBox.Show($"Запись с именем {Name.Text} успешно обновленна");

                this.Hide();
            }
        }


        private bool CheckData()
        {
            // Check dont choose note
            if (FormatVerification.IsEmpty(ChooseNote.Text))
            {
                MessageBox.Show("Выбирете запись для обновления");

                return false;
            }

            // Check id input
            if (FormatVerification.IsEmpty(Id.Text))
            {
                MessageBox.Show("Поле код должно быть заполненно!");

                return false;
            }
            else if (FormatVerification.SpaceCheck(Id.Text))
            {
                MessageBox.Show("Поле код не должно иметь пробелы!");

                return false;
            }
            else if (FormatVerification.IsDigital(Id.Text))
            {
                MessageBox.Show("Поле код должно состоять только из чисел!");

                return false;
            }
            else
            {
                var list = Repository.GetAllId();

                foreach (var i in list)
                {
                    if (Id.Text == ChooseNote.Text)
                    {
                        continue;
                    }

                    if (i == Name.Text)
                    {
                        MessageBox.Show("Запись с таким кодом уже существует");

                        return false;
                    }
                }
            }


            // Check name input
            if (FormatVerification.IsEmpty(Name.Text))
            {
                MessageBox.Show("Поле имя должно быть заполненно!");

                return false;
            }
            else if (FormatVerification.SpaceCheck(Name.Text))
            {
                MessageBox.Show("Поле имя не должно иметь пробелы!");

                return false;
            }
            else
            {
                var list = Repository.GetAllName();

                foreach (var i in list)
                {
                    if (Name.Text == ChooseNote.Text)
                    {
                        continue;
                    }

                    if (i == Name.Text)
                    {
                        MessageBox.Show("Запись с таким именем уже существует");

                        return false;
                    }
                }
            }


            // Check type input
            if (FormatVerification.IsEmpty(Type.Text))
            {
                MessageBox.Show("Тип должен быть выбран!");

                return false;
            }

            return true;
        }
    }
}
