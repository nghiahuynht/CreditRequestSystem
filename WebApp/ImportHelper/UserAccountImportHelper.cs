using DAL.Entities;
using DAL.Models.UserInfo;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ExcelHelper;

namespace WebApp.ImportHelper
{
    public class UserAccountImportHelper: ExcelUtil
    {
        public List<UserInfoImportModel> list;

        public UserAccountImportHelper(string folder) : base(folder)
        {
            list = new List<UserInfoImportModel>();
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

                UserInfoImportModel p = new UserInfoImportModel();
                p.FullName = ToString(row.GetCell(0));
                p.SDT = ToString(row.GetCell(1));
                p.Email = ToString(row.GetCell(2));
                p.Title = ToString(row.GetCell(3));
                p.DepartmentCode = ToString(row.GetCell(4));
                list.Add(p);

            }

            return true;
        }
    }
}
