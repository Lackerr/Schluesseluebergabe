using System.Collections.Generic;
using System.Windows.Controls;

namespace Schluesseluebergabe.Views
{
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
