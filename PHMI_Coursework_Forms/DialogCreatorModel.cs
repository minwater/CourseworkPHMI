using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHMI_Coursework_Forms
{
    class DialogCreatorModel
    {
        private DialogCreatorPresenter presenter;
        Dialog dialog;
        List<DialogStep> steps = new List<DialogStep>();
        CreationMode mode;


        public DialogCreatorModel(DialogCreatorPresenter presenter)
        {
            this.presenter = presenter;
        }
        
        public enum CreationMode
        {
            Inner,
            Basic
        }



    }
}
