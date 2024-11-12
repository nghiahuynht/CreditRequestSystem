using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;


namespace WebApp.ExcelHelper
{
    public abstract class ExcelUtil
    {
        public string err;

        protected string refNo;
        protected string rootFolder;
        protected int sheetNo = 0;
        protected abstract bool Parse(ISheet sheet);

        protected HSSFWorkbook hssBook = null;
        protected XSSFWorkbook xssBook = null;

        public ExcelUtil(string folder)
        {
            this.rootFolder = folder;
        }

        public virtual bool Parse(IFormFile file)
        {
            var fName = file.FileName;
            var folder = $"{rootFolder}\\Import";
            var fileName = Path.Combine(folder, fName);

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            return Parse(file, fileName);
        }

        protected virtual bool Parse(IFormFile file, string fileName)
        {
            bool res = false;
            try
            {
                string ext = Path.GetExtension(file.FileName).ToLower();

                if (ext != ".xls" && ext != ".xlsx")
                    return res;

                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                    res = Parse(stream, ext);
                }
            }
            catch (Exception ex)
            {
                err = "ExcelUtil: " + ex.Message;
            }

            return res;
        }

        protected virtual bool Parse(Stream stream, string ext)
        {
            ISheet sheet = OpenSheet(stream, ext, sheetNo);

            return Parse(sheet);
        }

        protected virtual ISheet OpenSheet(Stream stream, string ext, int sheetNo)
        {
            ISheet sheet;

            if (xssBook != null)
            {
                sheet = xssBook.GetSheetAt(sheetNo);
            }
            else if (hssBook != null)
            {
                sheet = hssBook.GetSheetAt(sheetNo);
            }
            else
            {
                stream.Position = 0;

                if (ext == ".xls")
                {
                    HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                    sheet = hssfwb.GetSheetAt(sheetNo);
                    hssBook = hssfwb;
                }
                else
                {
                    XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                    sheet = hssfwb.GetSheetAt(sheetNo);
                    xssBook = hssfwb;
                }
            }

            return sheet;
        }

        protected int? ToInt(ICell cell)
        {
            if (cell != null && 
                (cell.CellType == CellType.Numeric || (cell.CellType == CellType.Formula && cell.CachedFormulaResultType == CellType.Numeric)))
                return Convert.ToInt32(cell.NumericCellValue);
            else
                return null;
        }

        protected int ToIntOrZero(ICell cell)
        {
            if (cell != null && (cell.CellType == CellType.Numeric 
                || (cell.CellType == CellType.Formula && cell.CachedFormulaResultType == CellType.Numeric)
                || cell.CellType == CellType.String))
                return Convert.ToInt32(cell.NumericCellValue);
            else
                return 0;
        }

        protected long ToLong(ICell cell)
        {
            if (cell != null && (cell.CellType == CellType.Numeric || (cell.CellType == CellType.Formula && cell.CachedFormulaResultType == CellType.Numeric)))
                return Convert.ToInt64(cell.NumericCellValue);
            else
                return 0;
        }

        protected string ToString(ICell cell)
        {
            if (cell != null && (cell.CellType == CellType.String || (cell.CellType == CellType.Formula && cell.CachedFormulaResultType == CellType.String)))
                return cell.StringCellValue;
            else if (cell != null && (cell.CellType == CellType.Numeric || (cell.CellType == CellType.Formula && cell.CachedFormulaResultType == CellType.Numeric)))
                return "" + cell.NumericCellValue;
            else
                return null;
        }

        protected decimal? ToDecimal(ICell cell)
        {
            if (cell != null && (cell.CellType == CellType.Numeric || (cell.CellType == CellType.Formula && cell.CachedFormulaResultType == CellType.Numeric)))
                return Convert.ToDecimal(cell.NumericCellValue);
            else
                return null;
        }

        protected bool? ToBool(ICell cell)
        {
            if (cell != null && (cell.CellType == CellType.Boolean || (cell.CellType == CellType.Formula && cell.CachedFormulaResultType == CellType.Boolean)))
                return cell.BooleanCellValue;
            else
                return null;
        }

        protected DateTime? ToDate(ICell cell)
        {
            if (cell != null)
            {
                try
                {
                    if (cell.CellType == CellType.Numeric)
                    {
                        if (cell.DateCellValue.Year < 1900)
                            return null;
                        else
                            return cell.DateCellValue;
                    }

                    if (cell.CellType == CellType.String)
                        return Convert.ToDateTime(cell.StringCellValue);
                }
                catch
                {
                }
            }

            return null;
        }
    }
}
