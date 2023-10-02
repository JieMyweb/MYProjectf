using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Project2.Models;

public partial class tOrderDetail
{
    public int fId { get; set; }
    [DisplayName("訂單編號")]
    public string fOrderGuid { get; set; }
    [DisplayName("會員帳號")]
    public string fUserId { get; set; }
    [DisplayName("產品編號")]
    public string fPId { get; set; }
    [DisplayName("品名")]
    public string fName { get; set; }
    [DisplayName("單價")]
    public int fPrice { get; set; }
    [DisplayName("訂購數量")]
    public int fQty { get; set; }
    [DisplayName("是否為訂單")]
    public string fIsApproved { get; set; }
}
