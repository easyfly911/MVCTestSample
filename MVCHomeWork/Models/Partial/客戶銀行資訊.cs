﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCHomeWork.Models {
    [MetadataType(typeof(客戶銀行資訊.Model))]
    public partial class 客戶銀行資訊 {
        private class Model {

            [Required(ErrorMessage = "請輸入{0}資料")]
            public int Id { get; set; }

            [Required(ErrorMessage = "請輸入{0}資料")]
            public int 客戶Id { get; set; }

            public string 銀行名稱 { get; set; }

            [Required(ErrorMessage = "請輸入{0}資料")]
            [RegularExpression("^[0-9]*$", ErrorMessage ="{0} 只能輸入數字")]
            public int 銀行代碼 { get; set; }

            [RegularExpression("^[0-9]*$", ErrorMessage = "{0} 只能輸入數字")]
            public Nullable<int> 分行代碼 { get; set; }

            [Required(ErrorMessage = "請輸入{0}資料")]
            public string 帳戶名稱 { get; set; }

            [Required(ErrorMessage = "請輸入{0}資料")]
            [RegularExpression("^.[A-Za-z0-9]+$", ErrorMessage = "{0} 只能輸入英文字母或數字")]
            public string 帳戶號碼 { get; set; }
        }

        /// <summary>
        /// 驗證銀行資訊是否重複
        /// </summary>
        /// <param name="CustID"></param>
        /// <param name="BankNo"></param>
        /// <param name="SubNo"></param>
        /// <param name="AccountNo"></param>
        /// <returns></returns>
        public bool CheckBankNoIsExists(int CustID, int BankNo, int? SubNo, string AccountNo) {
            bool resultValue = false;

            using (CustomEntities db = new CustomEntities()) {
                resultValue = db.客戶銀行資訊.Any(b => b.客戶Id == CustID && b.銀行代碼 == BankNo && b.分行代碼 == SubNo && b.帳戶號碼 == AccountNo);
            }

            return resultValue;
        }
    }
}