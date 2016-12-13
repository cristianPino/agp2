using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class MailBCA
    {
        private int codigo;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string subject;
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        private string body;
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        private string ccopy;
        public string Ccopy
        {
            get { return ccopy; }
            set { ccopy = value; }
        }
       
        private string firma;
        public string Firma
        {
            get { return firma; }
            set { firma = value; }
        }

    }
}
