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
            SetActualNoteData(Repository.GetNote(ChooseNote.SelectedItem.ToString()));
        }


        private void SetActualNoteData(NoteModel note)
        {
            Name.Text          = note.Name;
            Price.Text         = note.Price.ToString();
            Type.Text          = note.Type;
            InCredit.IsChecked = note.InCredit;
            Description.Text   = note.Description;
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

                var note = new NoteModel();

                note.Name        = Name.Text;
                note.Price       = Int32.Parse(Price.Text);
                note.Type        = Type.Text;
                note.InCredit    = InCredit.IsChecked.Value;
                note.Description = Description.Text;

                Repository.Add(note);

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
            else if (!FormatVerification.IsDigital(Name.Text[0].ToString()))
            {
                MessageBox.Show("Поле имя не должно начинаться с цифры!");

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


            // Check price input
            if (FormatVerification.IsEmpty(Price.Text))
            {
                MessageBox.Show("Поле цена должно быть заполненно!");

                return false;
            }
            else if (FormatVerification.IsDigital(Price.Text))
            {
                MessageBox.Show("Поле цена должно содержать только числа!");

                return false;
            }
            else if (Int32.Parse(Price.Text) < 0)
            {
                MessageBox.Show("Цена не должна быть меньше 0");

                return false;
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
