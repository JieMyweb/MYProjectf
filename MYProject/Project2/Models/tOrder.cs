using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Project2.Models;

public partial class tOrder
{
    public int fId { get; set; }
    [DisplayName("訂單編號")]
    public string fOrderGuid { get; set; }
    [DisplayName("會員帳號")]
    public string fUserId { get; set; }
    [DisplayName("收件人姓名")]
    [Required(ErrorMessage = "請輸入姓名")]
    public string fReceiver { get; set; }
    [DisplayName("收件人信箱")]
    [Required(ErrorMessage = "請輸入信箱")]
    [EmailAddress(ErrorMessage = "信箱格式錯誤")]
    public string fEmail { get; set; }
    [DisplayName("收件人地址")]
    [Required(ErrorMessage = "請輸入地址")]
    public string fAddress { get; set; }
    [DisplayName("訂單日期")]
    public DateTime fDate { get; set; }
}
