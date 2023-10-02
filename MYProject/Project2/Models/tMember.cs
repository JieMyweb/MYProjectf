using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Project2.Models;

public partial class tMember
{
    public int fId { get; set; }
    [DisplayName("帳號")]
    [Required(ErrorMessage = "請輸入帳號")]
    public string fUserId { get; set; }
    [DisplayName("密碼")]
    [Required(ErrorMessage = "請輸入密碼")]
    public string fPwd { get; set; }
    [DisplayName("姓名")]
    [Required(ErrorMessage = "請輸入姓名")]
    public string fName { get; set; }
    [DisplayName("信箱")]
    [Required(ErrorMessage = "請輸入信箱")]
    [EmailAddress(ErrorMessage = "信箱格式錯誤")]
    public string fEmail { get; set; }
}
