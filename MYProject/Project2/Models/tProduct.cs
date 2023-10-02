using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Project2.Models;

public partial class tProduct
{
    public int fId { get; set; }
    [DisplayName("產品編號")]
    public string fPId { get; set; }
    [DisplayName("品名")]
    public string fName { get; set; }
    [DisplayName("單價")]
    public int fPrice { get; set; }
    [DisplayName("圖示")]
    public string fImg { get; set; }
    [DisplayName("介紹")]
    public string fDescription { get; set; }
    [DisplayName("說明")]
    public string fDetail { get; set; }
}
