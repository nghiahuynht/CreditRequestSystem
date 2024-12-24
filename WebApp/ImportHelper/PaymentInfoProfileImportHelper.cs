using DAL.Models.Category;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ExcelHelper;

namespace WebApp.ImportHelper
{
    public class PaymentInfoProfileImportHelper: ExcelUtil
    {
        public List<CategoryPaymentInfoModel> list;

        public PaymentInfoProfileImportHelper(string folder) : base(folder)
        {
            list = new List<CategoryPaymentInfoModel>();
        }

        protected override bool Parse(ISheet sheet)
        {
            for (int i = 1; i <= sheet.LastRowNum + 1; i++) //Read Excel File
            {
                IRow row = sheet.GetRow(i);

                if (row == null)
                    continue;

                if (row.Cells.All(d => d.CellType == CellType.Blank))
                    continue;

                CategoryPaymentInfoModel p = new CategoryPaymentInfoModel();
                p.PaymentInfoCode = ToString(row.GetCell(0));
                p.PaymentInfoName = ToString(row.GetCell(1));
                p.Notes = ToString(row.GetCell(2));
                p.IsRequiredDoc = (ToString(row.GetCell(3)).ToUpper()=="CÓ" || ToString(row.GetCell(3)).ToUpper() == "CÓ") ? true:false;
                list.Add(p);

            }

            return true;
        }
    }
}
