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
using TXTextControl.DocumentServer;
using TXTextControl;
using System.IO;

namespace Schluesseluebergabe.Views
{
    /// <summary>
    /// Interaktionslogik für CreateNewHandoverView.xaml
    /// </summary>
    public partial class CreateNewHandoverView : UserControl
    {

        private List<TextBox> _textBoxes;
       

        public CreateNewHandoverView()
        {
            InitializeComponent();
            _textBoxes = GetTextBoxes();
        }

        private List<TextBox> GetTextBoxes()
        {
            List<TextBox> list = new()
            {
                TxtRecipientName,
                TxtRecipientForeName,
                TxtRecipientId,
                TxtSenderName,
                TxtSenderForeName,
                TxtKeyId,
                TxtGeoDataCity
            };
            return list;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BttnSubmit.IsEnabled = true;
            foreach (var item in _textBoxes)
            {
                if (item.Text == null || item.Text == "")
                {
                    BttnSubmit.IsEnabled = false;
                    return;
                }
            }
            if (DatePicker.SelectedDate == null)
            {
                BttnSubmit.IsEnabled = false;
            }
        }

        
    }
}
