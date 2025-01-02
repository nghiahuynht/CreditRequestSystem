using DAL.Models.ProjectFinancialSummar;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ExcelHelper;

namespace WebApp.ImportHelper
{
    public class PlaningProjectImportHelper : ExcelUtil
    {
        public List<ProjectPlaningImportModel> list;

        public PlaningProjectImportHelper(string folder) : base(folder)
        {
            list = new List<ProjectPlaningImportModel>();
        }

        protected override bool Parse(ISheet sheet)
        {
            for (int i = 3; i <= sheet.LastRowNum + 1; i++) //Read Excel File
            {
                IRow row = sheet.GetRow(i);

                if (row == null)
                    continue;

                if (row.Cells.All(d => d.CellType == CellType.Blank))
                    continue;

                ProjectPlaningImportModel p = new ProjectPlaningImportModel();
                p.ProjectCode = ToString(row.GetCell(0));
                p.ProjectName = ToString(row.GetCell(1));
                p.ActivitiCode = ToString(row.GetCell(2));
                p.ActivitiName = ToString(row.GetCell(3));
                p.ExpenseCode = ToString(row.GetCell(4));
                p.ExpenseName = ToString(row.GetCell(5));
                p.TieuMuc = ToString(row.GetCell(6));
                p.TieuChuan = ToString(row.GetCell(7));
                p.DonVi = ToString(row.GetCell(8));
                p.Quanti = ToInt(row.GetCell(9));
                p.Price = ToDecimal(row.GetCell(10));
                list.Add(p);

            }

            return true;
        }
    }
}
