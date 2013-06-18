using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rss4Mobi.Models
{
    public class MemberService
    {

        public static bool ActivateUser(int id,string code)
        {
            using(var db=new Rss4MobiDBContext())
            {
                var member = db.Members.Where(p => p.ID == id && p.GUID == code&&!p.IsActive);
                if(member.Any())
                {
                    member.First().IsActive = true;
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}