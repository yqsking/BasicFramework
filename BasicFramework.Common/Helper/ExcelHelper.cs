using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFramework.Common.Helper
{
    /// <summary>
    /// excel工具类
    /// </summary>
    public  static class ExcelHelper
    {
        //public static ISheet ImportExcel(IFormFile file,int sheetIndex=0)
        //{
        //    var fileExt = Path.GetExtension(file.FileName).ToLower();
        //    if (fileExt != ".xls" && fileExt != ".xlsx" )
        //    {
        //        throw new Exception("文件类型错误");
        //    }
        //    var stream = file.OpenReadStream();
        //    stream.Position = 0;
        //    if (fileExt == ".xls")
        //    {
        //        HSSFWorkbook hssfwb = new HSSFWorkbook(stream);
        //        return hssfwb.GetSheetAt(sheetIndex);
        //    }
        //    else
        //    {
        //        XSSFWorkbook hssfwb = new XSSFWorkbook(stream);
        //        return hssfwb.GetSheetAt(sheetIndex);
        //    }
        //}
    }
}
