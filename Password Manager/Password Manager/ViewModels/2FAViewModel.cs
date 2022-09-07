using Common;
using Password_Manager.Commands._2FACommands;
using Password_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Password_Manager.ViewModels
{
    public class _2FAViewModel : BaseViewModel
    {
        #region fields
        private static List<_2FAModel> _2fAcollection;
        private string nickname;
        private string secret;
        private string additional;
        private static int selectedID;
        
        #endregion
        #region props

        public static int SelectedID
        {
            get { return selectedID; }
            set { selectedID = value; }
        }
        public List<_2FAModel> _2FACollection { get { return _2fAcollection; } set { _2fAcollection = value; } }
        public string Nickname { get { return nickname; } set { nickname = value; OnPropertyChanged("Nickname"); } }
        public string Secret { get { return secret; } set { secret = value; OnPropertyChanged("Secret"); } }
        public string Additional { get { return additional; } set { additional = value; OnPropertyChanged("Additional"); } }

        #endregion

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand GetSpecific2FA { get; }

        public _2FAViewModel()
        {
            AddCommand = new Add2FACommand(this);
            GetSpecific2FA = new GetSpecific2FA(this);
            DeleteCommand = new Delete2FACommand();
            _2FACollection = new List<_2FAModel>();
            UpdateList();
        }

        public List<_2FAModel> _2FAModels(Dictionary<int, string> getValues)
        {
            try
            {
                List<_2FAModel> retList = new List<_2FAModel>();

                foreach (int id in getValues.Keys)
                {
                    retList.Add(_2FAModel.Deserialize(getValues[id], id));
                }

                return retList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void UpdateList()
        {
            try
            {

                _2FACollection = _2FAModels(DatabaseManager.Get("_2FA", "")).OrderBy(x => x.Id).ToList();
            }
            catch(Exception ex)
            {
                _2FACollection.Clear();
            }
        }
        public int FindFirstId()
        {
            int result = 0;
            for (; result < _2fAcollection.Count; result++)
            {
                if (!_2fAcollection.Any(t => t.Id == result))
                {
                    break;
                }
            }
            return result;
        }
    }
}
