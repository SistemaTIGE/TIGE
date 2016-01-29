using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TIGE.DAL;

namespace TIGE.Helpers
{
    public static class Extensions
    {
        public static int GetInstituicao(this System.Security.Principal.IIdentity source)
        {
            using (var db = TIGEContext.Create())
            {
                var instituicaoId = db.Users.Where(m => m.UserName.Equals(source.Name, StringComparison.CurrentCultureIgnoreCase))
                    .FirstOrDefault().InstituicaoID;

                return instituicaoId;
            }
        }
    }
}