using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class MailBCABC
    {
        public MailBCA getMailbycodigo(Int32 id_mail)
        {
            MailBCA mMail = new MailBCADAC().getMAilBycodigo(id_mail);
            return mMail;
        }
    }
}
