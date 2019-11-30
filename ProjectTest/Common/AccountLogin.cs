using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Common
{
    [Serializable]
    public class AccountLogin
    {
        public long AccountId { set; get; }
        public string UserName { set; get; }
    }
}
