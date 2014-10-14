using HLP.Controls.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.ViewModel.ViewModel
{
    public class CustomComboBoxViewModel
    {
        public Dictionary<object, string> GetItemsList(string xItemsList)
        {
            try
            {
                Dictionary<object, string> dictRet = new Dictionary<object, string>();
                foreach (var items in xItemsList.Split(';'))
                {
                    if (items.ToString() != "")
                        if (items.Contains(","))
                            dictRet.Add(key: items.Split(',')[0], value: items.Split(',')[1].ToString().Trim());

                }
                return dictRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<ItemsComboBoxModel> GetItemsList2(string xItemsList)
        {
            try
            {
                List<ItemsComboBoxModel> lRet = new List<ItemsComboBoxModel>();
                foreach (var items in xItemsList.Split(';'))
                {
                    if (items.ToString() != "")
                        if (items.Contains(","))
                            lRet.Add(new ItemsComboBoxModel
                            {
                                index = items.Split(',')[0],
                                display = items.Split(',')[1]
                            });

                }
                return new ObservableCollection<ItemsComboBoxModel>(lRet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
