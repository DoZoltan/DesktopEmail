﻿using MailKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Interfaces
{
    interface IGetMailService
    {
        static IMailFolder GetMessage();
    }
}
