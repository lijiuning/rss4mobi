using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Rss4Mobi.Models
{
    public class Member
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "电子邮件"), Required, DataType(DataType.EmailAddress), MaxLength(200), MinLength(5)]
        public string Email { get; set; }
        [Display(Name = "用户名称"),MaxLength(50),MinLength(3),DataType(DataType.Text)]
        public string Name { get; set; }
        [Display(Name = "密码"),Required,MaxLength(120),DataType(DataType.Password)]
        public string Password { get; set; }
        [ScaffoldColumn(false),StringLength(40)]
        public string GUID { get; set; }
        [ScaffoldColumn(false)]
        public DateTime RegisterDate { get; set; }
        [ScaffoldColumn(false)]
        public bool IsActive { get; set; }
    }


}